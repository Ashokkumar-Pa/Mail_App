using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mail_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Home/Index")]

        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet]
        [Route("Home/Student")]

        public IEnumerable<StudentAttendanceDetailsModel> Getst()
        {
            StudentAttendanceDetailsModel attendanceObj1 = new StudentAttendanceDetailsModel();
            StudentAttendanceDetailsModel attendanceObj2 = new StudentAttendanceDetailsModel();
            attendanceObj1.StudentID = 1;
            attendanceObj1.StudentName = "Adam";
            attendanceObj1.AttendencePercentage = 83.02;
            attendanceObj2.StudentID = 2;
            attendanceObj2.StudentName = "Brad";
            attendanceObj2.AttendencePercentage = 71.02;
            List<StudentAttendanceDetailsModel> listObj = new List<StudentAttendanceDetailsModel>
            {
                attendanceObj1,
                attendanceObj2
            };
            return listObj;
        }
    }
}
