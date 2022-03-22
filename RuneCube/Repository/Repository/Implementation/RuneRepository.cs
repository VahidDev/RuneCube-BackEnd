using DomainModels.Models.Entities;
using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.Repository.Abstarction;

namespace Repository.Repository.Implementation
{
    public class RuneRepository:GenericRepository<Rune>,IRuneRepository
    {
        public RuneRepository(AppDbContext dbContext,ILogger logger) : base(dbContext, logger) { }
    }
}
