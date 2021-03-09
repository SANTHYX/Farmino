using System.Text.Json.Serialization;

namespace Farmino.Data.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Regions
    {
        Dolnośląskie,
        KujawskoPomorskie,
        Lubelskie,
        Lubuskie,
        Łódzkie, 
        Małopolskie,
        Mazowieckie,
        Opolskie,
        Podkarpackie,
        Podlaskie,
        Pomorskie,
        Śląskie, 
        Świętokrzyskie,
        WarmińskoMazurskie,
        Wielkopolskie,
        ZachodnioPomorskie
    } 
}
