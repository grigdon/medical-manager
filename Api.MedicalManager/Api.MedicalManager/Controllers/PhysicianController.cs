using Api.MedicalManager.Enterprise;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.MedicalManager.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PhysicianController: ControllerBase
    {
        private readonly ILogger<PhysicianController> _logger;

        public PhysicianController(ILogger<PhysicianController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PhysicianDTO> Get()
        {
            return new PhysicianEC().Physicians;
        }

        [HttpGet("{id}")]
        public PhysicianDTO? GetById(int id)
        {
            return new PhysicianEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public PhysicianDTO? DeleteByID(int id)
        {
            return new PhysicianEC().DeleteById(id);
        }
        [HttpPost("Search")]
        public List<PhysicianDTO> Search([FromBody] Query query)
        {
            return new PhysicianEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<PhysicianDTO>();
        }
        [HttpPost]
        public Physician? AddOrUpdate([FromBody] PhysicianDTO? physician)
        {
            return new PhysicianEC().AddOrUpdate(physician);
        }
    }
}
