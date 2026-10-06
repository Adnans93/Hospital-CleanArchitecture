using HospitalSystem.Infrastructure.Data;
using HospitalSystem.Domain.Models;
using HospitalSystem.Infrastructure.Repositories.Base;

namespace HospitalSystem.Infrastructure.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context)
        {
        }

        // هل المسمى الوظيفي مرتبط بأطباء؟
        public bool IsInUse(int jobId)
        {
            return _context.Doctors.Any(d => d.JobId == jobId);
        }
    }
}
