using HospitalSystem.Infrastructure.Data;
using HospitalSystem.Domain.Models;
using HospitalSystem.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Infrastructure.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Role> GetRolesWithPermissions()
        {
            return _context.Roles.Include(r => r.Permissions).ToList();
        }

        public Role? GetRoleWithPermissions(int id)
        {
            return _context.Roles.Include(r => r.Permissions).FirstOrDefault(r => r.Id == id);
        }
    }
}
