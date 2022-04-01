using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Repository.Services.Abstarction;
using RuneCube.Utilities.LeaderBoardUtilities;

namespace RuneCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LeaderBoardsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<bool> StorePlayers([FromBody] JObject json)
        {  
            await _unitOfWork.LeaderBoards.AddAsync(
                LeaderBoardGetter.GetLeaderBoard(
                json["username1"].ToString(),
                json["username2"].ToString(),
                json["role1"].ToString(),
                json["spent_time"].ToString()
                ));
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
