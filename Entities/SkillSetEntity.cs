using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Entities
{
    public class SkillSetEntity
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
