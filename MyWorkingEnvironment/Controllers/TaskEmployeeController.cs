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
        public ActionResult Details(Guid id)
        {
            var model = _taskEmployeeRepository.GetTaskEmployeeById(id);
            return View("DetailsTaskEmployee", model);
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
        public ActionResult Edit(Guid id)
        {
            var model = _taskEmployeeRepository.GetTaskEmployeeById(id);
            return View("EditTaskEmployee", model);
        }

        // POST: TaskEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new TaskEmployeeModel();
                var task = TryUpdateModelAsync(model); //modelul nu ia id-ul, iar aceasta ramane null
                model.IdTask = id;
                task.Wait();
                if (task.Result)
                {
                    _taskEmployeeRepository.UpdateTaskEmployee(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: TaskEmployeeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _taskEmployeeRepository.GetTaskEmployeeById(id);
            return View("DeleteTaskEmployee", model);
        }

        // POST: TaskEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _taskEmployeeRepository.DeleteTaskEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
