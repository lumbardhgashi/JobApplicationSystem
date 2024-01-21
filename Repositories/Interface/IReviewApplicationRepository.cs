using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IReviewApplicationRepository
    {
        public ReviewApplicationEntity CreateReviewApplication(ReviewApplicationEntity reviewApplication);
        public void UpdateReviewApplication(ReviewApplicationEntity reviewApplication);
        public void DeleteReviewApplication(int id);
        public ReviewApplicationEntity GetReviewApplicationById(int id);
        public List<ReviewApplicationEntity> GetAllReviewAplications();
    }
}
