using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepository _jobPostingRepository;
        private readonly IMapper  _mapper;

        public JobPostingService(IJobPostingRepository jobPostingRepository, IMapper mapper)
        {
            _jobPostingRepository = jobPostingRepository;
            _mapper = mapper;
        }

        public JobPosting CreateJobPost(JobPosting jobPosting)
        {
            try
            {
                var jobPostEntity = _mapper.Map<JobPostingEntity>(jobPosting);
                _jobPostingRepository.CreateJobPost(jobPostEntity);
                return jobPosting;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteJobPost(int id)
        {
            _jobPostingRepository.DeleteJobPostById(id);
        }

        public List<JobPosting> GetAllJobPosts()
        {
            var jobPostsEntity = _jobPostingRepository.GetAllJobPosts();
            var jobPosts = _mapper.Map<List<JobPosting>>(jobPostsEntity);
            return jobPosts;
        }

        public List<JobPosting> GetAllJobPostsByHrId(int id)
        {
            var jobPostsEntity = _jobPostingRepository.GetAllJobPostsByHrId(id);
            var jobPosts = _mapper.Map<List<JobPosting>>(jobPostsEntity);
            return jobPosts;
        }

        public List<JobPosting> GetAllJobPostsByHrName(string name)
        {
            var jobPostsEntity = _jobPostingRepository.GetAllJobPostsByHrName(name);
            var jobPosts = _mapper.Map<List<JobPosting>>(jobPostsEntity);
            return jobPosts;
        }

        public JobPosting GetJobPostById(int id)
        {
            var jobPostEntity = _jobPostingRepository.GetJobPostById(id);
            var jobPost = _mapper.Map<JobPosting>(jobPostEntity);
            return jobPost;
        }

        public void UpdateJobPost(JobPosting jobPosting)
        {
            var jobPostEntity = _mapper.Map<JobPostingEntity>(jobPosting);
            _jobPostingRepository.UpdateJobPost(jobPostEntity);
        }
    }
}
