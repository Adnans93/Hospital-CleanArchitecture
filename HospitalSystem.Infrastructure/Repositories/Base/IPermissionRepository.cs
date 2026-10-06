using HospitalSystem.Domain.Models;

namespace HospitalSystem.Infrastructure.Repositories.Base
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        List<string> GetUserPermissions(int userId);
        List<Permission> GetByIds(IEnumerable<int> ids);
    }
}
