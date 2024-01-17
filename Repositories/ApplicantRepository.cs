using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly AppDbContext _dbContext;
        public ApplicantRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicantEntity CreateApplicant(ApplicantEntity applicant)
        {
            _dbContext.Applicants.Add(applicant);
            _dbContext.SaveChanges();
            return applicant;
        }

        public void DeleteApplicant(int id)
        {
            var applicant = _dbContext.Applicants.Find(id);
            _dbContext.Applicants.Remove(applicant);
            _dbContext.SaveChanges();
        }

        public List<ApplicantEntity> GetAllApplicants()
        {
            var applicants = _dbContext.Applicants.ToList();
            return applicants;
        }

        public ApplicantEntity GetApplicantById(int id)
        {
            var applicant = _dbContext.Applicants.Find(id);
            return applicant;

        }

        public void UpdateApplicant(ApplicantEntity applicant)
        {
            var oldApplicant = _dbContext.Applicants.Find(applicant.Id);
            _dbContext.Applicants.Entry(oldApplicant).CurrentValues.SetValues(applicant);
            _dbContext.SaveChanges();
        }
    }
}
