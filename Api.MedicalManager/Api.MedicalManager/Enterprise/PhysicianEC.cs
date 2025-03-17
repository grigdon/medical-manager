using Api.MedicalManager.Database;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;
namespace Api.MedicalManager.Enterprise
{
    public class PhysicianEC
    {
        private readonly Filebase _filebase;
        public PhysicianEC()
        {
            _filebase = Filebase.Current;
        }
        public IEnumerable<PhysicianDTO> Physicians
        {
            get
            {
                return _filebase.Physicians.Take(100).Select(p => new PhysicianDTO(p));
            }
        }
        public IEnumerable<PhysicianDTO>? Search(string query)
        {
            return _filebase.Physicians
                .Where(p => p.Name.ToUpper()
                .Contains(query?.ToUpper() ?? string.Empty))
                .Select(p => new PhysicianDTO(p));
        }
        public PhysicianDTO? GetById(int id)
        {
            var physician = _filebase
                .Physicians
                .FirstOrDefault(p => p.Id == id);
            if (physician != null)
            {
                return new PhysicianDTO(physician);
            }
            return null;
        }
        public PhysicianDTO? DeleteById(int id)
        {
            var physicianToDelete = _filebase.Physicians.FirstOrDefault(p => p.Id == id);
            if (physicianToDelete != null)
            {
                _filebase.Physicians.Remove(physicianToDelete);
                return new PhysicianDTO(physicianToDelete);
            }
            return null;
        }
        public Physician? AddOrUpdate(PhysicianDTO? physician)
        {
            if (physician == null)
            {
                return null;
            }
            return _filebase.AddOrUpdatePhysician(new Physician(physician));
        }
    }
}
