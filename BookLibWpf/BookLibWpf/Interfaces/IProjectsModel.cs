using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibWpf.Interfaces
{
    interface IProjectsModel
    {
        void UpdateProject(Project project);
        IEnumerable<Project> GetProjects();
        Project GetProject(int Id);
        event EventHandler<ProjectEventArgs> ProjectUpdated;
    }
}
