using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IDepartmentService
    {
        public Department CreateDepartment(Department department);
        public void UpdateDepartment(Department department);
        public void DeleteDepartment(int id);
        public Department GetDepartmentById(int id);
        public List<Department> GetAllDepartments();
    }
}
