using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface ISkillSetRepository
    {
        public SkillSetEntity CreateSkillSet(SkillSetEntity skillSet);
        public void UpdateSkillSet(SkillSetEntity skillSet);
        public void DeleteSkillSet(int id);
        public SkillSetEntity GetSkillSetById(int id);
        public List<SkillSetEntity> GetAllSkillSet();
    }
}
