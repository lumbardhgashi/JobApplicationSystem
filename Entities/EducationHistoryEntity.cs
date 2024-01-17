using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Entities
{
    public class EducationHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int School { get; set; }
        [Required]
        public int StartDate { get; set; }
        [Required]
        public int EndDate { get; set; }
        [Required]
        public string AvgGrade { get; set; }
        [Required]
        public string ApplicantId { get; set; }
    }
}
