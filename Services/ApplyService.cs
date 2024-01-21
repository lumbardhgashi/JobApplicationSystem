using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class ApplyService:IApplyService
    {
        private readonly IApplyRepository _applyRepository;
        private readonly IMapper _mapper;

        public ApplyService(IApplyRepository applyRepository, IMapper mapper)
        {
            _applyRepository = applyRepository;
            _mapper = mapper;
        }

        public Apply CreateApply(Apply apply)
        {
            try
            {
                var applyEntity = _mapper.Map<ApplyEntity>(apply);
                var result = _applyRepository.CreateApply(applyEntity);
                var applyCreated = _mapper.Map<Apply>(apply);
                return applyCreated;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteApply(int id)
        {
            _applyRepository.DeleteApply(id);
        }

        public List<Apply> GetAllApplies()
        {
            var appliesEntities = _applyRepository.GetAllApplies();
            var applies = _mapper.Map<List<Apply>>(appliesEntities);
            return applies;
        }

        public Apply GetApplyById(int id)
        {
            var applyEntity = _applyRepository.GetApplyById(id);
            var applyModel = _mapper.Map<Apply>(applyEntity);
            return applyModel;
        }

        public void UpdateApply(Apply apply)
        {
            var applyEntity = _mapper.Map<ApplyEntity>(apply);
            _applyRepository.UpdateApply(applyEntity);
        }
    }
}
