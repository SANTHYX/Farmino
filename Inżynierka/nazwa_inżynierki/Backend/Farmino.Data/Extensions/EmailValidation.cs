namespace Farmino.Data.Extensions
{
    public static class EmailValidation
    {
        public static bool IsEmail(this string value)
        {
            if (value.Contains('@'))
            {
                return true;
            }
            else return false;
        }
        
    }
}
