using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatients.Models
{
    public partial class Prescriptions
    {
    
        public int IdPrescription { get; set; }
        public int Date { get; set; }
        public int DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public virtual Doctors IdDoctorNavigation { get; set; }
        public virtual Patients IdPatientNavigation { get; set; }
        public virtual ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; }
    }
}
