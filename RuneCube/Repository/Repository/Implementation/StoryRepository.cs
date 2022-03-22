using DomainModels.Models.Entities;
using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.Repository.Abstarction;

namespace Repository.Repository.Implementation
{
   public class StoryRepository:GenericRepository<Story>, IStoryRepository
    {
        public StoryRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger){}
    }
}
