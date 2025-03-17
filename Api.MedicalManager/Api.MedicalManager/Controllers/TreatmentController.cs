using Api.MedicalManager.Enterprise;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.MedicalManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreatmentController: ControllerBase
    {
        private readonly ILogger<TreatmentController> _logger;

        public TreatmentController(ILogger<TreatmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TreatmentDTO> Get()
        {
            return new TreatmentEC().Treatments;
        }

        [HttpGet("{id}")]
        public TreatmentDTO? GetById(int id)
        {
            return new TreatmentEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public TreatmentDTO? DeleteByID(int id)
        {
            return new TreatmentEC().DeleteById(id);
        }
        [HttpPost("Search")]
        public List<TreatmentDTO> Search([FromBody] Query query)
        {
            return new TreatmentEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<TreatmentDTO>();
        }
        [HttpPost]
        public Treatment? AddOrUpdate([FromBody] TreatmentDTO? treatment)
        {
            return new TreatmentEC().AddOrUpdate(treatment);
        }
    }
}
