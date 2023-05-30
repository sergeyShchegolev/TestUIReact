using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interfaces;
using Audit.Core;

namespace DataAccess.Repositories
{
    public class PhaseRepository : IRepository<Phase>
    {
        private readonly SBMContext _context;

        public PhaseRepository(SBMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Phase>> GetAllAsync()
        {
            return await _context.Phases
                .Include(r => r.Role)
                .Where(p => p.IsActive == true)
                .ToListAsync();
        }

        public async Task<Phase?> GetAsync(int id)
        {
            var phaseItem = await _context.Phases
                .Include(r => r.Role)
                .Where(p => p.IsActive == true)
                .FirstOrDefaultAsync(x => x.Id == id);

            return phaseItem;
        }

        public async Task UpdateAsync(Phase phase)
        {
            var phaseItem = await FindAsync(phase.Id);
            if (phaseItem == null) { throw new KeyNotFoundException(); }

            phaseItem.Name = phase.Name;
            phaseItem.RoleId = (int)phase.RoleId;
            phaseItem.IsRequiredProcessPhase = phase.IsRequiredProcessPhase;
            phaseItem.PhaseOrder = phase.PhaseOrder;
            phaseItem.IsActive = phase.IsActive;
            phaseItem.VersionNumber = (int?)phase.VersionNumber;

            using (var audit = AuditScope.Create("Phase:Update", () => phaseItem))
            {
                audit.Event.Target.Type = "Phases";
                await _context.SaveChangesAsync();
                audit.Event.CustomFields["ReferenceId"] = phase.Id;
            }
        }

        public async Task CreateAsync(Phase phaseItem)
        {
            using (var audit = AuditScope.Create("Phase:Create", () => phaseItem))
            {
                audit.Event.Target.Old = null;
                audit.Event.Target.Type = "Phases";
                _context.Phases.Add(phaseItem);
                await _context.SaveChangesAsync();
                audit.Event.CustomFields["ReferenceId"] = phaseItem.Id;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var phaseItem = await FindAsync(id);
            if (phaseItem == null) { throw new KeyNotFoundException(); }

            phaseItem.IsActive = false;
            phaseItem.Last_IsActive_ChangeDate = DateTime.UtcNow;

            using (var audit = AuditScope.Create("Phase:Delete", () => phaseItem))
            {
                audit.Event.Target.Type = "Phases";
                await _context.SaveChangesAsync();
                audit.Event.CustomFields["ReferenceId"] = id;
            }
        }

        public async Task<Phase?> FindAsync(int id)
        {
            return await _context.Phases.FindAsync(id);
        }
    }
}
