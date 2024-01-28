using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Entities
{
    public class CompanyEntity
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Sektori { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NumriTelefonit { get; set; }
        public ICollection<DepartmentEntity> Departments { get; set; }
        public ICollection<HRManagerEntity> HRManagers { get; set; }

    }
}
