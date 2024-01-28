using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.Entities
{
    public class ApplicantEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<SkillSetEntity> Skills { get; set; }
        public ICollection<ExperienceEntity> Experiences { get; set; }
        public ICollection<EducationHistoryEntity> Educations { get; set; }
        public ICollection<ApplyEntity> Applies { get; set; }
        public ApplicationStatusEntity ApplicationStatus { get; set; }

    }
}
