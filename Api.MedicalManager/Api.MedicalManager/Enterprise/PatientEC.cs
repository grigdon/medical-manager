using Api.MedicalManager.Database;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;

namespace Api.MedicalManager.Enterprise
{
    public class PatientEC
    {
        private readonly Filebase _filebase;
        public PatientEC() 
        {
            _filebase = Filebase.Current;
        }
        public IEnumerable<PatientDTO> Patients
        {
            get
            {
                return _filebase.Patients.Take(100).Select(p => new PatientDTO(p));
            }
        }
        public IEnumerable<PatientDTO>? Search(string query)
        {
            return _filebase.Patients
                .Where(p => p.Name.ToUpper()
                .Contains(query?.ToUpper() ?? string.Empty))
                .Select(p => new PatientDTO(p));
        }
        public PatientDTO? GetById(int id)
        {
            var patient = _filebase
                .Patients
                .FirstOrDefault(p => p.Id == id);
            if(patient != null)
            {
                return new PatientDTO(patient);
            }
            return null;
        }
        public PatientDTO? DeleteById(int id)
        {
            var patientToDelete = _filebase.Patients.FirstOrDefault(p => p.Id == id);
            if(patientToDelete != null)
            {
                _filebase.Patients.Remove(patientToDelete);
                return new PatientDTO(patientToDelete);
            }
            return null;
        }
        public Patient? AddOrUpdate(PatientDTO? patient)
        {
            if(patient == null)
            {
                return null;
            }
            return _filebase.AddOrUpdatePatient(new Patient(patient));
        }
    }
}
