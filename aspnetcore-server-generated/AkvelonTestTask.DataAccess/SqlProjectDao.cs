using AkvelonTestTask.Common;
using System.Collections.Generic;
using System.Linq;

namespace AkvelonTestTask.DataAccess
{
    public class SqlProjectDao : IProjectDao
    {
        public bool AddProject(Project project)
        {
            if (project is null)
            {
                throw new ArgumentNullException();
            }

            using (var db = new ProjectContext())
            {
                db.Projects.Add(project);
                return db.SaveChanges() > 0;
            }
        }

        public bool AddTask(Common.Task task)
        {
            if (task is null)
            {
                throw new ArgumentNullException();
            }

            using (var db = new ProjectContext())
            {
                db.Tasks.Add(task);
                return db.SaveChanges() > 0;
            }
        }

        public bool DeleteProject(int projectId)
        {
            using (var db = new ProjectContext())
            {
                var project = db.Projects.FirstOrDefault(project => project.Id == projectId);

                if (project is null)
                {
                    return false;
                }

                db.Remove(project);
                return db.SaveChanges() > 0;
            }
        }

        public bool DeleteTask(int taskId)
        {
            using (var db = new ProjectContext())
            {
                var task = db.Tasks.FirstOrDefault(task => task.Id == taskId);

                if (task is null)
                {
                    return false;
                }

                db.Remove(task);
                return db.SaveChanges() > 0;
            }
        }

        public int DeleteTasks(int[] taskIds)
        {
            using (var db = new ProjectContext())
            {
                var tasks = db.Tasks.Where(task => task.Id.HasValue && taskIds.Contains(task.Id.Value)).ToArray();

                foreach (var task in tasks)
                {
                    db.Tasks.Remove(task);
                }

                return db.SaveChanges();
            }
        }

        public Project? GetProject(int projectId)
        {
            using (var db = new ProjectContext())
            {
                return db.Projects.FirstOrDefault(project => project.Id == projectId);
            }
        }

        public List<Project> GetProjects()
        {
            using (var db = new ProjectContext())
            {
                return db.Projects.ToList();
            }
        }

        public List<Common.Task> GetTasks(int projectId)
        {
            using (var db = new ProjectContext())
            {
                if (db.Projects.Any(project => project.Id == projectId))
                {
                    return db.Tasks.Where(task => task.ProjectId == projectId).ToList();
                }
                else
                {
                    throw new KeyNotFoundException($"Project ID {projectId} not found.");
                }
            }
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

            using (var db = new ProjectContext())
            {
                var project = db.Projects.FirstOrDefault(project => project.Id == newProjectData.Id);

                if (project is null)
                {
                    throw new KeyNotFoundException($"Project ID {newProjectData.Id} not found.");
                }

                project.Name = newProjectData.Name;
                project.StartDate = newProjectData.StartDate;
                project.CompletionDate = newProjectData.CompletionDate;
                project.Status = newProjectData.Status;
                project.Priority = newProjectData.Priority;
                return db.SaveChanges() > 0;
            }
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

            using (var db = new ProjectContext())
            {
                var task = db.Tasks.FirstOrDefault(task => task.Id == newTaskData.Id);

                if (task is null)
                {
                    throw new KeyNotFoundException($"Task ID {newTaskData.Id} not found.");
                }

                task.Name = newTaskData.Name;
                task.Status = newTaskData.Status;
                task.Description = newTaskData.Description;
                task.Priority = newTaskData.Priority;
                task.ProjectId = newTaskData.ProjectId;
                return db.SaveChanges() > 0;
            }
        }
    }
}
