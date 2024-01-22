using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class ApplicationStatusRepository: IApplicationStatusRepository
    {
        private readonly AppDbContext _dbContext;
        public ApplicationStatusRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationStatusEntity CreateApplicationStatus(ApplicationStatusEntity applicationStatus)
        {
            _dbContext.ApplicationStatuses.Add(applicationStatus);
            _dbContext.SaveChanges();
            return applicationStatus;
        }

        public void DeleteApplicationStatus(int id)
        {
            var deletedApplicationStatus = _dbContext.ApplicationStatuses.Find(id);
            _dbContext.ApplicationStatuses.Remove(deletedApplicationStatus);
            _dbContext.SaveChanges();
        }

        public List<ApplicationStatusEntity> GetAllApplicationStatus()
        {
            var allApplicationStatus = _dbContext.ApplicationStatuses.ToList();
            return allApplicationStatus;
        }

        public ApplicationStatusEntity GetApplicationStatusById(int id)
        {
            var applicationStatusById = _dbContext.ApplicationStatuses.Find(id);
            return applicationStatusById;
        }

        public void UpdateApplicationStatus(ApplicationStatusEntity applicationStatus)
        {
            var oldApplicationStatus = _dbContext.ApplicationStatuses.Find(applicationStatus.Id);
            _dbContext.ApplicationStatuses.Entry(oldApplicationStatus).CurrentValues.SetValues(applicationStatus);
            _dbContext.SaveChanges();
        }
    }
}
