using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Models
{
    public class SkillSet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ApplicantId { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        public string Pointer { get; set; }
    }
}
