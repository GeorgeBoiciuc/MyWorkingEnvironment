using MyWorkingEnvironment.Models.DBObbjects;
using MyWorkingEnvironment.Models;
using Task = MyWorkingEnvironment.Models.DBObbjects.Task;

namespace MyWorkingEnvironment.Repository
{
    public class TaskRepository
    {
        private MyWorkingEnvironmentDBContext _DbContext;

        public TaskRepository()
        {
            _DbContext = new MyWorkingEnvironmentDBContext();
        }

        public TaskRepository(MyWorkingEnvironmentDBContext dbContext)
        {
            _DbContext = dbContext;
        }

        private TaskModel MapDBObjectToModel(Task dbobject)
        {
            var model = new TaskModel();
            if (dbobject != null)
            {
                model.IdTask = dbobject.IdTask;
                model.Title = dbobject.Title;
                model.Priority = dbobject.Priority;
                model.Description = dbobject.Description;
            }
            return model;
        }

        private Task MapModelToDBObject(TaskModel model)
        {
            var dbobject = new Task();
            if (model != null)
            {
                dbobject.IdTask = model.IdTask;
                dbobject.Title = model.Title;
                dbobject.Priority = model.Priority;
                dbobject.Description = model.Description;
            }
            return dbobject;
        }
    }
}
