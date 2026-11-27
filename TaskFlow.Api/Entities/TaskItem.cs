namespace TaskFlow.Api.Entities
{
    public class TaskItem
    {
        public int TaskItemId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public TaskItemStatus Status { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; }
    }
}
