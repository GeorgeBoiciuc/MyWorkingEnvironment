using MyWorkingEnvironment.Data;
using MyWorkingEnvironment.Models.DBObjects;
using MyWorkingEnvironment.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWorkingEnvironment.Repository
{
    public class ReservationRepository
    {
        private ApplicationDbContext _dbContext;

        public ReservationRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ReservationModel MapDBObjectToModel(Reservation dbobject)
        {
            var model = new ReservationModel();
            if (dbobject != null)
            {
                model.IdReservation = dbobject.IdReservation;
                model.CheckIn = dbobject.CheckIn;
                model.CheckOut = dbobject.CheckOut;
            }
            return model;
        }

        private Reservation MapModelToDBObject(ReservationModel model)
        {
            var dbobject = new Reservation();
            if (model != null)
            {
                dbobject.IdReservation = model.IdReservation;
                dbobject.CheckIn = model.CheckIn;
                dbobject.CheckOut = model.CheckOut;
            }
            return dbobject;
        }

        public List<ReservationModel> GetAllReservations()
        {
            var list = new List<ReservationModel>();
            foreach (var dbObject in _dbContext.Reservations)
            {
                list.Add(MapDBObjectToModel(dbObject));
            }
            return list;
        }

        public ReservationModel GetReservationById(Guid id)
        {
            return MapDBObjectToModel(_dbContext.Reservations.FirstOrDefault(x => x.IdReservation == id));
        }

        public void InsertReservation(ReservationModel model)
        {
            model.IdReservation = Guid.NewGuid();
            _dbContext.Reservations.Add(MapModelToDBObject(model));
            _dbContext.SaveChanges();
        }

        public void UpdateReservation(ReservationModel model)
        {
            var dbObject = _dbContext.Reservations.FirstOrDefault(x => x.IdReservation == model.IdReservation);
            if (dbObject != null)
            {
                dbObject.IdReservation = model.IdReservation;
                dbObject.CheckIn = model.CheckIn;
                dbObject.CheckOut = model.CheckOut;
                _dbContext.SaveChanges();
            }
        }

        public void DeleteReservation(Guid id)
        {
            var dbObject = _dbContext.Reservations.FirstOrDefault(x => x.IdReservation == id);
            if (dbObject != null)
            {
                _dbContext.Reservations.Remove(dbObject);
                _dbContext.SaveChanges();
            }
        }
    }
}
