using System.Collections.Generic;
using HospitalSystem.Application.Dtos;

namespace HospitalSystem.Application.Dtos.UsersDtos
{
    public class UserRolesVM
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<RoleCheckVM> Roles { get; set; } = new List<RoleCheckVM>();
    }
}