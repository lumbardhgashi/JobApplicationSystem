using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IJobPostingRepository
    {
        public JobPostingEntity CreateJobPost(JobPostingEntity jobPost);
        public void UpdateJobPost(JobPostingEntity jobPost);
        public JobPostingEntity GetJobPostById(int id);
        public List<JobPostingEntity> GetAllJobPosts();
        public void DeleteJobPostById(int id);
    }
}
