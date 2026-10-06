using HospitalSystem.Domain.Models;
using HospitalSystem.Infrastructure.Repositories.Base;
using HospitalSystem.Application.Services.Base;

namespace HospitalSystem.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Patient> SearchPatients(string? search)
        {
            return _unitOfWork.PatientRepo.Search(search);
        }

        public Patient? GetPatientById(int id)
        {
            return _unitOfWork.PatientRepo.GetById(id);
        }

        public Patient? GetPatientWithHistory(int id)
        {
            return _unitOfWork.PatientRepo.GetPatientWithHistory(id);
        }

        public void CreatePatient(Patient patient)
        {
            _unitOfWork.PatientRepo.Add(patient);
            _unitOfWork.Save();
        }

        public void UpdatePatient(Patient patient)
        {
            _unitOfWork.PatientRepo.Update(patient);
            _unitOfWork.Save();
        }

        public void DeletePatient(int id)
        {
            var patient = _unitOfWork.PatientRepo.GetById(id);
            if (patient != null)
            {
                _unitOfWork.PatientRepo.Delete(patient);
                _unitOfWork.Save();
            }
        }
    }
}
