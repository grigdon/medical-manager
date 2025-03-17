using Library.MedicalManager.Models;
using Newtonsoft.Json;

namespace Api.MedicalManager.Database
{
    public static class EntityHelper<T>
    {
        public static int GetLastKey<T>(List<T> entities) where T : IEntity
        {
            if (entities.Any())
            {
                return entities.Select(x => x.Id).Max();
            }
            return 0;
        }
    }
    public class Filebase
    {
        private static object _lock = new object();
        private static Filebase? _instance;
        private string _root = @"C:\temp";
        private string _patientRoot,
                       _physicianRoot,
                       _appointmentRoot,
                       _treatmentRoot,
                       _insurancePolicyRoot;
        public static Filebase Current
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Filebase();
                    }
                    return _instance;
                }
            }
        }

        private Filebase()
        {
            _instance = null;
            DeclareRoots();
            
        }
        public Patient AddOrUpdatePatient(Patient patient)
        {
            if(patient.Id <= 0)
            {
                patient.Id = EntityHelper<Patient>.GetLastKey(Filebase._instance.Patients) + 1;
            }

            string path = $"{_patientRoot}\\{patient.Id}.json";

            if(File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(patient));

            return patient;
        }

        public List<Patient> Patients
        {
            get
            {
                var root = new DirectoryInfo(_patientRoot);
                var _patients = new List<Patient>();
                foreach(var patientFile in root.GetFiles())
                {
                    var patient = JsonConvert
                        .DeserializeObject<Patient>
                        (File.ReadAllText(patientFile.FullName));
                    if(patient != null)
                    {
                        _patients.Add(patient);
                    }
                }
                return _patients;
            }
        }
        public Physician AddOrUpdatePhysician(Physician physician)
        {
            if (physician.Id <= 0)
            {
                physician.Id = EntityHelper<Physician>.GetLastKey(Filebase._instance.Physicians) + 1;
            }

            string path = $"{_physicianRoot}\\{physician.Id}.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(physician));

            return physician;
        }

        public List<Physician> Physicians
        {
            get
            {
                var root = new DirectoryInfo(_physicianRoot);
                var _physicians = new List<Physician>();
                foreach (var physicianFile in root.GetFiles())
                {
                    var physician = JsonConvert
                        .DeserializeObject<Physician>
                        (File.ReadAllText(physicianFile.FullName));
                    if (physician != null)
                    {
                        _physicians.Add(physician);
                    }
                }
                return _physicians;
            }
        }
        public Appointment AddOrUpdateAppointment(Appointment appointment)
        {
            if (appointment.Id <= 0)
            {
                appointment.Id = EntityHelper<Appointment>.GetLastKey(Filebase._instance.Appointments) + 1;
            }

            string path = $"{_appointmentRoot}\\{appointment.Id}.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(appointment));

            return appointment;
        }

        public List<Appointment> Appointments
        {
            get
            {
                var root = new DirectoryInfo(_appointmentRoot);
                var _appointments = new List<Appointment>();
                foreach (var appointmentFile in root.GetFiles())
                {
                    var appointment = JsonConvert
                        .DeserializeObject<Appointment>
                        (File.ReadAllText(appointmentFile.FullName));
                    if (appointment != null)
                    {
                        _appointments.Add(appointment);
                    }
                }
                return _appointments;
            }
        }
        public Treatment AddOrUpdateTreatment(Treatment treatment)
        {
            if (treatment.Id <= 0)
            {
                treatment.Id = EntityHelper<Treatment>.GetLastKey(Filebase._instance.Patients) + 1;
            }

            string path = $"{_treatmentRoot}\\{treatment.Id}.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(treatment));

            return treatment;
        }

        public List<Treatment> Treatments
        {
            get
            {
                var root = new DirectoryInfo(_treatmentRoot);
                var _treatments = new List<Treatment>();
                foreach (var treatmentFile in root.GetFiles())
                {
                    var treatment = JsonConvert
                        .DeserializeObject<Treatment>
                        (File.ReadAllText(treatmentFile.FullName));
                    if (treatment != null)
                    {
                        _treatments.Add(treatment);
                    }
                }
                return _treatments;
            }
        }
        public InsurancePolicy AddOrUpdateInsurancePolicy(InsurancePolicy insurancePolicy)
        {
            if (insurancePolicy.Id <= 0)
            {
                insurancePolicy.Id = EntityHelper<InsurancePolicy>.GetLastKey(Filebase._instance.InsurancePolicies) + 1;
            }

            string path = $"{_insurancePolicyRoot}\\{insurancePolicy.Id}.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(insurancePolicy));

            return insurancePolicy;
        }

        public List<InsurancePolicy> InsurancePolicies
        {
            get
            {
                var root = new DirectoryInfo(_insurancePolicyRoot);
                var _insurancePolicies = new List<InsurancePolicy>();
                foreach (var insurancePolicyFile in root.GetFiles())
                {
                    var insurancePolicy = JsonConvert
                        .DeserializeObject<InsurancePolicy>
                        (File.ReadAllText(insurancePolicyFile.FullName));
                    if (insurancePolicy != null)
                    {
                        _insurancePolicies.Add(insurancePolicy);
                    }
                }
                return _insurancePolicies;
            }
        }
        public bool Delete(string type, string id)
        {
            if (File.Exists(type))
            {
                File.Delete(type);
            }
            return true;
        }
        public void DeclareRoots()
        {
            _patientRoot = $"{_root}\\Patients";
            _physicianRoot = $"{_root}\\Physicians";
            _appointmentRoot = $"{_root}\\Appointments";
            _treatmentRoot = $"{_root}\\Treatments";
            _insurancePolicyRoot = $"{_root}\\InsurancePolicies";
        }
    }
}
