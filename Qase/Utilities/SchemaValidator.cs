using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Qase.Utilities;

public class SchemaValidator
{
    public static bool ValidateResponse(string jsonResponse, string jsonSchema)
    {
        var schema = JSchema.Parse(jsonSchema);
        
        var response = JsonConvert.DeserializeObject<JObject>(jsonResponse);
        
        var isValid = response.IsValid(schema);

        return isValid;
    }
}
