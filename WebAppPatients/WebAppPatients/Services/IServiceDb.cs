using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatients.Models;

namespace WebAppPatients.Services
{
    public interface IServiceDb
    {
        public IEnumerable<Patients> GetPatients();
        public DetailsPatient GetPatientDetails(int index);
        public void AddPatient(Patients patient);
        public void RemovePatient(int index);
        
    }
}
