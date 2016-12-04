using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibWpf.Interfaces
{
    interface IProjectsView
    {
        int NONE_SELECTED { get; }
        int SelectedProjectId { get; }
        void UpdateProject(Project project);
        void LoadProjects(IEnumerable<Project> projects);
        void UpdateDetails(Project project);
        void EnableControls(bool isEnabled);
        void SetEstimatedColor(Color? color);
        event EventHandler<ProjectEventArgs> ProjectUpdated;
        event EventHandler<ProjectEventArgs> DetailsUpdated;
        event EventHandler SelectionChanged;
    }
}
