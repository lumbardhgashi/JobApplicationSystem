using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class ReviewApplicationEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("HrManager")]
        public int HrManagerId { get; set; }
        [ForeignKey("Apply")]
        public int ApplyId { get; set; }
        [Required]
        public string PointOfReview { get; set; }
        public HRManagerEntity HRManager { get; set; }
        public ApplyEntity Apply { get; set; }
        public ApplicationStatusEntity ApplicationStatus { get; set; }
    }
}
