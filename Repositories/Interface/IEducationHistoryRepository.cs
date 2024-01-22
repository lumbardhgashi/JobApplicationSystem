using JobApplicationSystem.Entities;

namespace JobApplicationSystem.Repositories.Interface
{
    public interface IEducationHistoryRepository
    {
        public EducationHistoryEntity CreateEducationHistory(EducationHistoryEntity educationHistory);
        public void UpdateEducationHistory (EducationHistoryEntity educationHistory);
        public void DeleteEducationHistory (int id);
        public EducationHistoryEntity GetEducationHistoryById (int id);
        public List<EducationHistoryEntity> GetAllEducationHistory ();

    }
}
