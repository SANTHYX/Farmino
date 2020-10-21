using System;

namespace Farmino.Service.Exceptions
{
    public class ServiceExceptions : Data.Exceptions.ApplicationExceptions
    {
        public ServiceExceptions()
        {

        }

        public ServiceExceptions(string code) : base(code)
        {

        }

        public ServiceExceptions(string message, params object[] args)
            : base(string.Empty, message, args)
        {

        }

        public ServiceExceptions(string code, string message, params object[] args)
            : base(null, string.Empty, message, args)
        {

        }

        public ServiceExceptions(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args)
        {

        }

        public ServiceExceptions(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {

        }
    }
}
