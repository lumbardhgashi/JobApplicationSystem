using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class EducationHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string AvgGrade { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public ApplicantEntity Applicant { get; set; }
    }
}
