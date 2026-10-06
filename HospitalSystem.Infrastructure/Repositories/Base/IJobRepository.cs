using HospitalSystem.Domain.Models;

namespace HospitalSystem.Infrastructure.Repositories.Base
{
    public interface IJobRepository : IRepository<Job>
    {
        bool IsInUse(int jobId);
    }
}
