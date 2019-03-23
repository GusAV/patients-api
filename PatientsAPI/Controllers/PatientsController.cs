using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmdApi.Models;

namespace Patients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientsContext _context;

        public PatientsController(PatientsContext context) => _context = context;

        // GET api/patients
        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            return _context.PatientItems;
        }

        // GET api/patients/n
        [HttpGet("{id}")]
        public ActionResult<Patient> GetSinglePatient(int id)
        {
            var patient = _context.PatientItems.Find(id);

            if (patient == null)
            {
                return NotFound();
            }
            return patient;
        }

        // POST api/patients
        [HttpPost]
        public ActionResult<Patient> PostNewPatient(Patient patient)
        {
            _context.PatientItems.Add(patient);
            _context.SaveChanges();

            return CreatedAtAction("GetSinglePatient", new Patient { id = patient.id }, patient);
        }

        // PUT api/patients/n
        [HttpPut("{id}")]
        public ActionResult<Patient> UpdatePatient(int id, Patient patient)
        {
            if (id != patient.id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/patients/n
        [HttpDelete("{id}")]
        public ActionResult<Patient> DeletePatient(int id)
        {
            var _patient = _context.PatientItems.Find(id);

            if (id != _patient.id)
            {
                return NotFound();
            }

            _context.PatientItems.Remove(_patient);
            _context.SaveChanges();
            return _patient;
        }
    }
}
