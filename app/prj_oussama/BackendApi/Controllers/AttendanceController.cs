using Microsoft.AspNetCore.Mvc;
using BackendApi.Models;
using BackendApi.Services;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;
        private static readonly OfficeLocation _office = new OfficeLocation { Latitude = 36.7525, Longitude = 3.0420 }; // Exemple Alger

        public AttendanceController()
        {
            _attendanceService = new AttendanceService(_office);
        }

        [HttpPost("validate")]
        public ActionResult<AttendanceValidationResult> ValidateAttendance([FromBody] AttendanceValidationRequest request)
        {
            var result = _attendanceService.ValidateAttendance(request.Latitude, request.Longitude, request.IsFingerprintAuthenticated);
            return Ok(result);
        }
    }

    public class AttendanceValidationRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsFingerprintAuthenticated { get; set; }
        public string FingerprintId { get; set; } // Pour simulation
    }
}
