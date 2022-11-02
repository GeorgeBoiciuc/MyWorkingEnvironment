using MyWorkingEnvironment.Models;
using MyWorkingEnvironment.Models.DBObbjects;

namespace MyWorkingEnvironment.Repository
{
    public class MeetingRoomRepository
    {
        private MyWorkingEnvironmentDBContext _DbContext;

        public MeetingRoomRepository()
        {
            _DbContext = new MyWorkingEnvironmentDBContext();
        }

        public MeetingRoomRepository(MyWorkingEnvironmentDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        private MeetingRoomModel MapDBObjectToModel(MeetingRoom dbobject)
        {
            var model = new MeetingRoomModel();
            if (dbobject != null)
            {
                model.IdMeetingRoom = dbobject.IdMeetingRoom;
                model.Name = dbobject.Name;
            }
            return model;
        }

        private MeetingRoom MapModelToDBObject(MeetingRoomModel model)
        {
            var dbobject = new MeetingRoom();
            if (model != null)
            {
                dbobject.IdMeetingRoom = model.IdMeetingRoom;
                dbobject.Name = model.Name;
            }
            return dbobject;
        }
    }
}
