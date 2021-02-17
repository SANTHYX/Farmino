using System.Text.Json.Serialization;

namespace Farmino.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Oczekujaca,
        Przyjeta,
        Odrzucona,
        Dostarczona
    }
}
