using DomainModels.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Rune> Runes { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<Setting> Settings{ get; set; }
    }
}
