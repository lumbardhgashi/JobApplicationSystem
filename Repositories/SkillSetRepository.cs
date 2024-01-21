using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class SkillSetRepository : ISkillSetRepository
    {
        private readonly AppDbContext _dbContext;
        public SkillSetRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SkillSetEntity CreateSkillSet(SkillSetEntity skillSet)
        {
            _dbContext.SkillSets.Add(skillSet);
            _dbContext.SaveChanges();
            return skillSet;
        }

        public void DeleteSkillSet(int id)
        {
            var skillSet = _dbContext.SkillSets.Find(id);
            _dbContext.SkillSets.Remove(skillSet);
            _dbContext.SaveChanges();
        }

        public List<SkillSetEntity> GetAllSkillSet()
        {
            var skillSet = _dbContext.SkillSets.ToList();
            return skillSet;
        }

        public SkillSetEntity GetSkillSetById(int id)
        {
            var skillSet = _dbContext.SkillSets.Find(id);
            return skillSet;
        }

        public void UpdateSkillSet(SkillSetEntity skillSet)
        {
            var oldSkillSet = _dbContext.SkillSets.Find(skillSet.Id);
            _dbContext.SkillSets.Entry(oldSkillSet).CurrentValues.SetValues(skillSet);
            _dbContext.SaveChanges();
        }
    }
}
