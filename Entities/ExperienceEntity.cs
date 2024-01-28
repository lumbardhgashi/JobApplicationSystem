using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class ExperienceEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public ApplicantEntity Applicant { get; set; }

    }
}
