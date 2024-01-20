using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface ICompanyRepository
    {
        public CompanyEntity CreateCompany(CompanyEntity company);
        public void UpdateCompany(CompanyEntity company);
        public void DeleteCompany(int id);
        public CompanyEntity GetCompanyById(int id);
        public List<CompanyEntity> GetAllCompany();
    }
}
