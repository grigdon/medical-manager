using Api.MedicalManager.Enterprise;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.MedicalManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController: ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        public AppointmentController(ILogger<AppointmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AppointmentDTO> Get()
        {
            return new AppointmentEC().Appointments;
        }

        [HttpGet("{id}")]
        public AppointmentDTO? GetById(int id)
        {
            return new AppointmentEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public AppointmentDTO? DeleteByID(int id)
        {
            return new AppointmentEC().DeleteById(id);
        }
        [HttpPost("Search")]
        public List<AppointmentDTO> Search([FromBody] Query query)
        {
            return new AppointmentEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<AppointmentDTO>();
        }
        [HttpPost]
        public Appointment? AddOrUpdate([FromBody] AppointmentDTO? appointment)
        {
            return new AppointmentEC().AddOrUpdate(appointment);
        }
    }
}
