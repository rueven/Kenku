using Kenku.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kenku.Services.Implementations
{
    internal class SerializerService : ISerializerService
    {
        public SerializerService()
        {
            Configuration = new JsonSerializerOptions()
            {
                AllowTrailingCommas = false,
                IgnoreReadOnlyFields = true,
                IgnoreReadOnlyProperties = true,
                IncludeFields = false,
                NumberHandling = JsonNumberHandling.Strict,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };
        }

        private JsonSerializerOptions Configuration { get; }

        public T? Deserialize<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return default;
            }
            var output = JsonSerializer
                .Deserialize<T>(value, Configuration);
            return output;
        }

        public string Serialize<T>(T value)
        {
            var output = JsonSerializer
                .Serialize(value, Configuration);
            return output;
        }
    }
}