using JobApplicationSystem.Models;
using JobApplicationSystem.Entities;
using AutoMapper;

namespace JobApplicationSystem.Mappings
{
    public class ProfileMap: Profile
    {
        public ProfileMap() {
            CreateMap<Applicant, ApplicantEntity>().ReverseMap();
            CreateMap<Apply, ApplyEntity>().ReverseMap();
            CreateMap<SkillSet, SkillSetEntity>().ReverseMap();
            CreateMap<JobPosting, JobPostingEntity>().ReverseMap();
            CreateMap<Company, CompanyEntity>().ReverseMap();
            CreateMap<ReviewApplication, ReviewApplicationEntity>().ReverseMap();
            CreateMap<HRManager, HRManagerEntity>().ReverseMap();
        }
    }
}
