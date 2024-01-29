using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public Department CreateDepartment(Department department)
        {
            try
            {
                var departmentEntity = _mapper.Map<DepartmentEntity>(department);
                var result = _departmentRepository.CreateDepartment(departmentEntity);
                var departmentCreated = _mapper.Map<Department>(department);
                return departmentCreated;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.DeleteDepartment(id);
        }

        public List<Department> GetAllDepartments()
        {
            var departmentsEntity = _departmentRepository.GetAllDepartments();
            var departmens = _mapper.Map<List<Department>>(departmentsEntity);
            return departmens;
        }

        public Department GetDepartmentById(int id)
        {
            var departmentEntity = _departmentRepository.GetDepartmentById(id);
            var department = _mapper.Map<Department>(departmentEntity);
            return department;
        }

        public Department GetDepartmentByName(string name)
        {
            var departmentEntity = _departmentRepository.GetDepartmentByName(name);
            var department = _mapper.Map<Department>(departmentEntity);
            return department;
        }

        public void UpdateDepartment(Department department)
        {
            var existingDepartment = _departmentRepository.GetDepartmentById(department.DepartmentId);
            var departmentEntity = _mapper.Map<DepartmentEntity>(department);
            _departmentRepository.UpdateDepartment(departmentEntity);
        }
    }
}
        