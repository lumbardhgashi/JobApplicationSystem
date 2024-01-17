using JobApplicationSystem.Models;
using JobApplicationSystem.Entities;
using AutoMapper;

namespace JobApplicationSystem.Mappings
{
    public class ProfileMap: Profile
    {
        public ProfileMap() {
            CreateMap<Applicant, ApplicantEntity>().ReverseMap();
        }
    }
}
