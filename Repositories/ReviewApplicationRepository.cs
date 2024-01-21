using JobApplicationSystem.Context;
using JobApplicationSystem.Entities;
using JobApplicationSystem.Repositories.Interface;

namespace JobApplicationSystem.Repositories
{
    public class ReviewApplicationRepository : IReviewApplicationRepository
    {
        private readonly AppDbContext _dbContext;

        public ReviewApplicationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ReviewApplicationEntity CreateReviewApplication(ReviewApplicationEntity reviewApplication)
        {
            _dbContext.ReviewApplications.Add(reviewApplication);
            _dbContext.SaveChanges();
            return reviewApplication;
        }

        public void DeleteReviewApplication(int id)
        {
            var reviewApplication = _dbContext.ReviewApplications.Find(id);
            _dbContext.ReviewApplications.Remove(reviewApplication);
            _dbContext.SaveChanges();
        }

        public List<ReviewApplicationEntity> GetAllReviewAplications()
        {
            var reviewAplications = _dbContext.ReviewApplications.ToList();
            return reviewAplications;
        }

        public ReviewApplicationEntity GetReviewApplicationById(int id)
        {
            var reviewApplication = _dbContext.ReviewApplications.Find(id);
            return reviewApplication;
        }

        public void UpdateReviewApplication(ReviewApplicationEntity reviewApplication)
        {
            var oldReviewApplication = _dbContext.ReviewApplications.Find(reviewApplication.Id);
            _dbContext.ReviewApplications.Entry(oldReviewApplication).CurrentValues.SetValues(reviewApplication);
            _dbContext.SaveChanges();
        }
    }
}
