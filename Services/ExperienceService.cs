using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public ExperienceService(IExperienceRepository experienceRepository, IMapper mapper)
        {
            _experienceRepository = experienceRepository;
            _mapper = mapper;
        }

        public Experience CreateExperience(Experience experience)
        {
            try
            {
                var experienceEntity = _mapper.Map<ExperienceEntity>(experience);
                var result = _experienceRepository.CreateExperience(experienceEntity);
                var experienceCreated = _mapper.Map<Experience>(experience);
                return experienceCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteExperience(int id)
        {
            _experienceRepository.DeleteExperience(id);
        }

        public List<Experience> GetAllExperience()
        {
            var experienceEntity = _experienceRepository.GetAllExperience();
            var experience = _mapper.Map<List<Experience>>(experienceEntity);
            return experience;
        }

        public Experience GetExperienceById(int id)
        {
            var experienceEntity = _experienceRepository.GetExperienceById(id);
            var experience = _mapper.Map<Experience>(experienceEntity);
            return experience;
        }

        public void UpdateExperience(Experience experience)
        {
            var existingExperience = _experienceRepository.GetExperienceById(experience.Id);
            var experienceEntity = _mapper.Map<ExperienceEntity>(experience);
            _experienceRepository.UpdateExperience(experienceEntity);
        }
    }
}
