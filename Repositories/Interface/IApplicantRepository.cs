using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IApplicantRepository
    {
        public ApplicantEntity CreateApplicant(ApplicantEntity applicant);
        public void UpdateApplicant(ApplicantEntity applicant);
        public void DeleteApplicant(int id);
        public ApplicantEntity GetApplicantById(int id);
        public List<ApplicantEntity> GetAllApplicants();
    }
}
