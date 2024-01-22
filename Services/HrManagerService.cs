using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class HrManagerService : IHrManagerService
    {
        private readonly IHrManagerRepository _hrManagerRepository;
        private readonly IMapper _mapper;

        public HrManagerService(IHrManagerRepository hrManagerRepository,IMapper mapper)
        {
            _hrManagerRepository = hrManagerRepository;
            _mapper = mapper;
        }

        public HRManager CreateHrManager(HRManager hRManager)
        {
            try
            {
                var HrManagerEntity = _mapper.Map<HRManagerEntity>(hRManager);
                var result = _hrManagerRepository.CreateHrManger(HrManagerEntity);
                var HrManagerCreated = _mapper.Map<HRManager>(hRManager);
                return HrManagerCreated;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteHrManager(int id)
        {
            _hrManagerRepository.DeleteHrManager(id);
        }

        public List<HRManager> GetAllHrManager()
        {
            var HrManagerEntity = _hrManagerRepository.GetAllHrManagers();
            var HrManager = _mapper.Map<List<HRManager>>(HrManagerEntity);
            return HrManager;
        }

        public HRManager GetHrManagerById(int id)
        {
            var HrManagerEntity = _hrManagerRepository.GetHrManagerById(id);
            var HrManager = _mapper.Map<HRManager>(HrManagerEntity);
            return HrManager;
        }

        public void UpdateHrManager(HRManager hrManager)
        {
            var existingHrManager = _hrManagerRepository.GetHrManagerById(hrManager.HRManagerId);
            var HrManagerEntity = _mapper.Map<HRManagerEntity>(hrManager);
            _hrManagerRepository.UpdateHrManager(HrManagerEntity);
        }
    }
}
