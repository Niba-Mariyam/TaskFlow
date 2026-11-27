namespace TaskFlow.Api.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public  string? Title { get; set; }
        public string? Description { get; set;  }
        public CommentStatus CommentStatus { get; set; }
        public int TaskItemId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
