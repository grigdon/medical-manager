using Api.MedicalManager.Enterprise;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.MedicalManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PatientDTO> Get()
        {
            return new PatientEC().Patients;
        }

        [HttpGet("{id}")]
        public PatientDTO? GetById(int id)
        {
            return new PatientEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public PatientDTO? DeleteByID(int id)
        {
            return new PatientEC().DeleteById(id);
        }
        [HttpPost("Search")]
        public List<PatientDTO> Search([FromBody] Query query)
        {
            return new PatientEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<PatientDTO>();
        }
        [HttpPost]
        public Patient? AddOrUpdate([FromBody] PatientDTO? patient)
        {
            return new PatientEC().AddOrUpdate(patient);
        }
    }
}