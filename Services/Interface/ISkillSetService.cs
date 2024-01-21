using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface ISkillSetService
    {
        public SkillSet CreateSkillSet(SkillSet skillSet);
        public void UpdateSkillSet(SkillSet skillSet);
        public void DeleteSkillSet(int id);
        public SkillSet GetSkillSetById(int id);
        public List<SkillSet> GetAllSkillSet();
    }
}