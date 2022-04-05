using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels.Dtos.RuneDtos;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Abstarction;
using RuneCube.Services;

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
            dto = RuneServices.SetColors(dto,_mapper);
            return Ok(dto);
        }
    }
}
