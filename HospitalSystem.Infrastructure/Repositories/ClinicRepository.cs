using HospitalSystem.Infrastructure.Data;
using HospitalSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using HospitalSystem.Infrastructure.Repositories.Base;

namespace HospitalSystem.Infrastructure.Repositories
{
    public class ClinicRepository : Repository<Clinic>, IClinicRepository
    {
        public ClinicRepository(AppDbContext context) : base(context)
        {
        }

        // عدد الأطباء في كل عيادة (للوحة التحكم)
        public List<Clinic> GetClinicsWithDoctors(int take)
        {
            return _context.Clinics
                .Include(c => c.Doctors)
                .OrderByDescending(c => c.Doctors!.Count())
                .Take(take)
                .ToList();
        }
    }
}
