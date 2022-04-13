using DomainModels.Models.Entities;
using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.Repository.Abstarction;

namespace Repository.Repository.Implementation
{
    public class SettingRepository:GenericRepository<Setting>,ISettingRepository
    {
        public SettingRepository(AppDbContext context, ILogger logger) : base(context, logger) { }
    }
}
