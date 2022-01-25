using MegaEmployee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MegaEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private readonly AppDatabaseContext _db;

        public EmployeeApiController(AppDatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppDatabaseContext>>> Get()
        {
            return Ok(await _db.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AppDatabaseContext>>> Get(int id)
        {
            var data = await _db.Employees.FindAsync(id);
            if(data == null)
            {
                return BadRequest("Employee Data not found!");
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<List<AppDatabaseContext>>> Post(Employee emp)
        {
            _db.Employees.Add(emp);
            await _db.SaveChangesAsync();
            return Ok(await _db.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<AppDatabaseContext>>> Put(Employee emp)
        {
            var data = _db.Employees.Find(emp.Id);
            if(data == null)
            {
                return BadRequest("Employee not found!");
            }
            data.Name = emp.Name;
            data.Type = emp.Type;
            await _db.SaveChangesAsync();
            return Ok(await _db.Employees.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AppDatabaseContext>>> Delete(int id)
        {
            var data = await _db.Employees.FindAsync(id);
            if(data == null)
            {
                return BadRequest("Employee not found!");
            }
            _db.Employees.Remove(data);
            await _db.SaveChangesAsync();
            return Ok();    //await _db.Employees.ToListAsync()
        }
    }
}
