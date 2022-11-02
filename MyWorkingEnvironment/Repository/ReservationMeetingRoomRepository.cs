using MyWorkingEnvironment.Models.DBObbjects;
using MyWorkingEnvironment.Models;

namespace MyWorkingEnvironment.Repository
{
    public class ReservationMeetingRoomRepository
    {
        private MyWorkingEnvironmentDBContext _DbContext;

        public ReservationMeetingRoomRepository()
        {
            _DbContext = new MyWorkingEnvironmentDBContext();
        }

        public ReservationMeetingRoomRepository(MyWorkingEnvironmentDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        private ReservationMeetingRoomModel MapDBObjectToModel(ReservationMeetingRoom dbobject)
        {
            var model = new ReservationMeetingRoomModel();
            if (dbobject != null)
            {
                model.IdReservation = dbobject.IdReservation;
                model.IdMeetingRoom = dbobject.IdMeetingRoom;
            }
            return model;
        }

        private ReservationMeetingRoom MapModelToDBObject(ReservationMeetingRoomModel model)
        {
            var dbobject = new ReservationMeetingRoom();
            if (model != null)
            {
                dbobject.IdReservation = model.IdReservation;
                dbobject.IdMeetingRoom = model.IdMeetingRoom;
            }
            return dbobject;
        }
    }
}
