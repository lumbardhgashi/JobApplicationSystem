using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class HrManagerRepository : IHrManagerRepository
    {
        private readonly AppDbContext _dbContext;
        public HrManagerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public HRManagerEntity CreateHrManger(HRManagerEntity hRManager)
        {
            _dbContext.HrManagers.Add(hRManager);
            _dbContext.SaveChanges();
            return hRManager;
        }

        public void DeleteHrManager(int id)
        {
            var HrManager = _dbContext.HrManagers.Find(id);
            _dbContext.HrManagers.Remove(HrManager);
            _dbContext.SaveChanges();
        }

        public List<HRManagerEntity> GetAllHrManagers()
        {
            var HrManager = _dbContext.HrManagers.ToList();
            return HrManager;
        }

        public HRManagerEntity GetHrManagerById(int id)
        {
            var HrManager = _dbContext.HrManagers.Find(id);
            return HrManager;
        }

        public void UpdateHrManager(HRManagerEntity hrManager)
        {
            var oldHrManager = _dbContext.HrManagers.Find(hrManager.HRManagerId);
            _dbContext.HrManagers.Entry(oldHrManager).CurrentValues.SetValues(hrManager);
            _dbContext.SaveChanges();
        }
    }
}
