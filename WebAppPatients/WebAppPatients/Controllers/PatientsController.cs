using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppPatients.Models;
using WebAppPatients.Services;

namespace WebAppPatients.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IServiceDb _service;

        public PatientsController(IServiceDb service)
        {
            _service = service;
        }

        public IActionResult GetPatients()
        {
            return View (_service.GetPatients());
        }

        public IActionResult GetPatientDetails(int index)
        {
            return View(_service.GetPatientDetails(index));
        }

        [HttpPost]
        public IActionResult AddPatient(Patients patient)
        {
            _service.AddPatient(patient);
            return RedirectToAction("GetPatients");
        }

        public IActionResult RemovePatient(int index)
        {
            _service.RemovePatient(index);
            return RedirectToAction("GetPatients");
        }
    }
}