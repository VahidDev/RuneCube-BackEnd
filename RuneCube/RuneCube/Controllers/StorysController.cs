using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repository.Services.Abstarction;
using RuneCube.Utilities.GPT3;

namespace RuneCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorysController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StorysController(IConfiguration config,IUnitOfWork unitOfWork,
             IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetStoryAsync()
        {
            return Ok(await StartEndStoryPromptGenerator
                .GenerateStartEndStoryPromptAsync(_unitOfWork,_mapper));
        }
        [HttpGet("list")]
        public IActionResult List()
        {
            return Ok("Hello for testing!");
        }
    }
}
