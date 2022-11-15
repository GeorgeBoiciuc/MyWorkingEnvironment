using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models.DBObjects;
using MyWorkingEnvironment.Models;

namespace MyWorkingEnvironment.Repository
{
    public class EmployeeRepository
    {
        private ApplicationDbContext _DbContext;

        public EmployeeRepository()
        {
            _DbContext = new ApplicationDbContext();
        }

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        private EmployeeModel MapDBObjectToModel(Employee dbObject)
        {
            var model = new EmployeeModel();
            if (dbObject != null)
            {
                model.IdEmployee = dbObject.IdEmployee;
                model.FirstName = dbObject.FirstName;
                model.LastName = dbObject.LastName;
                model.Title = dbObject.Title;
                model.Email = dbObject.Email;
                model.JoinDate = dbObject.JoinDate;
                model.VacationDays = dbObject.VacationDays;
            }
            return model;
        }

        private Employee MapModelToDBObject(EmployeeModel model)
        {
            var dbObject = new Employee();
            if (model != null)
            {
                dbObject.IdEmployee = model.IdEmployee;
                dbObject.FirstName = model.FirstName;
                dbObject.LastName = model.LastName;
                dbObject.Title = model.Title;
                dbObject.Email = model.Email;
                dbObject.JoinDate = model.JoinDate;
                dbObject.VacationDays = model.VacationDays;
            }
            return dbObject;
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            var list = new List<EmployeeModel>();
            foreach (var dbObject in _DbContext.Employees)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }
            return list;
        }

        public EmployeeModel GetEmployeeById(Guid id)
        {
            return MapDBObjectToModel(_DbContext.Employees.FirstOrDefault(x => x.IdEmployee == id));
        }

        public void InsertEmployee(EmployeeModel employeeModel)
        {
            employeeModel.IdEmployee = Guid.NewGuid();
            _DbContext.Employees.Add(MapModelToDBObject(employeeModel));
            _DbContext.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            var dbObject = _DbContext.Employees.FirstOrDefault(x => x.IdEmployee == model.IdEmployee);
            if (dbObject != null)
            {
                dbObject.IdEmployee = model.IdEmployee;
                dbObject.FirstName = model.FirstName;
                dbObject.LastName = model.LastName;
                dbObject.Title = model.Title;
                dbObject.Email = model.Email;
                dbObject.JoinDate = model.JoinDate;
                dbObject.VacationDays = model.VacationDays;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteEmployee(Guid id)
        {
            var dbObject = _DbContext.Employees.FirstOrDefault(x => x.IdEmployee == id);
            if (dbObject != null)
            {
                _DbContext.Employees.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
