using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IJobPostingService
    {
        public JobPosting CreateJobPost(JobPosting jobPosting);
        public void UpdateJobPost(JobPosting jobPosting);
        public void DeleteJobPost(int id);
        public JobPosting GetJobPostById(int id);
        public List<JobPosting> GetAllJobPosts();
    }
}
