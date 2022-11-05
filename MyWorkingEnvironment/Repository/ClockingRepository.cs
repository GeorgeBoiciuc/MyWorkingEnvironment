using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models.DBObjects;
using MyWorkingEnvironment.Models;

namespace MyWorkingEnvironment.Repository
{
    public class ClockingRepository
    {
        private ApplicationDbContext _dbContext;

        public ClockingRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ClockingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public List<ClockingModel> GetAllClockings()
        {
            var list = new List<ClockingModel>();
            foreach (var dbObject in _dbContext.Clockings)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }
            return list;
        }

        public ClockingModel GetClokingById(Guid id)
        {
            return MapDBObjectToModel(_dbContext.Clockings.FirstOrDefault(x => x.IdClocking == id));
        }

        public void InsertClocking(ClockingModel model)
        {
            model.IdClocking = Guid.NewGuid();
            _dbContext.Clockings.Add(MapModelToDBObject(model));
            _dbContext.SaveChanges();
        }

        public void UpdateCloking(ClockingModel model)
        {
            var dbObject = _dbContext.Clockings.FirstOrDefault(x => x.IdClocking == model.IdClocking);
            if (dbObject != null)
            {
                dbObject.IdClocking = model.IdClocking;
                dbObject.IdEmployee = model.IdEmployee;
                dbObject.Type = model.Type;
                dbObject.CheckIn = model.CheckIn;
                dbObject.CheckOut = model.CheckOut;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteClocking(Guid id)
        {
            var dbObject = _dbContext.Clockings.FirstOrDefault(x => x.IdClocking == id);
            if (dbObject != null)
            {
                _dbContext.Clockings.Remove(dbObject);
                _dbContext.SaveChanges();
            }
        }
    }
}
