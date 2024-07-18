namespace TiredEagle.Domain.Abstraction
{
    public class Entity<T>
    {
        public T Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
