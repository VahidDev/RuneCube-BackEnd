using System;
using System.Threading.Tasks;
using DomainModels.Dtos.SettingDtos;
using Microsoft.AspNetCore.Mvc;

namespace RuneCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSettings()
        {
            Random rnd = new ();
            int randomNum = rnd.Next(8, 16);
            SettingDto dto = new();
            dto.MaxResponseTime = randomNum;
            dto.Count = 5;
            dto.EachSideCount = 6;
            dto.SidesTime = randomNum * dto.Count;
            return Ok(dto);
        }
    }
}
