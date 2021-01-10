namespace Farmino.Data.Extensions
{
    public static class HouseNumberValidation
    {
        public static bool IsHouseNumber(this string value)
            => value[0].ToString() == "-" || value == "0";
    }
}
