using HospitalSystem.Domain.Models;

namespace HospitalSystem.Application.Services.Base
{
    public interface IPatientService
    {
        IEnumerable<Patient> SearchPatients(string? search);
        Patient? GetPatientById(int id);
        Patient? GetPatientWithHistory(int id);
        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}
