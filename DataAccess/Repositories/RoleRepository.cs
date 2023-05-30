using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interfaces;
using Audit.Core;

namespace DataAccess.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly SBMContext _context;

        public RoleRepository(SBMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles
                .Where(x => x.IsActive == true)
                .ToListAsync();
        }

        public async Task<Role?> GetAsync(int id)
        {
            return await _context.Roles
                .Where(p => p.IsActive == true)
                .FirstOrDefaultAsync(x => (int)x.Id == id);
        }

        public async Task UpdateAsync(Role role)
        {
            var roleItem = await FindAsync((int)role.Id);
            if (roleItem == null) { throw new KeyNotFoundException(); }

            roleItem.Name = role.Name;

            using (var audit = AuditScope.Create("Role:Update", () => roleItem))
            {
                audit.Event.Target.Type = "Roles";
                await _context.SaveChangesAsync();
                audit.Event.CustomFields["ReferenceId"] = roleItem.Id;
            }
        }

        public async Task CreateAsync(Role roleItem)
        {
            using (var audit = AuditScope.Create("Role:Create", () => roleItem))
            {
                audit.Event.Target.Old = null;
                audit.Event.Target.Type = "Roles";
                _context.Roles.Add(roleItem);
                await _context.SaveChangesAsync();
                audit.Event.CustomFields["ReferenceId"] = roleItem.Id;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var roleItem = await FindAsync(id);
            if (roleItem == null) { throw new KeyNotFoundException(); }

            roleItem.IsActive = false;
            roleItem.Last_IsActive_ChangeDate = DateTime.UtcNow;

            using (var audit = AuditScope.Create("Role:Delete", () => roleItem))
            {
                audit.Event.Target.Type = "Roles";
                await _context.SaveChangesAsync();
                audit.Event.CustomFields["ReferenceId"] = id;
            }
        }

        public async Task<Role?> FindAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }
    }
}
