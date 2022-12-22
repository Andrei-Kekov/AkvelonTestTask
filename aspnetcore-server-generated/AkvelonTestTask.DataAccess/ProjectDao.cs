using AkvelonTestTask.Common;
using System.Collections.Generic;
using System.Linq;

namespace AkvelonTestTask.DataAccess
{
    public class ProjectDao
    {
        public void AddProject(Project project)
        {
            using (var context = new ProjectContext())
            {
                context.Projects.Add(project);
            }
        }
    }
}
