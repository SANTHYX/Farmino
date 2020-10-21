namespace Farmino.Data.Extensions
{
    public static class EmailValidation
    {
        public static bool IsEmail(this string value)
            => value.Contains('@') ? true : false;   
    }
}
