using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class EducationHistory
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
        [Required]
        public int ApplicantId { get; set; }
    }
}
