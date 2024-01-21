using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class JobPostingRepository:IJobPostingRepository
    {
        private readonly AppDbContext _dbContext;

        public JobPostingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public JobPostingEntity CreateJobPost(JobPostingEntity jobPost)
        {
            _dbContext.JobPostings.Add(jobPost);
            _dbContext.SaveChanges();
            return jobPost;
        }

        public void DeleteJobPostById(int id)
        {
            var jobPost = _dbContext.JobPostings.Find(id);
            _dbContext.JobPostings.Remove(jobPost);
            _dbContext.SaveChanges();

        }

        public List<JobPostingEntity> GetAllJobPosts()
        {
            var jobPosts = _dbContext.JobPostings.ToList();
            return jobPosts;
        }

        public JobPostingEntity GetJobPostById(int id)
        {
            var jobPost = _dbContext.JobPostings.Find(id);
            return jobPost;
        }

        public void UpdateJobPost(JobPostingEntity jobPost)
        {
            var idOfOldJobPost = jobPost.Id;
            var oldJobPost = _dbContext.JobPostings.Find(idOfOldJobPost);
            _dbContext.JobPostings.Entry(oldJobPost).CurrentValues.SetValues(jobPost);
            _dbContext.SaveChanges();
        }
    }
}
