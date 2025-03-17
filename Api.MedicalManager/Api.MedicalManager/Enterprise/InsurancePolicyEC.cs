using Api.MedicalManager.Database;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;

namespace Api.MedicalManager.Enterprise
{
    public class InsurancePolicyEC
    {
        private readonly Filebase _filebase;
        public InsurancePolicyEC() 
        {
            _filebase = Filebase.Current;
        }
        public IEnumerable<InsurancePolicyDTO> InsurancePolicies
        {
            get
            {
                return _filebase.InsurancePolicies.Take(100).Select(i => new InsurancePolicyDTO(i));
            }
        }
        public IEnumerable<InsurancePolicyDTO>? Search(string query)
        {
            return _filebase.InsurancePolicies
                .Where(i => i.Name.ToUpper()
                .Contains(query?.ToUpper() ?? string.Empty))
                .Select(i => new InsurancePolicyDTO(i));
        }
        public InsurancePolicyDTO? GetById(int id)
        {
            var insurancePolicy = _filebase
                .InsurancePolicies
                .FirstOrDefault(i => i.Id == id);
            if (insurancePolicy != null)
            {
                return new InsurancePolicyDTO(insurancePolicy);
            }
            return null;
        }
        public InsurancePolicyDTO? DeleteById(int id)
        {
            var insurancePolicyToDelete = _filebase.InsurancePolicies.FirstOrDefault(i => i.Id == id);
            if (insurancePolicyToDelete != null)
            {
                _filebase.InsurancePolicies.Remove(insurancePolicyToDelete);
                return new InsurancePolicyDTO(insurancePolicyToDelete);
            }
            return null;
        }
        public InsurancePolicy? AddOrUpdate(InsurancePolicyDTO? insurancePolicy)
        {
            if (insurancePolicy == null)
            {
                return null;
            }
            return _filebase.AddOrUpdateInsurancePolicy(new InsurancePolicy(insurancePolicy));
        }
    }
}
