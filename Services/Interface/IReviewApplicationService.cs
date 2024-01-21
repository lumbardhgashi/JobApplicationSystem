using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IReviewApplicationService
    {
        public ReviewApplication CreateReviewApplication(ReviewApplication reviewApplication);
        public void UpdateReviewApplication(ReviewApplication reviewApplication);
        public void DeleteReviewApplication(int id);
        public ReviewApplication GetReviewApplicationById(int id);
        public List<ReviewApplication> GetAllReviewAplications();
    }
}
