using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class EducationHistoryService : IEducationHistoryService
    {
        private readonly IEducationHistoryRepository _educationHistoryRepository;
        private readonly IMapper _mapper;

        public EducationHistoryService(IEducationHistoryRepository educationHistoryRepository, IMapper mapper)
        {
            _educationHistoryRepository = educationHistoryRepository;
            _mapper = mapper;
        }

        public EducationHistory CreateEducationHistory(EducationHistory educationHistory)
        {
            try
            {
                var educationHistoryEntity = _mapper.Map<EducationHistoryEntity>(educationHistory);
                var result = _educationHistoryRepository.CreateEducationHistory(educationHistoryEntity);
                var educationHistoryCreated = _mapper.Map<EducationHistory>(educationHistory);
                return educationHistoryCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteEducationHistory(int id)
        {
            _educationHistoryRepository.DeleteEducationHistory(id);
        }

        public List<EducationHistory> GetAllEducationHistory()
        {
            var educationHistoryEnitity = _educationHistoryRepository.GetAllEducationHistory();
            var educationHistory = _mapper.Map<List<EducationHistory>>(educationHistoryEnitity);
            return educationHistory;
        }

        public EducationHistory GetEducationHistoryById(int id)
        {
            var educatinHistoryEntity = _educationHistoryRepository.GetEducationHistoryById(id);
            var educationHistory = _mapper.Map<EducationHistory>(educatinHistoryEntity);
            return educationHistory;
        }

        public void UpdateEducationHistory(EducationHistory educationHistory)
        {
            var existingEducatinHistory = _educationHistoryRepository.GetEducationHistoryById(educationHistory.Id);
            var educationHistoryEntity = _mapper.Map<EducationHistoryEntity>(educationHistory);
            _educationHistoryRepository.UpdateEducationHistory(educationHistoryEntity);
        }
    }
}
