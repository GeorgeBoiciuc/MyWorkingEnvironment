using MyWorkingEnvironment.Models.DBObbjects;
using MyWorkingEnvironment.Models;

namespace MyWorkingEnvironment.Repository
{
    public class ReservationRepository
    {
        private MyWorkingEnvironmentDBContext _DbContext;

        public ReservationRepository()
        {
            _DbContext = new MyWorkingEnvironmentDBContext();
        }

        public ReservationRepository(MyWorkingEnvironmentDBContext dbContext)
        {
            _DbContext = dbContext;
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
    }
}
