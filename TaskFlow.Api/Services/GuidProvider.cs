namespace TaskFlow.Api.Services
{
    
    public interface IGuidProvider
    {
        public Guid Id { get; }
    }
    public class GuidProvider : IGuidProvider
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
