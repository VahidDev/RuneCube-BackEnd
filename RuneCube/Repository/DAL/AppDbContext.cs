using DomainModels.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        public DbSet<Story> Stories { get; set; }
        public DbSet<Rune> Runes { get; set; }
    }
}
