using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreFront.Models
{
    public class LoginViewModel : CustomerBaseViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}