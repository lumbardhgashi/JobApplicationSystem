using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _dbContext;
        public CompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CompanyEntity CreateCompany(CompanyEntity company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
            return company;
        }

        public void DeleteCompany(int id)
        {
            var company = _dbContext.Companies.Find(id);
            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();
        }

        public List<CompanyEntity> GetAllCompany()
        {
            var company = _dbContext.Companies.ToList();
            return company;
        }

        public CompanyEntity GetCompanyById(int id)
        {
            var company = _dbContext.Companies.Find(id);
            return company;

        }

        public int GetNumberOfEmployesByCompanyId(int id)
        {
            var company = _dbContext.Companies.Find(id);
            var companies = _dbContext.Departments.Where(d => d.CompanyId == id);
            var nrOfEmployes = companies.Sum(d => d.NumriPunonjesve);
            return nrOfEmployes;
        }

        public void UpdateCompany(CompanyEntity company)
        {
            var oldCompany = _dbContext.Companies.Find(company.CompanyId);
            _dbContext.Companies.Entry(oldCompany).CurrentValues.SetValues(company);
            _dbContext.SaveChanges();
        }
    }
}
