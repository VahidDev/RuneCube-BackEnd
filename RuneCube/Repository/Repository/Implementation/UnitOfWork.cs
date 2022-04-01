using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.Repository.Abstarction;
using Repository.Services.Abstarction;
using System;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        public IStoryRepository Stories { get; private set; }
        public IRuneRepository Runes { get; private set; }
        public ILeaderBoardRepository LeaderBoards { get; set; }
        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Stories = new StoryRepository(_context, _logger);
            Runes = new RuneRepository(_context, _logger);
            LeaderBoards = new LeaderBoardRepository(_context, _logger);
        }


        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose() => _context.Dispose();
    }
}