using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;
using BarberShop.ViewModel;
using BarberShop.Services;

namespace BarberShop.Controllers
{
    public class HomeController : Controller
    {

        private UserManager<User> _userManager;
        private IRepository _repository;
        public HomeController(IRepository repository, UserManager<User> userManager)
        {
            _userManager = userManager;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Account/Services")]
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        [Authorize]
        public IActionResult AllAppointments()
        {
            //shows all the appointments to perform CRUD 
            var model = _repository.GetAppointment();
            return View(model);
        }
       [HttpGet]
        public IActionResult CreateAppointment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAppointment(AppointmentViewModel appointmentViewModel)
        {
            if (ModelState.IsValid)
            {
                Appointment newappointment = new Appointment();
                //newappointment.UserId = this.User
                //find out how to associate userid with user 
                newappointment.Barber = appointmentViewModel.Barber;
                newappointment.AppointmentDateTime = appointmentViewModel.AppointmentDateTime;
                newappointment.ServiceRequested = appointmentViewModel.ServiceRequesting;
                // Appointment.User = customer;
                //Appointment.Id = _userManager.GetUserId(User);
                _repository.AddAppointment(newappointment);
                return RedirectToAction("AllAppointments", "Home");
            }

            return View();
        }
        [HttpGet]
        public ViewResult Update(int id)
        {
            Appointment obj = _repository.GetAppointment(id);
            return View(obj);
        }
        [HttpPost]
        public ViewResult Update(Appointment obj, int id)
        {
            obj.AppointmentId = id;
            Appointment changedappli = _repository.UpdateAppointment(obj);
            var model = _repository.GetAppointment();
            return View("AllAppointments", model);
        }
        public IActionResult Delete(int id)
        {
            _repository.DeleteAppointment(id);
            return RedirectToAction("AllAppointments");
        }
    }
}
