using AutoMapper;
using Business.Managers.Auth.Commands.Register;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<RegisterDto, User>().ForMember(
                dest => dest.Username,
                opt => opt.MapFrom(src => src.Username.ToLower())
                );

            CreateMap<User, LoginInfoDto>();
            CreateMap<User, UserDto>();
            CreateMap<Exam, ExamDto>();
            CreateMap<ExamDto, Exam>()
                .ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(src => DateTime.Now.ToString())
                )
                .ForMember(
                dest => dest.IsActive,
                opt => opt.MapFrom(src => 1)
                );
            CreateMap<Exam, ExamWithQuestionsDto>();
            CreateMap<ExamWithQuestionsDto, Exam>().ForMember(
                dest => dest.Date,
                opt => opt.MapFrom(src => DateTime.Now.ToString())
                )
                 .ForMember(
                dest => dest.IsActive,
                opt => opt.MapFrom(src => 1)
                );
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<Role, RoleDto>();
            CreateMap<OperationClaim, OperationClaimDto>();
        }
    }
}
