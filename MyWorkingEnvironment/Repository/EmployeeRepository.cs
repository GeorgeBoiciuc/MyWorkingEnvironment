using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Models.DBObjects;

namespace MyWorkingEnvironment.Repository
{
    public class EmployeeRepository
    {
        private ApplicationDbContext _DbContext;
        private TaskEmployeeRepository _taskEmployeeRepository;
        private ReservationRepository _reservationReposotiry;

        public EmployeeRepository()
        {
            _taskEmployeeRepository = new TaskEmployeeRepository();
            _reservationReposotiry = new ReservationRepository();
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
            _DbContext.Employees.Add(MapModelToDBObject(employeeModel));
            _DbContext.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            var dbObject = _DbContext.Employees.FirstOrDefault(x => x.IdEmployee == model.IdEmployee);
            if (dbObject != null)
            {
                dbObject.IdEmployee = model.IdEmployee;
                dbObject.IdTask = model.IdTask;
                dbObject.IdReservation = model.IdReservation;
                dbObject.FirstName = model.FirstName;
                dbObject.LastName = model.LastName;
                dbObject.StartDate = model.StartDate;
                dbObject.VacationDays = model.VacationDays;
                _DbContext.SaveChanges();
            }
        }

        public void DeleteEmployee(Guid id)
        {
            var dbObject = _DbContext.Employees.FirstOrDefault(x => x.IdEmployee == id);
            if (dbObject != null)
            {
                //var tasks = _DbContext.TaskEmployees.Where(x => x.IdTask == dbObject.IdTask);
                _taskEmployeeRepository.DeleteTaskEmployee((Guid)dbObject.IdTask);
                _reservationReposotiry.DeleteReservation((Guid)dbObject.IdReservation);

                //var reservations = _reservationReposotiry.GetReservationById((Guid)dbObject.IdReservation);
                //var reservations = _DbContext.Reservations.Where(x => x.IdReservation == dbObject.IdReservation);
                //foreach (var reservation in reservations)
                //{
                //    _DbContext.Reservations.Remove(reservation);
                //}


                _DbContext.Employees.Remove(dbObject);
                _DbContext.SaveChanges();
            }
        }
    }
}
