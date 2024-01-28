using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class ApplicationStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ReviewApplicationId { get; set; }
        [Required]
        public int ApplicantId { get; set; }
        [Required]
        public string Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
