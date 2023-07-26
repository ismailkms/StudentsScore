using AutoMapper;
using DTOLayer.DTOs.CourseDTOs;
using DTOLayer.DTOs.RoleDTOs;
using DTOLayer.DTOs.ScoreDTOs;
using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;

namespace StudentsScore.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserAddDTO, User>();
            CreateMap<User, UserAddDTO>();
            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();

            CreateMap<CourseAddDTO, Course>();
            CreateMap<Course, CourseAddDTO>();
            CreateMap<CourseUpdateDTO, Course>();
            CreateMap<Course, CourseUpdateDTO>();

            CreateMap<RoleAddDTO, Role>();
            CreateMap<Role, RoleAddDTO>();
            CreateMap<RoleUpdateDTO, Role>();
            CreateMap<Role, RoleUpdateDTO>();

            CreateMap<ScoreAddDTO, Score>();
            CreateMap<Score, ScoreAddDTO>();
            CreateMap<ScoreUpdateDTO, Score>();
            CreateMap<Score, ScoreUpdateDTO>();
        }
    }
}
