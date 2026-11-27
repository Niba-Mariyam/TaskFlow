using TaskFlow.Api.DTOs;

namespace TaskFlow.Api.Services
{
    public interface IProjectService
    {
         IEnumerable<ProjectDto> GetAllProjects();
         ProjectDto? GetProjectById(int id);
         ProjectDto CreateProject(CreateProjectDto dto);
         bool UpdateProject(int id,UpdateProjectDto dto);
         bool DeleteProject(int id);
    }
}
