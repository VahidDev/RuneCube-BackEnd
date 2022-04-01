using System;
using System.Collections.Generic;
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
            IList<RuneDto> dto = new List<RuneDto>();
            dto = _mapper.Map<IList<RuneDto>>(await _unitOfWork.Runes.GetAllAsync());
            return Ok(dto);
        }
    }
}
