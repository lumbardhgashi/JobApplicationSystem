using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class ApplyRepository:IApplyRepository
    {
        private readonly AppDbContext _dbContext;
        public ApplyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplyEntity CreateApply(ApplyEntity apply)
        {
            _dbContext.Applies.Add(apply);
            _dbContext.SaveChanges();
            return apply;
        }

        public void DeleteApply(int id)
        {
            var deletedApply = _dbContext.Applies.Find(id);
            _dbContext.Applies.Remove(deletedApply);
            _dbContext.SaveChanges();
        }

        public List<ApplyEntity> GetAllApplies()
        {
            var allApplies = _dbContext.Applies.ToList();
            return allApplies;
        }

        public ApplyEntity GetApplyById(int id)
        {
            var applyById = _dbContext.Applies.Find(id);
            return applyById;
        }

        public void UpdateApply(ApplyEntity apply)
        {
            var oldApply = _dbContext.Applies.Find(apply.Id);
            _dbContext.Applies.Entry(oldApply).CurrentValues.SetValues(apply);
            _dbContext.SaveChanges();
        }
    }
}
