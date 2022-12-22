using AkvelonTestTask.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AkvelonTestTask.DataAccess
{
    public class ProjectDao
    {
        public void AddProject(Project project)
        {
            Project result;

            using (var context = new ProjectContext())
            {
                context.Projects.Add(project);
            }
        }
    }
}
