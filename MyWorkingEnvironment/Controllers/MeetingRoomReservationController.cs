using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Repository;
using MyWorkingEnvironment.ViewModels;

namespace MyWorkingEnvironment.Controllers
{
    public class MeetingRoomReservationController : Controller
    {
        private ReservationRepository _reservationRepository;
        private MeetingRoomRepository _meetingRoomRepository;
        private EmployeeRepository _employeeRepository;
        private MeetingRoomReservationRepository _meetingRoomReservationRepository;

        public MeetingRoomReservationController(ApplicationDbContext dbContext)
        {
            _reservationRepository = new ReservationRepository(dbContext);
            _meetingRoomRepository = new MeetingRoomRepository(dbContext);
            _employeeRepository = new EmployeeRepository(dbContext);
            _meetingRoomReservationRepository = new MeetingRoomReservationRepository(dbContext);
        }

        // GET: MeetingRoomReservationController
        public ActionResult Index()
        {
            var list = _meetingRoomReservationRepository.GetAllMeetingRoomReservations();
            var viewModelList = new List<MeetingRoomReservationViewModel>();
            foreach (var model in list)
            {
                viewModelList.Add(new MeetingRoomReservationViewModel(model, _reservationRepository, _meetingRoomRepository));
            }
            return View(viewModelList);
        }

        // GET: MeetingRoomReservationController/Details/5
        public ActionResult Details(Guid id)
        {
            var viewModel = new MeetingRoomReservationViewModel(_meetingRoomReservationRepository.GetMeetingRoomReservationById(id), 
                                                                _reservationRepository, 
                                                                _meetingRoomRepository);
            return View("DetailsMeetingRoomReservation", viewModel);
        }

        // GET: MeetingRoomReservationController/Create
        public ActionResult Create()
        {
            var employees = _employeeRepository.GetAllEmployees();
            var employeeList = employees.Select(x => new SelectListItem(x.FirstName + " " + x.LastName, x.IdEmployee.ToString()));
            ViewBag.EmployeeList = employeeList;

            var meetingRooms = _meetingRoomRepository.GetAllMeetingRooms();
            var meetingRoomList = meetingRooms.Select(x => new SelectListItem(x.Name, x.IdMeetingRoom.ToString()));
            ViewBag.MeetingRoomList = meetingRoomList;
            return View("CreateMeetingRoomReservation");
        }

        // POST: MeetingRoomReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MeetingRoomReservationModel();
                var viewModel = new MeetingRoomReservationViewModel(model, _reservationRepository, _meetingRoomRepository);
                var task = TryUpdateModelAsync(viewModel);
                task.Wait();
                if (task.Result)
                {
                    var reservationModel = new ReservationModel()
                    {
                        IdReservation = viewModel.IdReservation,
                        IdEmployee = viewModel.IdEmployee,
                        Date = viewModel.Date,
                        End = viewModel.End,
                        Start = viewModel.Start
                    };
                    _reservationRepository.InsertReservation(reservationModel);

                    model.IdReservation = viewModel.IdReservation;
                    model.IdMeetingRoom = viewModel.IdMeetingRoom;
                    _meetingRoomReservationRepository.InsertMeetingRoomReservation(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMeetingRoomReservation");
            }
        }

        // GET: MeetingRoomReservationController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: MeetingRoomReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
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

        // GET: MeetingRoomReservationController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: MeetingRoomReservationController/Delete/5
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
