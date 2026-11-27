using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.DTOs;
using TaskFlow.Api.Services;

namespace TaskFlow.Api.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService) => _projectService = projectService;

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetAll() => Ok(_projectService.GetAllProjects());
        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetProjectById(int id)
        {
            var project= _projectService.GetProjectById(id);
            return project == null ? NotFound() : Ok(project);
        }
        [HttpPost]
        public ActionResult<ProjectDto> CreateProject(CreateProjectDto project)
        {
            var created = _projectService.CreateProject(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = created.ProjectId }, created);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProject(int id,UpdateProjectDto project)
        {
            bool updated=_projectService.UpdateProject(id,project);
            return updated? NoContent():NotFound();

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProject(int id) 
        {
            bool deleted=_projectService.DeleteProject(id);
            return deleted? NoContent():NotFound();
        }

    }
}
