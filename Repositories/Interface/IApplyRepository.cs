

using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IApplyRepository
    {
        public ApplyEntity CreateApply(ApplyEntity apply);
        public void UpdateApply(ApplyEntity apply);
        public void DeleteApply(int id);
        public ApplyEntity GetApplyById(int id);
        public List<ApplyEntity> GetAllApplies();
    }
}
