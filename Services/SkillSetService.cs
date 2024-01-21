using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class SkillSetService : ISkillSetService
    {
        private readonly ISkillSetRepository _skillSetRepository;
        private readonly IMapper _mapper;

        public SkillSetService(ISkillSetRepository skillSetRepository, IMapper mapper)
        {
            _skillSetRepository = skillSetRepository;
            _mapper = mapper;
        }

        public SkillSet CreateSkillSet(SkillSet skillSet)
        {
            try
            {
                var skillSetEntity = _mapper.Map<SkillSetEntity>(skillSet);
                var result = _skillSetRepository.CreateSkillSet(skillSetEntity);
                var skillSetCreated = _mapper.Map<SkillSet>(skillSet);
                return skillSetCreated;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteSkillSet(int id)
        {
            _skillSetRepository.DeleteSkillSet(id);
        }

        public List<SkillSet> GetAllSkillSet()
        {
            var skillSetEntity = _skillSetRepository.GetAllSkillSet();
            var skillSet = _mapper.Map<List<SkillSet>>(skillSetEntity);
            return skillSet;
        }

        public SkillSet GetSkillSetById(int id)
        {
            var skillSetEntity = _skillSetRepository.GetSkillSetById(id);
            var skillSet = _mapper.Map<SkillSet>(skillSetEntity);
            return skillSet;
        }

        public void UpdateSkillSet(SkillSet skillSet)
        {
            var existingSkillSet = _skillSetRepository.GetSkillSetById(skillSet.Id);
            var skillSetEntity = _mapper.Map<SkillSetEntity>(skillSet);
            _skillSetRepository.UpdateSkillSet(skillSetEntity);
        }
    }
}
