using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPI.Models
{

    //"Data Source=DESKTOP-G2ONDJ4\SQLEXPRESS;Initial Catalog=UserDB1;Integrated Security=True" providerName="System.Data.SqlClient"
    public class AccountModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string LoggedOn { get; set; }
    }
}