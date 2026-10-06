using Microsoft.AspNetCore.Http;
using HospitalSystem.Application.Dtos.UsersDtos;
using HospitalSystem.Domain.Models;

namespace HospitalSystem.Application.Services.Base
{
    public interface IUserService
    {
        // تسجيل الدخول: يرجع JWT Token أو null إذا البيانات غلط
        string? Login(string username, string password);
        DateTime GetTokenExpiry();

        IEnumerable<UsersDto> GetAllUsers();
        User? GetUserById(int id);
        User? GetUserByUid(string uid);
        bool UsernameExists(string username, int? exceptUserId = null);
        void CreateUser(CreateUserDto userDto);
        void UpdateUser(UpdateUserDto userDto);
        void DeleteUser(User user);

        UserRolesVM? GetUserRoles(int userId);
        void SaveUserRoles(UserRolesVM model);

        List<UserFile> GetUserFiles(int userId);
        UserFile? GetUserFile(int fileId);
        void AddUserFile(UserFile userFile, IFormFile file);
        void DeleteUserFile(UserFile file);

        IEnumerable<Doctor> GetAllDoctors();
    }
}
