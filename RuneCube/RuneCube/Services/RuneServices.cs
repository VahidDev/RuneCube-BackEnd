using System.Collections.Generic;
using AutoMapper;
using DomainModels.Dtos.RuneDtos;
using RuneCube.Constants;

namespace RuneCube.Services
{
    public class RuneServices
    {
        public static IList<RuneDto> SetColors(IList<RuneDto>list,IMapper mapper)
        {
            List<RuneDto> dto=new List<RuneDto>();
            int x = 0;
            foreach (RuneDto rune in list)
            {
                foreach (string color in ColorConstants.Colors)
                {
                    RuneDto newRune = mapper.Map<RuneDto>(rune);
                    x++;
                    newRune.Id = x;
                    newRune.Color = color;
                    dto.Add(newRune);
                }
            }
            return dto;
        }
    }
}
