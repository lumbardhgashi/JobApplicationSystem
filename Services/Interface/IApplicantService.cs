using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IApplicantService
    {
        public Applicant CreateApplicant(Applicant applicant);
        public void UpdateApplicant(Applicant applicant);
        public void DeleteApplicant(int id);
        public Applicant GetApplicantById(int id);
        public List<Applicant> GetAllApplicants();
    }
}
