using System.ComponentModel.DataAnnotations;

namespace MegaEmployee.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
