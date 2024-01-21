using AutoMapper;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Models;
using JobApplicationSystem.Repositories.Interface;
using JobApplicationSystem.Services.Interface;

namespace JobApplicationSystem.Services
{
    public class ReviewApplicationService:IReviewApplicationService
    {
        private readonly IReviewApplicationRepository _reviewApplicationRepository;
        private readonly IMapper _mapper;

        public ReviewApplicationService(IReviewApplicationRepository reviewApplicationRepository, IMapper mapper)
        {
            _reviewApplicationRepository = reviewApplicationRepository;
            _mapper = mapper;
        }

        public ReviewApplication CreateReviewApplication(ReviewApplication reviewApplication)
        {
            try
            {
                var reviewApplicationEntity = _mapper.Map<ReviewApplicationEntity>(reviewApplication);
                _reviewApplicationRepository.CreateReviewApplication(reviewApplicationEntity);
                return reviewApplication;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteReviewApplication(int id)
        {
            _reviewApplicationRepository.DeleteReviewApplication(id);
        }

        public List<ReviewApplication> GetAllReviewAplications()
        {
            var reviewApplicationsEntity = _reviewApplicationRepository.GetAllReviewAplications();
            var reviewApplications = _mapper.Map<List<ReviewApplication>>(reviewApplicationsEntity);
            return reviewApplications;
        }

        public ReviewApplication GetReviewApplicationById(int id)
        {
            var reviewApplicationEntity = _reviewApplicationRepository.GetReviewApplicationById(id);
            var reviewApplication = _mapper.Map<ReviewApplication>(reviewApplicationEntity);
            return reviewApplication;
        }

        public void UpdateReviewApplication(ReviewApplication reviewApplication)
        {
            var reviewApplicationEntity = _mapper.Map<ReviewApplicationEntity>(reviewApplication);
            _reviewApplicationRepository.UpdateReviewApplication(reviewApplicationEntity);

        }
    }
}
