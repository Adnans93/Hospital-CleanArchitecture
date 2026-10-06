using HospitalSystem.Domain.Models;

namespace HospitalSystem.Infrastructure.Repositories.Base
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IEnumerable<Patient> Search(string? search);
        Patient? GetPatientWithHistory(int id);
        IEnumerable<Patient> GetRecent(int take);
    }
}
