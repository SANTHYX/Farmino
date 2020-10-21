using System;
using System.Collections.Generic;
using System.Text;

namespace Farmino.Data.Exceptions
{
    public class DataExceptions : ApplicationExceptions
    {
        public DataExceptions()
        {
        }

        public DataExceptions(string code) : base(code)
        {

        }

        public DataExceptions(string message, params object[] args)
            : base(string.Empty, message, args)
        {

        }

        public DataExceptions(string code, string message, params object[] args)
            : base(null, string.Empty, message, args)
        {

        }

        public DataExceptions(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args)
        {

        }

        public DataExceptions(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {

        }
    }
