using Api.MedicalManager.Enterprise;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.MedicalManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsurancePolicyController: ControllerBase
    {
        private readonly ILogger<InsurancePolicyController> _logger;

        public InsurancePolicyController(ILogger<InsurancePolicyController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<InsurancePolicyDTO> Get()
        {
            return new InsurancePolicyEC().InsurancePolicies;
        }

        [HttpGet("{id}")]
        public InsurancePolicyDTO? GetById(int id)
        {
            return new InsurancePolicyEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public InsurancePolicyDTO? DeleteByID(int id)
        {
            return new InsurancePolicyEC().DeleteById(id);
        }
        [HttpPost("Search")]
        public List<InsurancePolicyDTO> Search([FromBody] Query query)
        {
            return new InsurancePolicyEC().Search(query?.Content ?? string.Empty)?.ToList() ?? new List<InsurancePolicyDTO>();
        }
        [HttpPost]
        public InsurancePolicy? AddOrUpdate([FromBody] InsurancePolicyDTO? InsurancePolicy)
        {
            return new InsurancePolicyEC().AddOrUpdate(InsurancePolicy);
        }
    }
}
