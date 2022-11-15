using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Repository;

namespace MyWorkingEnvironment.Controllers
{
    public class TaskEmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;
        private TaskEmployeeRepository _taskEmployeeRepository;

        public TaskEmployeeController(ApplicationDbContext dbContext)
        {
            _employeeRepository = new EmployeeRepository(dbContext);
            _taskEmployeeRepository = new TaskEmployeeRepository(dbContext);
        }

        // GET: TaskEmployeeController
        public ActionResult Index()
        {
            return View(_taskEmployeeRepository.GetAllTaskEmployees());
        }

        // GET: TaskEmployeeController/Details/5
        public ActionResult Details(Guid id)
        {
            return View("DetailsTaskEmployee", _taskEmployeeRepository.GetTaskEmployeeById(id));
        }

        // GET: TaskEmployeeController/Create
        public ActionResult Create()
        {
            var employees = _employeeRepository.GetAllEmployees();
            var employeeList = employees.Select(x => new SelectListItem(x.FirstName + " " + x.LastName, x.IdEmployee.ToString()));
            ViewBag.EmployeeList = employeeList;
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateTaskEmployee");
            }
        }

        // GET: TaskEmployeeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var employees = _employeeRepository.GetAllEmployees();
            var employeeList = employees.Select(x => new SelectListItem(x.FirstName + " " + x.LastName, x.IdEmployee.ToString()));
            ViewBag.EmployeeList = employeeList;
            return View("EditTaskEmployee", _taskEmployeeRepository.GetTaskEmployeeById(id));
        }

        // POST: TaskEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new TaskEmployeeModel();
                var task = TryUpdateModelAsync(model);
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
            return View("DeleteTaskEmployee", _taskEmployeeRepository.GetTaskEmployeeById(id));
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
