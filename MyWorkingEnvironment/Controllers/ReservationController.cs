﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Repository;

namespace MyWorkingEnvironment.Controllers
{
    public class ReservationController : Controller
    {
        private EmployeeRepository _employeeRepository;
        private ReservationRepository _reservationRepository;

        public ReservationController(ApplicationDbContext dbContext)
        {
            _employeeRepository = new EmployeeRepository(dbContext);
            _reservationRepository = new ReservationRepository(dbContext);
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            return View(_reservationRepository.GetAllReservations());
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(Guid id)
        {
            return View("DetailsReservation", _reservationRepository.GetReservationById(id));
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            var employees = _employeeRepository.GetAllEmployees();
            var employeeList = employees.Select(x => new SelectListItem(x.FirstName + " " + x.LastName, x.IdEmployee.ToString()));
            ViewBag.EmployeeList = employeeList;
            return View("CreateReservation");
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new ReservationModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _reservationRepository.InsertReservation(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateReservation");
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var employees = _employeeRepository.GetAllEmployees();
            var employeeList = employees.Select(x => new SelectListItem(x.FirstName + " " + x.LastName, x.IdEmployee.ToString()));
            ViewBag.EmployeeList = employeeList;
            return View("EditReservation", _reservationRepository.GetReservationById(id));
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ReservationModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _reservationRepository.UpdateReservation(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View("DeleteReservation", _reservationRepository.GetReservationById(id));
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _reservationRepository.DeleteReservation(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
