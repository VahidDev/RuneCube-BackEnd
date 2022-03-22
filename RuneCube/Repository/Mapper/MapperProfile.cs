using AutoMapper;
using DomainModels.Dtos.RuneDtos;
using DomainModels.Dtos.StoryDtos;
using DomainModels.Models.Entities;

namespace Repository.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Story, StoryPromptDto>().ReverseMap();
            CreateMap<RuneDto, Rune>().ReverseMap();
        }
    }
}
