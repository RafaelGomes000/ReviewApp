using AutoMapper;
using PetReviewApp.Dto;
using PetReviewApp.Models;

namespace PetReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pet, PetDto>();
        }
    }
}
