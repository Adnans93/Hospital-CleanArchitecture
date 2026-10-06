using HospitalSystem.Infrastructure.Data;
using HospitalSystem.Domain.Models;
using HospitalSystem.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Infrastructure.Repositories
{
    public class MedicalRecordRepository : Repository<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<MedicalRecord> GetRecordsWithPatient()
        {
            return _context.MedicalRecords
                .Include(m => m.Patient)
                .OrderByDescending(m => m.VisitDate)
                .ToList();
        }
    }
}
