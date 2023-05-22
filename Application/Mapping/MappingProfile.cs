using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<CreatePostDto, Post>()
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ReverseMap();
        }
    }
}
