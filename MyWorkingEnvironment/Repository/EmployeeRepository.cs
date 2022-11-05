using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Models.DBObjects;

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
                model.IdTask = dbObject.IdTask;
                model.IdReservation = dbObject.IdReservation;
                model.FirstName = dbObject.FirstName;
                model.LastName = dbObject.LastName;
                model.StartDate = dbObject.StartDate;
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
                dbObject.IdTask = model.IdTask;
                dbObject.IdReservation = model.IdReservation;
                dbObject.FirstName = model.FirstName;
                dbObject.LastName = model.LastName;
                dbObject.StartDate = model.StartDate;
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
            employeeModel.IdReservation = Guid.NewGuid();
            employeeModel.IdTask = Guid.NewGuid();
            _DbContext.Employees.Add(MapModelToDBObject(employeeModel));
            _DbContext.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            var dbObject = _DbContext.Employees.FirstOrDefault(x => x.IdEmployee == employeeModel.IdEmployee);
            if (dbObject != null)
            {
                dbObject.IdEmployee = employeeModel.IdEmployee;
                dbObject.IdTask = employeeModel.IdTask;
                dbObject.IdReservation = employeeModel.IdReservation;
                dbObject.FirstName = employeeModel.FirstName;
                dbObject.LastName = employeeModel.LastName;
                dbObject.StartDate = employeeModel.StartDate;
                dbObject.VacationDays = employeeModel.VacationDays;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteEmployee(Guid id)
        {
            var dbObject = _DbContext.Employees.FirstOrDefault(x => x.IdEmployee == id);
            if (dbObject != null)
            {
                var tasks = _DbContext.TaskEmployees.Where(x => x.IdTask == dbObject.IdTask);
                foreach (var task in tasks)
                {
                    _DbContext.TaskEmployees.Remove(task);
                }

                var reservations = _DbContext.Reservations.Where(x => x.IdReservation == dbObject.IdReservation);
                foreach (var reservation in reservations)
                {
                    _DbContext.Reservations.Remove(reservation);
                }

                _DbContext.Employees.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
