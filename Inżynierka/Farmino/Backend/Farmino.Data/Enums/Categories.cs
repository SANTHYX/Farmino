using System.Text.Json.Serialization;

namespace Farmino.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Categories
    {
        Warzywa,
        Owoce, 
        Przetwory, 
        Wedliny,
        Nabial, 
        Pieczywo,
    }
}
