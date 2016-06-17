using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace StoreFront.Admin
{
    public partial class CustomerAdmin : System.Web.UI.Page
    {
        public string CurrentUser { get; set; } = "Alan";

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}