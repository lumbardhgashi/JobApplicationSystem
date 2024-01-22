using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly AppDbContext _dbContext;
        public ExperienceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ExperienceEntity CreateExperience(ExperienceEntity experience)
        {
            _dbContext.Experiences.Add(experience);
            _dbContext.SaveChanges();
            return experience;
        }

        public void DeleteExperience(int id)
        {
            var experinces = _dbContext.Experiences.Find(id);
            _dbContext.Experiences.Remove(experinces);
            _dbContext.SaveChanges();
        }

        public List<ExperienceEntity> GetAllExperience()
        {
            var experience = _dbContext.Experiences.ToList();
            return experience;
        }

        public ExperienceEntity GetExperienceById(int id)
        {
            var experience = _dbContext.Experiences.Find(id);
            return experience;
        }

        public void UpdateExperience(ExperienceEntity experience)
        {
            var oldExperience = _dbContext.Experiences.Find(experience.Id);
            _dbContext.Experiences.Entry(oldExperience).CurrentValues.SetValues(experience);
            _dbContext.SaveChanges();
        }
    }
}
