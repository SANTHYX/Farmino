using System.Text.Json.Serialization;

namespace Farmino.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Regions
    {
        dolnoslaskie,
        kujawskopomorskie,
        lubelskie,
        lubuskie,
        lodzkie,
        malopolskie,
        mazowieckie,
        opolskie,
        podkarpackie,
        podlaskie,
        pomorskie,
        slaskie,
        swietokrzyskie,
        warminskomazurskie,
        wielkopolskie,
        zachodniopomorskie
    }
}
