namespace Farmino.Data.Extensions
{
    public static class NumberValidation
    {
        public static bool IsNumber(this string value)
            => value.Length == 11 ? true : false;
    }
}
