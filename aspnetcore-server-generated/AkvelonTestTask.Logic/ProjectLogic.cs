using AkvelonTestTask.Common;
using AkvelonTestTask.DataAccess;

namespace AkvelonTestTask.Logic
{
    public class ProjectLogic : IProjectLogic
    {
        private const int DefaultProjectPriority = 0;
        private const int DefaultTaskPriority = 0;
        private IProjectDao _dao;

        public ProjectLogic(IProjectDao dao)
        {
            if (dao is null)
            {
                throw new ArgumentNullException();
            }

            _dao = dao;
        }

        public bool AddProject(Project project)
        {
            if (project is null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(project.Name))
            {
                throw new ArgumentException("The project must have a name.");
            }

            if (project.Id.HasValue)
            {
                project.Id = null;
            }

            if (!project.Status.HasValue)
            {
                project.Status = ProjectStatus.NotStarted;
            }

            if (!project.Priority.HasValue)
            {
                project.Priority = DefaultProjectPriority;
            }

            bool success = _dao.AddProject(project);

            if (!success)
            {
                throw new Exception("Failed to add the project to the database.");
            }

            return success;
        }

        public bool AddTask(Common.Task task)
        {
            if (task is null)
            {
                throw new ArgumentNullException();
            }

            if (string.IsNullOrEmpty(task.Name))
            {
                throw new ArgumentException("The task must have a name.");
            }

            if (task.Id.HasValue)
            {
                task.Id = null;
            }

            if (!task.Status.HasValue)
            {
                task.Status = Common.TaskStatus.ToDo;
            }

            if (!task.Priority.HasValue)
            {
                task.Priority = DefaultTaskPriority;
            }

            if (_dao.GetProject(task.ProjectId) is null)
            {
                throw new KeyNotFoundException($"Project ID {task.ProjectId} not found.");
            }

            bool success = _dao.AddTask(task);

            if (!success)
            {
                throw new Exception("Failed to add the task to the database.");
            }

            return success;
        }

        public bool DeleteProject(int projectId)
        {
            try
            {
                int[] taskIds = _dao.GetTasks(projectId).Select(task => task.Id.Value).ToArray();
                _dao.DeleteTasks(taskIds);
                return _dao.DeleteProject(projectId);
            }
            catch (KeyNotFoundException)
            { 
                return false; 
            }
        }

        public bool DeleteTask(int taskId)
        {
            return _dao.DeleteTask(taskId);
        }

        public List<Project> GetProjects()
        {
            return _dao.GetProjects();
        }

        public List<Common.Task> GetTasks(int projectId)
        {
            return _dao.GetTasks(projectId);
        }

        public bool UpdateProject(Project newProjectData)
        {
            if (newProjectData is null)
            {
                throw new ArgumentNullException();
            }

            if (!newProjectData.Id.HasValue)
            {
                throw new ArgumentException("No ID supplied for project update.");
            }

            return _dao.UpdateProject(newProjectData);
        }

        public bool UpdateTask(Common.Task newTaskData)
        {
            if (newTaskData is null)
            {
                throw new ArgumentNullException();
            }

            if (!newTaskData.Id.HasValue)
            {
                throw new ArgumentException("No ID supplied for task update.");
            }

            if (_dao.GetProject(newTaskData.ProjectId) is null)
            {
                throw new KeyNotFoundException($"Project ID {newTaskData.ProjectId} not found.");
            }

            return _dao.UpdateTask(newTaskData);
        }
    }
}