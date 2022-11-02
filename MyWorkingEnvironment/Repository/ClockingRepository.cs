using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Models.DBObbjects;

namespace MyWorkingEnvironment.Repository
{
    public class ClockingRepository
    {
        private MyWorkingEnvironmentDBContext _DbContext;

        public ClockingRepository()
        {
            _DbContext = new MyWorkingEnvironmentDBContext();
        }

        public ClockingRepository(MyWorkingEnvironmentDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        private ClockingModel MapDBObjectToModel(Clocking dbobject)
        {
            var model = new ClockingModel();
            if (dbobject != null)
            {
                model.IdClocking = dbobject.IdClocking;
                model.IdEmployee = dbobject.IdEmployee;
                model.Type = dbobject.Type;
                model.CheckIn = dbobject.CheckIn;
                model.CheckOut = dbobject.CheckOut;
            }

            return model;
        }

        private Clocking MapModelToDBObject(ClockingModel model)
        {
            var dbobject = new Clocking();
            if (model != null)
            {
                dbobject.IdClocking = model.IdClocking;
                dbobject.IdEmployee = model.IdEmployee;
                dbobject.Type = model.Type;
                dbobject.CheckIn = model.CheckIn;
                dbobject.CheckOut = model.CheckOut;
            }

            return dbobject;
        }
    }
}
