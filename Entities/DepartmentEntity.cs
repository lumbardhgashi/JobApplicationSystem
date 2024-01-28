using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class DepartmentEntity
    {
        [Key]
        public int DepartmentId { get; set; }
        
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int NumriPunonjesve { get; set; }
        [Required]
        public string DrejtoriDepartamentit { get; set; }
        public CompanyEntity Company { get; set; }
        public ICollection<JobPostingEntity> JobPosting { get; set; }
    }
}
