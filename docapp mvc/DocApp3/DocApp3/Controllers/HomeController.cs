using DocApp3.Data;
using DocApp3.Models;
using DocApp3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DocApp3.Controllers
{
    public class HomeController : Controller
    {
        private readonly PatientContext PContext;
        private readonly DoctorContext DContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PatientContext pcontext, DoctorContext dcontext)
        {
            PContext = pcontext;
            DContext = dcontext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login lg)
        {
            if (ModelState.IsValid)
            {
                if (PContext.Patient.Any(x => x.Email == lg.UserEmail && x.Password == lg.UserPassword))
                {
                    var x = PContext.Patient.Where(x => x.Email == lg.UserEmail).FirstOrDefault();
                    HttpContext.Session.SetString("patientid", x.PatientID);
                    //TempData["id"] = x.PatientID;
                    return RedirectToAction("Home", "Patients");
                }
                else if (DContext.Doctor.Any(x => x.Email == lg.UserEmail && x.Password == lg.UserPassword))
                {
                    var x = DContext.Doctor.Where(x => x.Email == lg.UserEmail).FirstOrDefault();
                    HttpContext.Session.SetString("doctorid", x.DoctorID);
                    return RedirectToAction("Home", "Doctors");
                }
                else
                {
                    ViewBag.errormessage = "Entered password is wrong, please enter valid password or enter forget password";

                }
            }


            return View();
        }
        public JsonResult IsEmailExist(string useremail)
        {
            return Json(PContext.Patient.Any(x => x.Email == useremail) || DContext.Doctor.Any(x => x.Email == useremail));
        }

    }
}
