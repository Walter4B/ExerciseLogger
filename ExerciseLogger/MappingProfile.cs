using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace ExerciseLogger
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gym, GymDto>();

            CreateMap<Exercise, ExerciseDto>();

            CreateMap<GymForCreationDto, Gym>();

            CreateMap<ExerciseForCreationDto, Exercise>();

            CreateMap<ExerciseForUpdateDto, Exercise>();

            CreateMap<GymForUpdateDto, Gym>();
        }
    }
}
