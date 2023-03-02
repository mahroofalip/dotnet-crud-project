using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.EfCore
{
    [Table("Employees")]
    public class Employees
    {
        [Key,Required]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Salary { get; set; }  
        public string? Department { get; set; }

    }
}
