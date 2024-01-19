using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IApplyService
    {
        public Apply CreateApply(Apply apply);
        public void UpdateApply(Apply apply);
        public Apply GetApplyById(int id);
        public List<Apply> GetAllApplies();
        public void DeleteApply(int id);
    }
}
