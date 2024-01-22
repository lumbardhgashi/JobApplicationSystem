using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class EducationHistoryRepository : IEducationHistoryRepository
    {
        private readonly AppDbContext _dbContext;
        public EducationHistoryRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public EducationHistoryEntity CreateEducationHistory(EducationHistoryEntity educationHistory)
        {
            _dbContext.EducationHistories.Add(educationHistory);
            _dbContext.SaveChanges();
            return educationHistory;
        }

        public void DeleteEducationHistory(int id)
        {
            var educationHistory = _dbContext.EducationHistories.Find(id);
            _dbContext.EducationHistories.Remove(educationHistory);
            _dbContext.SaveChanges();
        }

        public List<EducationHistoryEntity> GetAllEducationHistory()
        {
            var educationHistory = _dbContext.EducationHistories.ToList();
            return educationHistory;
        }

        public EducationHistoryEntity GetEducationHistoryById(int id)
        {
            var educationHistory = _dbContext.EducationHistories.Find(id);
            return educationHistory;

        }

        public void UpdateEducationHistory(EducationHistoryEntity educationHistory)
        {
            var oldEducationHistory = _dbContext.EducationHistories.Find(educationHistory.Id);
            _dbContext.EducationHistories.Entry(oldEducationHistory).CurrentValues.SetValues(educationHistory);
            _dbContext.SaveChanges();
        }
    }
}
