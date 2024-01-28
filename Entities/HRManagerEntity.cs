using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class HRManagerEntity
    {
        [Key]
        public int HRManagerId { get; set; }
        
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        public CompanyEntity Company { get; set; }
        public ICollection<JobPostingEntity> JobPosting { get; set; }
        public ICollection<ReviewApplicationEntity> ReviewApplications { get; set; }
    }
}
