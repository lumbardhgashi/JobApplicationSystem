using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IExperienceService
    {
        public Experience CreateExperience(Experience experience);
        public void UpdateExperience(Experience experience);
        public void DeleteExperience(int id);
        public Experience GetExperienceById(int id);
        public List<Experience> GetAllExperience();
    }
}
