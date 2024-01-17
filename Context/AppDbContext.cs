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
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicantEntity>().HasKey(x => x.Id);
            
        }
    }
}