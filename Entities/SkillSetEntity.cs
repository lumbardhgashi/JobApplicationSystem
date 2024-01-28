using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplicationSystem.Entities
{
    public class SkillSetEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Pointer { get; set; }
        public ApplicantEntity Applicant { get; set; }
    }
}
