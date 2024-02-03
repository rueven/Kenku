namespace Kenku.Objects.Implementations
{
    public class CollectedException
    {
        public required string Message { get; set; }
        public Exception? Exception { get; set; }
    }
}