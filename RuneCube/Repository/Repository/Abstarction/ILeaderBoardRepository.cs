using System.Collections.Generic;
using System.Threading.Tasks;
using DomainModels.Models.Entities;
using Repository.Services.Abstarction;

namespace Repository.Repository.Abstarction
{
    public interface ILeaderBoardRepository:IGenericRepository<LeaderBoard>
    {
        Task<IList<LeaderBoard>> GetAllOrderedByTimeAsync();
    }
}
