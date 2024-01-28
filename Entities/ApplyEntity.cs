using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class ApplyEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        [ForeignKey("JobPosting")]
        public int JobPostId { get; set; }
        public ApplicantEntity Applicant { get; set; }
        public JobPostingEntity JobPosting { get; set; }
        public ReviewApplicationEntity ReviewApplication { get; set; }
        
    }
}
