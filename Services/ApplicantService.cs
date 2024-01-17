using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMapper _mapper;

        public ApplicantService(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicantRepository = applicantRepository;
            _mapper = mapper;
        }

        public Applicant CreateApplicant(Applicant applicant)
        {
            try
            {
                var applicantEntity = _mapper.Map<ApplicantEntity>(applicant);
                var result = _applicantRepository.CreateApplicant(applicantEntity);
                var applicantCreated = _mapper.Map<Applicant>(applicant);
                return applicantCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteApplicant(int id)
        {
            _applicantRepository.DeleteApplicant(id);
        }

        public List<Applicant> GetAllApplicants()
        {
            var applicantsEntity =  _applicantRepository.GetAllApplicants();
            var applicants = _mapper.Map<List<Applicant>>(applicantsEntity);
            return applicants;
        }

        public Applicant GetApplicantById(int id)
        {
            var applicantEntity = _applicantRepository.GetApplicantById(id);
            var applicant = _mapper.Map<Applicant>(applicantEntity);
            return applicant;
        }

        public void UpdateApplicant(Applicant applicant)
        {
            var existingApplicant = _applicantRepository.GetApplicantById(applicant.Id);
            var applicantEntity = _mapper.Map<ApplicantEntity>(applicant);
            _applicantRepository.UpdateApplicant(applicantEntity);
        }
    }
}
