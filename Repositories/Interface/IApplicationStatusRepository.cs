using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IApplicationStatusRepository
    {
        public ApplicationStatusEntity CreateApplicationStatus(ApplicationStatusEntity applicationStatus);
        public void UpdateApplicationStatus(ApplicationStatusEntity applicationStatus);
        public void DeleteApplicationStatus(int id);
        public ApplicationStatusEntity GetApplicationStatusById(int id);
        public List<ApplicationStatusEntity> GetAllApplicationStatus();
    }
}
