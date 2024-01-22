using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IExperienceRepository
    {
        public ExperienceEntity CreateExperience(ExperienceEntity experience);
        public void UpdateExperience(ExperienceEntity experience);
        public void DeleteExperience(int id);
        public ExperienceEntity GetExperienceById(int id);
        public List<ExperienceEntity> GetAllExperience();
    }
}
