using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class ReviewApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int HrManagerId { get; set; }
        [Required]
        public int ApplyId { get; set; }
        [Required]
        public string PointOfReview { get; set; }
    }
}
