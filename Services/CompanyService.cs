using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public Company CreateCompany(Company company)
        {
            try
            {
                var companyEntity = _mapper.Map<CompanyEntity>(company);
                var result = _companyRepository.CreateCompany(companyEntity);
                var companyCreated = _mapper.Map<Company>(company);
                return companyCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCompany(int id)
        {
            _companyRepository.DeleteCompany(id);
        }

        public List<Company> GetAllCompany()
        {
            var companyEntity = _companyRepository.GetAllCompany();
            var company = _mapper.Map<List<Company>>(companyEntity);
            return company;
        }

        public Company GetCompanytById(int id)
        {
            var companyEntity = _companyRepository.GetCompanyById(id);
            var company = _mapper.Map<Company>(companyEntity);
            return company;
        }
        public void UpdateCompany(Company company)
        {
            var existingCompany = _companyRepository.GetCompanyById(company.CompanyId);
            var companyEntity = _mapper.Map<CompanyEntity>(company);
            _companyRepository.UpdateCompany(companyEntity);
        }
    }
}
