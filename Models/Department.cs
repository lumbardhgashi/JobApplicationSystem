using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int NumriPunonjesve { get; set; }
        [Required]
        public string DrejtoriDepartamentit { get; set; }
    }
}
