using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ApplicantId { get; set; }
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
