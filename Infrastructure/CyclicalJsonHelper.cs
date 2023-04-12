using System.Text.Json.Serialization;
using System.Text.Json;

namespace Group1_5_FagelGamous.Infrastructure
{
    public class CyclicalJsonHelper
    {
        public static dynamic DeCyclifyYoCode(dynamic stuff)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles // Disable reference handling
            };

            var json = JsonSerializer.Serialize(stuff, options);
            return json;
        }
    }
}
