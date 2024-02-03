namespace Kenku.Services.Interfaces
{
    public interface ISerializerService
    {
        string Serialize<T>(T value);

        T? Deserialize<T>(string value);
    }
}