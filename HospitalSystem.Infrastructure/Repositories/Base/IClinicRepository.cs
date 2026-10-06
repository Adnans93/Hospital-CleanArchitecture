using HospitalSystem.Domain.Models;

namespace HospitalSystem.Infrastructure.Repositories.Base
{
    public interface IClinicRepository : IRepository<Clinic>
    {
        List<Clinic> GetClinicsWithDoctors(int take);
    }
}
