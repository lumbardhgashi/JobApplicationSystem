using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Entities
{
    public class ExperienceEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ApplicantId { get; set; }
        [Required]
        public int StartDate { get; set; }
        [Required]
        public int EndDate { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
