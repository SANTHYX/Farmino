using System;
using System.Collections.Generic;
using System.Text;

namespace Farmino.Data.Models
{
    public class Account
    {
        public string Login { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }

    }
}
