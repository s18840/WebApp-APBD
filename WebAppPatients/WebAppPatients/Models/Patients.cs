using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPatients.Models
{
    public class Patients
    {
        public Patients()
        {
            Prescriptions = new HashSet<Prescriptions>();
        }

        public int IdPatient { get; set; }
        [DisplayName("Imię")]public string FirstName { get; set; }
        [DisplayName("Nazwisko")]public string LastName { get; set; }
        [DisplayName("Data urodzenia")]public DateTime Birthdate { get; set; }
        public virtual ICollection<Prescriptions> Prescriptions { get; set; }
    }
}

