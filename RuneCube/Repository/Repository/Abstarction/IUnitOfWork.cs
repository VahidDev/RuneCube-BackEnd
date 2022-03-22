using System.Threading.Tasks;
using Repository.Repository.Abstarction;

namespace Repository.Services.Abstarction
{
    public interface IUnitOfWork
    {
        IStoryRepository Stories { get; }
        IRuneRepository Runes{ get; }
        Task CompleteAsync();
        void Dispose();
    }
}