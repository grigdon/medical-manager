using Api.MedicalManager.Database;
using Library.MedicalManager.DTO;
using Library.MedicalManager.Models;

namespace Api.MedicalManager.Enterprise
{
    public class AppointmentEC
    {
        private readonly Filebase _filebase;
        public AppointmentEC() 
        {
            _filebase = Filebase.Current;
        }
        public IEnumerable<AppointmentDTO> Appointments
        {
            get
            {
                return _filebase.Appointments.Take(100).Select(a => new AppointmentDTO(a));
            }
        }
        public IEnumerable<AppointmentDTO>? Search(string query)
        {
            return _filebase.Appointments
                .Where(a => a.Patient.Name.ToUpper()
                .Contains(query?.ToUpper() ?? string.Empty))
                .Select(a => new AppointmentDTO(a));
        }
        public AppointmentDTO? GetById(int id)
        {
            var appointment = _filebase
                .Appointments
                .FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                return new AppointmentDTO(appointment);
            }
            return null;
        }
        public AppointmentDTO? DeleteById(int id)
        {
            var appointmentToDelete = _filebase.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointmentToDelete != null)
            {
                _filebase.Appointments.Remove(appointmentToDelete);
                return new AppointmentDTO(appointmentToDelete);
            }
            return null;
        }
        public Appointment? AddOrUpdate(AppointmentDTO? appointment)
        {
            if (appointment == null)
            {
                return null;
            }
            return _filebase.AddOrUpdateAppointment(new Appointment(appointment));
        }

    }
}
