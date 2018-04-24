using AspNetCoreFroTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFroTest.Web.Bll
{
    public class LoginBiz : ILoginBiz
    {
        private readonly TestContext _db;

        public LoginBiz(TestContext db)
        {
            _db = db;
        }

        public bool Login(string userName,string pw)
        {
            if(!_db.Customers.Any(m=>m.Name == userName && m.PW == pw))
            {
                return false;
            }

            return true;

        }
    }
}
