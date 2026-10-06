using System.ComponentModel.DataAnnotations.Schema;
using HospitalSystem.Application.Dtos;

namespace HospitalSystem.Application.Dtos.UsersDtos
{
    public class UpdateUserDto : CreateUserDto
    {
        public int Id { get; set; }
    }
}