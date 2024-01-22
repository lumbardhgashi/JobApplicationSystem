using JobApplicationSystem.Models;

namespace JobApplicationSystem.Services.Interface
{
    public interface IEducationHistoryService
    {
        public EducationHistory CreateEducationHistory(EducationHistory educationHistory);
        public void UpdateEducationHistory(EducationHistory educationHistory);
        public void DeleteEducationHistory(int id);
        public EducationHistory GetEducationHistoryById(int id);
        public List<EducationHistory> GetAllEducationHistory();
    }
}
