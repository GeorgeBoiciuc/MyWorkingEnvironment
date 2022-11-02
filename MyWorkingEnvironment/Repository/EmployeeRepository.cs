using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models.DBObbjects;
using MyWorkingEnvironment.Models;

namespace MyWorkingEnvironment.Repository
{
    public class EmployeeRepository
    {
        private MyWorkingEnvironmentDBContext _DbContext;

        public EmployeeRepository()
        {
            _DbContext = new MyWorkingEnvironmentDBContext();
        }

        public EmployeeRepository(MyWorkingEnvironmentDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        private EmployeeModel MapDBObjectToModel(Employee dbobject)
        {
            var model = new EmployeeModel();
            if (dbobject != null)
            {
                model.IdEmployee = dbobject.IdEmployee;
                model.IdTask = dbobject.IdTask;
                model.IdReservation = dbobject.IdReservation;
                model.FirstName = dbobject.FirstName;
                model.LastName = dbobject.LastName;
                model.StartDate = dbobject.StartDate;
                model.VacationDays = dbobject.VacationDays;
            }
            return model;
        }

        private Employee MapModelToDBObject(EmployeeModel model)
        {
            var dbobject = new Employee();
            if (model != null)
            {
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.IdTask = model.IdTask;
                dbobject.IdReservation = model.IdReservation;
                dbobject.FirstName = model.FirstName;
                dbobject.LastName = model.LastName;
                dbobject.StartDate = model.StartDate;
                dbobject.VacationDays = model.VacationDays;
            }
            return dbobject;
        }
    }
}
