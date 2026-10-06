using HospitalSystem.Domain.Models;

namespace HospitalSystem.Infrastructure.Repositories.Base
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetDoctorsWithJobAndClinic();
        Doctor? GetDoctorWithJobAndClinic(int id);
    }
}
