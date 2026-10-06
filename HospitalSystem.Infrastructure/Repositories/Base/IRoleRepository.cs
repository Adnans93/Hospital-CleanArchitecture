using HospitalSystem.Domain.Models;

namespace HospitalSystem.Infrastructure.Repositories.Base
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetRolesWithPermissions();
        Role? GetRoleWithPermissions(int id);
    }
}
