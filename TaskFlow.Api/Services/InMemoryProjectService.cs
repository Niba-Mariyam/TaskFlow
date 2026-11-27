using TaskFlow.Api.DTOs;
using TaskFlow.Api.Entities;

namespace TaskFlow.Api.Services
{
    public class InMemoryProjectService: IProjectService
    {
        private readonly List<Project> _projects = new ();
        private int _nextId = 1;
        private static ProjectDto ToDto(Project p)=>
            new() { ProjectId=p.ProjectId, ProjectName=p.ProjectName,Description=p.Description ,CreatedAt=p.CreatedAt,ModifiedAt=p.ModifiedAt};

        public ProjectDto CreateProject(CreateProjectDto dto)
        {
            var project = new Project()
            {
                ProjectId = _nextId++,
                ProjectName = dto.ProjectName,
                Description = dto.Description
            };
            _projects.Add(project);
            return ToDto(project);
        }
        public bool DeleteProject(int id)
        {
            var selectedproject=_projects.FirstOrDefault(p => p.ProjectId == id);
            if(selectedproject != null)
            {
                _projects.Remove(selectedproject);
                return true;
            }
            return false;
        }
        public IEnumerable<ProjectDto> GetAllProjects()=> _projects.Select(ToDto).ToList();
        public ProjectDto? GetProjectById(int id) => _projects.Where(i => i.ProjectId == id).Select(ToDto).FirstOrDefault();
        public bool UpdateProject(int id, UpdateProjectDto dto)
        {
            var selectedproject = _projects.FirstOrDefault(p => p.ProjectId == id);
            if (selectedproject != null)
            {
                selectedproject.ProjectName = dto.ProjectName;
                selectedproject.Description = dto.Description;
                selectedproject.ModifiedAt = DateTime.UtcNow;
                return true;

            }
            return false;
        }
    }
}
