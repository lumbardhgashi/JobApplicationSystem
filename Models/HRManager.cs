using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class HRManager
    {
        [Key]
        public int HRManagerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
