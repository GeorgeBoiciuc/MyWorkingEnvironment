using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Repository;

namespace MyWorkingEnvironment.Controllers
{
    public class MeetingRoomController : Controller
    {
        private MeetingRoomRepository _meetingRoomRepository;

        public MeetingRoomController(ApplicationDbContext dbContext)
        {
            _meetingRoomRepository = new MeetingRoomRepository(dbContext);
        }

        // GET: MeetingRoomController
        public ActionResult Index()
        {
            var list = _meetingRoomRepository.GetAllMeetingRooms();
            return View(list);
        }

        // GET: MeetingRoomController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: MeetingRoomController/Create
        public ActionResult Create()
        {
            return View("CreateMeetingRoom");
        }

        // POST: MeetingRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new MeetingRoomModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _meetingRoomRepository.InsertMeetingRoom(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateMeetingRoom");
            }
        }

        // GET: MeetingRoomController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: MeetingRoomController/Edit/5
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

        // GET: MeetingRoomController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: MeetingRoomController/Delete/5
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
