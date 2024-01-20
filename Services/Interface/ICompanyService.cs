using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface ICompanyService
    {
        public Company CreateCompany(Company company);
        public void UpdateCompany(Company company);
        public void DeleteCompany(int id);
        public Company GetCompanytById(int id);
        public List<Company> GetAllCompany();
    }
}