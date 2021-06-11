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
    public class DoctorsController : Controller
    {
        private readonly DoctorContext _context;
        private readonly AppointmentContext AContext;
        private readonly PatientContext PContext;

        public DoctorsController(DoctorContext context, AppointmentContext acontext, PatientContext pcontext)
        {
            AContext = acontext;
            PContext = pcontext;
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doctor.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorID,Name,Contact,Email,Password,Specialization")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var r = await _context.Doctor.OrderByDescending(e => e.DoctorID).FirstOrDefaultAsync();
                if (r == null)
                {
                    doctor.DoctorID = "DOC0001";
                }
                else
                {
                    doctor.DoctorID = "DOC" + (int.Parse(r.DoctorID.Substring(3)) + 1).ToString().PadLeft(4, '0');
                }
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DoctorID,Name,Contact,Email,Password,Specialization")] Doctor doctor)
        {
            if (id != doctor.DoctorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.DoctorID))
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
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.DoctorID == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(string id)
        {
            return _context.Doctor.Any(e => e.DoctorID == id);
        }
        public JsonResult IsEmailAvailable(string email)
        {
            return Json(!_context.Doctor.Any(x => x.Email == email));
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult MyAppointment()
        {
            var docID = HttpContext.Session.GetString("doctorid");
            var app = AContext.Appointment.Where(x => x.DoctorID == docID).ToList();
            return View(app);
        }
        public IActionResult Prescription()
        {
            var docID = HttpContext.Session.GetString("doctorid");
            var app = AContext.Appointment.Where(x => (x.DoctorID == docID) && (x.PrescriptionGiven == null)).ToList();
            return View(app);

        }

        public IActionResult WritePrescription(string aptid)
        {

            return View(AContext.Appointment.Where(x => x.AppointmentID == aptid).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult WritePrescription(Appointment appointment)
        {

            AContext.Update(appointment);
            AContext.SaveChanges();
            return RedirectToAction(nameof(Prescription));

        }
        public IActionResult MyRatings()
        {
            var docID = HttpContext.Session.GetString("doctorid");
            var app = AContext.Appointment.Where(x => x.DoctorID == docID).ToList();
            return View(app);
            
        }

    }
}
