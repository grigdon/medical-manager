using Api.MedicalManager.Database;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;

namespace Api.MedicalManager.Enterprise
{
    public class TreatmentEC
    {
        private readonly Filebase _filebase;
        public TreatmentEC()
        {
            _filebase = Filebase.Current;
        }
        public IEnumerable<TreatmentDTO> Treatments
        {
            get
            {
                return _filebase.Treatments.Take(100).Select(t => new TreatmentDTO(t));
            }
        }
        public IEnumerable<TreatmentDTO>? Search(string query)
        {
            return _filebase.Treatments
                .Where(p => p.Name.ToUpper()
                .Contains(query?.ToUpper() ?? string.Empty))
                .Select(p => new TreatmentDTO(p));
        }
        public TreatmentDTO? GetById(int id)
        {
            var treatment = _filebase
                .Treatments
                .FirstOrDefault(t => t.Id == id);
            if (treatment != null)
            {
                return new TreatmentDTO(treatment);
            }
            return null;
        }
        public TreatmentDTO? DeleteById(int id)
        {
            var treatmentToDelete = _filebase.Treatments.FirstOrDefault(t => t.Id == id);
            if (treatmentToDelete != null)
            {
                _filebase.Treatments.Remove(treatmentToDelete);
                return new TreatmentDTO(treatmentToDelete);
            }
            return null;
        }
        public Treatment? AddOrUpdate(TreatmentDTO? treatment)
        {
            if (treatment == null)
            {
                return null;
            }
            return _filebase.AddOrUpdateTreatment(new Treatment(treatment));
        }
    }
}
