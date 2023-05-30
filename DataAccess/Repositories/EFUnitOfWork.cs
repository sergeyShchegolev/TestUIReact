using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly SBMContext db;

        private PhaseRepository phaseRepository;
        private RoleRepository roleRepository;

        public EFUnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
            db = new SBMContext(_configuration.GetConnectionString("SBMContext"));
        }

        public IRepository<Phase> Phases => phaseRepository ??= new PhaseRepository(db);
        public IRepository<Role> Roles => roleRepository ??= new RoleRepository(db);

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
