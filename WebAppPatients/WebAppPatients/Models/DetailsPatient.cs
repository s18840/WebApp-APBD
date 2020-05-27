using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatients.Models
{
    public class DetailsPatient
    {
        public Patients Patient { get; set; }
        public IEnumerable<Prescriptions> Prescriptions { get; set; }
        public Dictionary<Prescriptions, List<Medicaments>> PrescriptionMedicamentsDict { get; set; }

        public DetailsPatient(Patients patient, IEnumerable<Prescriptions> prescriptions, Dictionary<Prescriptions, List<Medicaments>> prescriptionMedicamentsDict)
        {
            Patient = patient;
            Prescriptions = prescriptions;
            PrescriptionMedicamentsDict = prescriptionMedicamentsDict;
        }
    }
}
