using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IApplicationStatusService
    {
        public ApplicationStatus CreateApplicationStatus(ApplicationStatus applicationStatus);
        public void UpdateApplicationStatus(ApplicationStatus applicationStatus);
        public void DeleteApplicationStatus(int id);
        public ApplicationStatus GetApplicationStatusById(int id);
        public List<ApplicationStatus> GetAllApplicationStatus();
    }
}
