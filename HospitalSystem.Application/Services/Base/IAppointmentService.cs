using HospitalSystem.Application.Dtos.HospitalDtos;
using HospitalSystem.Domain.Models;

namespace HospitalSystem.Application.Services.Base
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentDto> GetAppointments(string? status, int? doctorId, bool ownOnly);
        AppointmentDto? GetAppointmentById(int id);
        void CreateAppointment(AppointmentDto appointmentDto);
        void UpdateAppointment(AppointmentDto appointmentDto);
        bool ChangeStatus(int id, string status, int? doctorId, bool ownOnly);
        void DeleteAppointment(int id);

        IEnumerable<Doctor> GetAllDoctors();
        IEnumerable<Patient> GetAllPatients();

        // بيانات لوحة التحكم
        DashboardVM GetDashboard(int? doctorId, bool ownOnly);
    }
}
