using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class ApplicationStatusService: IApplicationStatusService
    {
        private readonly IApplicationStatusRepository _applicationStatusRepository;
        private readonly IMapper _mapper;

        public ApplicationStatusService(IApplicationStatusRepository applicationStatusRepository, IMapper mapper)
        {
            _applicationStatusRepository = applicationStatusRepository;
            _mapper = mapper;
        }

        public ApplicationStatus CreateApplicationStatus(ApplicationStatus applicationStatus)
        {
            try
            {
                var applicationStatusEntity = _mapper.Map<ApplicationStatusEntity>(applicationStatus);
                var result = _applicationStatusRepository.CreateApplicationStatus(applicationStatusEntity);
                // --
                return applicationStatus;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteApplicationStatus(int id)
        {
            _applicationStatusRepository.DeleteApplicationStatus(id);
        }

        public List<ApplicationStatus> GetAllApplicationStatus()
        {
            var applicationStatusEntities = _applicationStatusRepository.GetAllApplicationStatus();
            var applicationStatus = _mapper.Map<List<ApplicationStatus>>(applicationStatusEntities);
            return applicationStatus;
        }

        public ApplicationStatus GetApplicationStatusById(int id)
        {
            var applicationStatusEntity = _applicationStatusRepository.GetApplicationStatusById(id);
            var applicationStatus = _mapper.Map<ApplicationStatus>(applicationStatusEntity);
            return applicationStatus;
        }

        public void UpdateApplicationStatus(ApplicationStatus applicationStatus)
        {
            var applicationStatusEntity = _mapper.Map<ApplicationStatusEntity>(applicationStatus);
            _applicationStatusRepository.UpdateApplicationStatus(applicationStatusEntity);
        }
    }
}
