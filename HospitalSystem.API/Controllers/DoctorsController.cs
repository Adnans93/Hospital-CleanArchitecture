using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalSystem.Application.Dtos.HospitalDtos;
using HospitalSystem.Application.Services.Base;

namespace HospitalSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("GetDoctors")]
        public IActionResult GetDoctors()
        {
            try
            {
                var doctors = _doctorService.GetDoctorsWithJobAndClinic();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            try
            {
                _doctorService.CreateDoctor(createDoctorDto);
                return Ok("Data Added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
