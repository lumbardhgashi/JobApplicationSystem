using Microsoft.EntityFrameworkCore;
using JobApplicationSystem.Entities;



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

            modelBuilder.Entity<DepartmentEntity>().ToTable("Applicants");
            modelBuilder.Entity<CompanyEntity>().ToTable("Companies");
            modelBuilder.Entity<DepartmentEntity>().ToTable("Departments");
            modelBuilder.Entity<HRManagerEntity>().ToTable("HrManagers");
            modelBuilder.Entity<JobPostingEntity>().ToTable("JobPostings");
            modelBuilder.Entity<ReviewApplicationEntity>().ToTable("ReviewApplications");
            modelBuilder.Entity<ApplicationStatusEntity>().ToTable("ApplicationStatuses");
            modelBuilder.Entity<ApplyEntity>().ToTable("Applies");
            modelBuilder.Entity<SkillSetEntity>().ToTable("SkillSets");
            modelBuilder.Entity<ExperienceEntity>().ToTable("Experiences");
            modelBuilder.Entity<EducationHistoryEntity>().ToTable("EducationHistories");


            modelBuilder.Entity<DepartmentEntity>()
                .HasKey(pk => pk.DepartmentId);

            modelBuilder.Entity<DepartmentEntity>()
                .HasOne(ae => ae.Company)
                .WithMany(ae => ae.Departments)
                .HasForeignKey(fk => fk.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<HRManagerEntity>()
                .HasKey(pk => pk.HRManagerId);

            modelBuilder.Entity<HRManagerEntity>()
                .HasOne(c => c.Company)
                .WithMany(hr => hr.HRManagers)
                .HasForeignKey(hr => hr.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SkillSetEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<SkillSetEntity>()
                .HasOne(a => a.Applicant)
                .WithMany(s => s.Skills)
                .HasForeignKey(s => s.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EducationHistoryEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<EducationHistoryEntity>()
                .HasOne(a => a.Applicant)
                .WithMany(e => e.Educations)
                .HasForeignKey(s => s.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExperienceEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<ExperienceEntity>()
                .HasOne(a => a.Applicant)
                .WithMany(e => e.Experiences)
                .HasForeignKey(s => s.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplyEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<ApplyEntity>()
                .HasOne(a => a.Applicant)
                .WithMany(a => a.Applies)
                .HasForeignKey(s => s.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplyEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<ApplyEntity>()
                .HasOne(a => a.JobPosting)
                .WithMany(a => a.Applies)
                .HasForeignKey(s => s.JobPostId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobPostingEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<JobPostingEntity>()
                .HasOne(d => d.Department)
                .WithMany(a => a.JobPosting)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobPostingEntity>()
                .HasOne(hr => hr.HrManager)
                .WithMany(a => a.JobPosting)
                .HasForeignKey(s => s.HrManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewApplicationEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<ReviewApplicationEntity>()
                .HasOne(hr => hr.HRManager)
                .WithMany(a => a.ReviewApplications)
                .HasForeignKey(s => s.HrManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReviewApplicationEntity>()
                .HasOne(a => a.Apply)
                .WithOne(a => a.ReviewApplication)
                .HasForeignKey<ReviewApplicationEntity>(s => s.ApplyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationStatusEntity>()
                .HasKey(pk => pk.Id);

            modelBuilder.Entity<ApplicationStatusEntity>()
                .HasOne(a => a.ReviewApplication)
                .WithOne(a => a.ApplicationStatus)
                .HasForeignKey<ApplicationStatusEntity>(s => s.ReviewApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationStatusEntity>()
               .HasOne(a => a.Applicant)
               .WithOne(a => a.ApplicationStatus)
               .HasForeignKey<ApplicationStatusEntity>(s => s.ApplicantId)
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}