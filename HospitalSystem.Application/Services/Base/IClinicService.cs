using HospitalSystem.Application.Dtos.HospitalDtos;
using HospitalSystem.Domain.Models;

namespace HospitalSystem.Application.Services.Base
{
    public interface IClinicService
    {
        IEnumerable<Clinic> GetAllClinics();
        Clinic? GetClinicById(int id);
        void CreateClinic(ClinicDto clinicDto);
        void UpdateClinic(Clinic clinic);
        void DeleteClinic(int id);
    }
}
