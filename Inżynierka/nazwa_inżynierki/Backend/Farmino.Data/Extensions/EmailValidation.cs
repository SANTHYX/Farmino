using System;
using System.Collections.Generic;
using System.Text;

namespace Farmino.Data.Extensions
{
    public static class EmailValidation
    {
        public static bool IsEmail(this string value)
            => value.Contains("@");
        
    }
}
