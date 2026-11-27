using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Api.DTOs
{
    public class UpdateProjectDto
    {
        [Required, StringLength(100,MinimumLength =3)]
        public string ProjectName { get; set; } = string.Empty;
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
