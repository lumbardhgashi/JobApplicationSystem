using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        public DepartmentEntity CreateDepartment(DepartmentEntity department);
        public void UpdateDepartment(DepartmentEntity department);
        public void DeleteDepartment(int id);
        public DepartmentEntity GetDepartmentById(int id);
        public List<DepartmentEntity> GetAllDepartments();
    }
}
