using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class ApplicationStatusEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ReviewApplication")]
        public int ReviewApplicationId { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        [Required]
        public string Status { get; set; }
        public string StatusDescription { get; set; }

        public ReviewApplicationEntity ReviewApplication { get; set; }
        public ApplicantEntity Applicant { get; set; }
    }
}
