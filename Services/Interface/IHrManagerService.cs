using JobApplicationSystem.Models;
namespace JobApplicationSystem.Services.Interface
{
    public interface IHrManagerService
    {
        public HRManager CreateHrManager(HRManager hRManager);
        public void UpdateHrManager(HRManager hrManager);
        public void DeleteHrManager(int id);
        public HRManager GetHrManagerById(int id);
        public List<HRManager> GetAllHrManager();
    }
}
