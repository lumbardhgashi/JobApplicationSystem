using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly AppDbContext _dbContext;
        public DepartmentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DepartmentEntity CreateDepartment(DepartmentEntity department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
            return department;
        }

        public void DeleteDepartment(int id)
        {
            var department = _dbContext.Departments.Find(id);
            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();
        }

        public List<DepartmentEntity> GetAllDepartments()
        {
            var departments = _dbContext.Departments.ToList();
            return departments;
        }

        public DepartmentEntity GetDepartmentById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }

        public void UpdateDepartment(DepartmentEntity department)
        {
            var oldDepartment = _dbContext.Departments.Find(department.DepartmentId);
            _dbContext.Departments.Entry(oldDepartment).CurrentValues.SetValues(department);
            _dbContext.SaveChanges();
        }
    }
}
