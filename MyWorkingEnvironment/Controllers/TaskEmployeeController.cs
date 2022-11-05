using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Repository;

namespace MyWorkingEnvironment.Controllers
{
    public class TaskEmployeeController : Controller
    {
        private TaskEmployeeRepository _taskEmployeeRepository;

        public TaskEmployeeController(ApplicationDbContext dbContext)
        {
            _taskEmployeeRepository = new TaskEmployeeRepository(dbContext);
        }

        // GET: TaskEmployeeController
        public ActionResult Index()
        {
            var list = _taskEmployeeRepository.GetAllTaskEmployees();
            return View(list);
        }

        // GET: TaskEmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TaskEmployeeController/Create
        public ActionResult Create()
        {
            return View("CreateTaskEmployee");
        }

        // POST: TaskEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new TaskEmployeeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _taskEmployeeRepository.InsertTaskEmployee(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateTaskEmployee");
            }
        }

        // GET: TaskEmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TaskEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: TaskEmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
