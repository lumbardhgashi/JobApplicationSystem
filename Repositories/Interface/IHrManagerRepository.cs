using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IHrManagerRepository
    {
        public HRManagerEntity CreateHrManger(HRManagerEntity hRManager);
        public void UpdateHrManager(HRManagerEntity hrManager);
        public void DeleteHrManager(int id);
        public HRManagerEntity GetHrManagerById(int id);
        public List<HRManagerEntity> GetAllHrManagers();
    }
}
