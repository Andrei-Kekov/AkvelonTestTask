using AkvelonTestTask.Common;

namespace AkvelonTestTask.Logic
{
    public interface IProjectLogic
    {
        public bool AddProject(Project project);

        public List<Project> GetProjects();

        public bool UpdateProject(Project newProjectData);

        public bool DeleteProject(int projectId);

        public bool AddTask(Common.Task task);

        public List<Common.Task> GetTasks(int projectId);

        public bool UpdateTask(Common.Task task);

        public bool DeleteTask(int taskId);
    }
}
