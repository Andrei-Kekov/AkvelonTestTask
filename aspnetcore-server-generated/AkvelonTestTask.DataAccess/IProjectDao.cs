using AkvelonTestTask.Common;

namespace AkvelonTestTask.DataAccess
{
    public interface IProjectDao
    {
        public bool AddProject(Project project);

        public Project? GetProject(int projectId);

        public List<Project> GetProjects();

        public bool UpdateProject(Project newProjectData);

        public bool DeleteProject(int projectId);

        public bool AddTask(Common.Task task);

        public List<Common.Task> GetTasks(int projectId);

        public bool UpdateTask(Common.Task newTaskData);

        public bool DeleteTask(int taskId);

        public int DeleteTasks(int[] taskIds);
    }
}
