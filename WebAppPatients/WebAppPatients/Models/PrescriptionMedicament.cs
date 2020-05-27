using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatients.Models
{
    public partial class PrescriptionMedicament
    {
        public int IdPrescription { get; set; }
        public int IdMedicament { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
        public virtual Medicaments IdMedicamentNavigation { get; set; }
        public virtual Prescriptions IdPrescriptionNavigation { get; set; }
    }
}
