namespace TaskFlow.Api.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public UserRole Role { get; set; }
   }
}
