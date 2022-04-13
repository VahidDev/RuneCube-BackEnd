using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.Repository.Abstarction;

namespace Repository.Repository.Implementation
{
    public class LeaderBoardRepository:GenericRepository<LeaderBoard>,ILeaderBoardRepository
    {
        public LeaderBoardRepository(AppDbContext dbContext, ILogger logger) 
            : base(dbContext, logger){
        }
        public async Task<IList<LeaderBoard>> GetAllOrderedByTimeAsync()
        {
            return (await dbSet.ToListAsync())
                .OrderBy(l => TimeSpan.Parse(l.SpentTime)).OrderBy(l=>!l.IsFinished).ToList();
        }
    }
}
