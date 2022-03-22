using System;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels.Dtos.RuneDtos;
using DomainModels.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Abstarction;

namespace RuneCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RunesController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetRuneAsync()
        {
            int allRuneCount=await _unitOfWork.Runes.GetCountAsync();
            Random rnd = new();
            int number = rnd.Next(1, allRuneCount);
            Rune rune = await _unitOfWork.Runes.GetSkippedAsync(number, 1);
            RuneDto dto = _mapper.Map<RuneDto>(rune);
            dto.Count = 5;
            dto.EachSideCount = 6;
            dto.SidesCount = 60;
            dto.MaxResponseTime = 12;
            return Ok(dto);
        }
    }
}
