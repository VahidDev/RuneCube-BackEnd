using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DomainModels.Dtos.LeaderBoardDtos;
using Microsoft.AspNetCore.Mvc;
using Repository.Services.Abstarction;

namespace RuneCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PlayersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IList<LeaderBoardDto>> GetPlayersAsync()
        {
            return _mapper.Map<IList<LeaderBoardDto>>
                (await _unitOfWork.LeaderBoards.GetAllOrderedByTimeAsync());
        }
    }
}
