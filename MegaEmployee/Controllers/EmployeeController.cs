using Microsoft.AspNetCore.Mvc;
using MegaEmployee.Models;

namespace MegaEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDatabaseContext _db;

        public EmployeeController(AppDatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Employee> data = _db.Employees.ToList();
            return View(data);
        }

        public IActionResult Read(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var data = _db.Employees.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _db.Employees.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var data = _db.Employees.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee data)
        {
            var obj = _db.Employees.Find(data.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
