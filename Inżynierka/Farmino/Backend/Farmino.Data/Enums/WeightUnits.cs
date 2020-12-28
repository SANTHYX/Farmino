using System.Text.Json.Serialization;

namespace Farmino.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WeightUnits
    {
        mg,
        dkg,
        g,
        kg,
        T,
    }
}
