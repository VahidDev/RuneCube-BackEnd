using System;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels.Dtos.SettingDtos;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Abstarction;

namespace RuneCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public SettingsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetSettings()
        {
            return Ok(_mapper.Map<SettingDto>
                (await _unitOfWork.Settings.FirstOrDefaultAsync(s=>!s.IsDeleted)));
        }
    }
}
