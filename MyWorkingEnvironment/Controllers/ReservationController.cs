using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Repository;

namespace MyWorkingEnvironment.Controllers
{
    public class ReservationController : Controller
    {
        private ReservationRepository _reservationRepository;

        public ReservationController(ApplicationDbContext dbContext)
        {
            _reservationRepository = new ReservationRepository(dbContext);    
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            var list = _reservationRepository.GetAllReservations();
            return View(list);
        }

        // GET: ReservationController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateReservation");
            }
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _reservationRepository.GetReservationById(id);
            return View("EditReservation", model);
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
                model.IdReservation = id;
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
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
