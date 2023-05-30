using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Phase> Phases { get; }
        IRepository<Role> Roles { get; }

        void Save();
    }
}

