using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Repository;

namespace MyWorkingEnvironment.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _employeeRepository = new EmployeeRepository(dbContext);
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var list = _employeeRepository.GetAllEmployees();
            return View(list);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _employeeRepository.GetEmployeeById(id);
            return View("DetailsEmployee", model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View("CreateEmployee");
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var model = new EmployeeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _employeeRepository.InsertEmployee(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateEmployee");
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _employeeRepository.GetEmployeeById(id);
            return View("EditEmployee", model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new EmployeeModel();
                var task = TryUpdateModelAsync(model);
                model.IdEmployee = id;
                task.Wait();
                if (task.Result)
                {
                    _employeeRepository.UpdateEmployee(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", id);
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _employeeRepository.GetEmployeeById(id);
            return View("DeleteEmployee", model);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _employeeRepository.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Delete", id);
            }
        }
    }
}
