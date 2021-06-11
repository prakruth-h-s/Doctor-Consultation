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
    public class AppointmentsController : Controller
    {
        private readonly AppointmentContext _context;
        private readonly PatientContext PContext;
        private readonly DoctorContext DContext;

        public AppointmentsController(AppointmentContext context, PatientContext pcontext, DoctorContext dcontext)
        {
            PContext = pcontext;
            DContext = dcontext;
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appointment.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create(string doctorid)
        {
            HttpContext.Session.SetString("pdoctorid", doctorid);
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentID,PatientID,DoctorID,AppointmentDate,HealthIssue,PrescriptionGiven,Rating,ReviewComment")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var r = await _context.Appointment.OrderByDescending(e => e.AppointmentID).FirstOrDefaultAsync();
                if (r == null)
                {
                    appointment.AppointmentID = "APT0001";
                }
                else
                {
                    appointment.AppointmentID = "APT" + (int.Parse(r.AppointmentID.Substring(3)) + 1).ToString().PadLeft(4, '0');
                }
                appointment.DoctorID = HttpContext.Session.GetString("pdoctorid");
                appointment.PatientID = HttpContext.Session.GetString("patientid");
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("MyAppointment", "Patients");
            }
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AppointmentID,PatientID,DoctorID,AppointmentDate,HealthIssue,PrescriptionGiven,Rating,ReviewComment")] Appointment appointment)
        {
            if (id != appointment.AppointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.AppointmentID))
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
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .FirstOrDefaultAsync(m => m.AppointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(string id)
        {
            return _context.Appointment.Any(e => e.AppointmentID == id);
        }

        public JsonResult IsDateValid(DateTime AppointmentDate)
        {
            var docID = HttpContext.Session.GetString("pdoctorid");
            var slots = _context.Appointment.Where(x => (x.DoctorID == docID) && (x.AppointmentDate < AppointmentDate.AddMinutes(30)) && (x.AppointmentDate
         > AppointmentDate.Add(new TimeSpan(0, -30, 0)))).FirstOrDefault();
            DateTime now = DateTime.Now;
            if (AppointmentDate.CompareTo(now) < 0)
            {
                return Json("Enter valid date and time");
            }
            else if (slots != null)
            {
                return Json("Slot not available for the given doctor and time");
            }
            else
            {
                return Json(true);
            }

        }
    }
}
