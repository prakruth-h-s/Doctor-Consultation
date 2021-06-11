using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocApp3.Data;
using DocApp3.Models;
using Microsoft.AspNetCore.Http;
using DocApp3.Services;

namespace DocApp3.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientContext _context;
        private readonly DoctorContext DContext;
        private readonly AppointmentContext AContext;

        public PatientsController(PatientContext context, DoctorContext dcontext, AppointmentContext acontext)
        {
            AContext = acontext;
            DContext = dcontext;
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patient.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FirstOrDefaultAsync(m => m.PatientID == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientID,Name,Contact,Email,Password")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                var r = await _context.Patient.OrderByDescending(e => e.PatientID).FirstOrDefaultAsync();
                if (r == null)
                {
                    patient.PatientID = "PAT0001";
                }
                else
                {
                    patient.PatientID = "PAT" + (int.Parse(r.PatientID.Substring(3)) + 1).ToString().PadLeft(4, '0');
                }
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Home");
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PatientID,Name,Contact,Email,Password")] Patient patient)
        {
            if (id != patient.PatientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.PatientID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient
                .FirstOrDefaultAsync(m => m.PatientID == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var patient = await _context.Patient.FindAsync(id);
            _context.Patient.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(string id)
        {
            return _context.Patient.Any(e => e.PatientID == id);
        }
        public JsonResult IsEmailAvailable(string email)
        {
            return Json(!_context.Patient.Any(x => x.Email == email));
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Specialization()
        {
            return View();
        }
        public IActionResult SpecializeDoctor(string specialization)
        {
            return View(DContext.Doctor.Where(x => x.Specialization == specialization).ToList());
        }
        public IActionResult MyAppointment()
        {
            var patID = HttpContext.Session.GetString("patientid");
            var app = AContext.Appointment.Where(x => x.PatientID == patID).ToList();
            return View(app);
        }
        public IActionResult MyPrescription()
        {
            var patID = HttpContext.Session.GetString("patientid");
            var app = AContext.Appointment.Where(x => x.PatientID == patID).ToList();
            return View(app);
        }
        public IActionResult AddRating(string aptid)
        {

            return View(AContext.Appointment.Where(x => x.AppointmentID == aptid).FirstOrDefault());
        }
        [HttpPost]
        public IActionResult AddRating(Appointment appointment)
        {

            AContext.Update(appointment);
            AContext.SaveChanges();
            return RedirectToAction(nameof(MyPrescription));

        }
    }
}
