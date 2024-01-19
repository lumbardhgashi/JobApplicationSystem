using Microsoft.EntityFrameworkCore;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;


namespace JobApplicationSystem.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<ApplicantEntity> Applicants { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<HRManagerEntity> HrManagers { get; set; }
        public DbSet<JobPostingEntity> JobPostings { get; set; }
        public DbSet<ReviewApplicationEntity> ReviewApplications { get; set; }
        public DbSet<ApplicationStatusEntity> ApplicationStatuses { get; set; }
        public DbSet<ApplyEntity> Applies { get; set; }
        public DbSet<SkillSetEntity> SkillSets { get; set; }
        public DbSet<ExperienceEntity> Experiences { get; set; }
        public DbSet<EducationHistoryEntity> EducationHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicantEntity>().HasKey(x => x.Id);

        
            
        }
    }
}