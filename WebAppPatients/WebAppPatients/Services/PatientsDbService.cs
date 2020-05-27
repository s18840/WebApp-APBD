using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPatients.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAppPatients.Services
{
    public class PatientsDbService : IServiceDb
    {
        private readonly PersonsDbContext _context;

        public PatientsDbService(PersonsDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Patients> GetPatients()
        {
            return _context.Patients.ToList();
        }

        public DetailsPatient GetPatientDetails(int index)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.IdPatient == index);
            var prescriptions = _context.Prescriptions.Where(p => p.IdPatient == index).ToList();
            var dictionary = new Dictionary<Prescriptions, List<Medicaments>>();

            foreach (var presc in prescriptions)
            {
                var meds = _context.PrescriptionMedicament.Where(p => p.IdPrescription == presc.IdPrescription).Select(prescMed => _context.Medicaments.First(m => m.IdMedicament == prescMed.IdMedicament)).ToList();
                dictionary.Add(presc, meds);
            }

            return new DetailsPatient(patient, prescriptions, dictionary);
        }

        public void AddPatient(Patients patient)
        {
            throw new NotImplementedException();
        }

        public void RemovePatient(int index)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.IdPatient == index);

            if (patient == null) return;

            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }
    }
}
