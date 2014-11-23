using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class LoginController
    {
        private DBConnector dbconn;
        private LoginForm loginForm;

        public LoginController(DBConnector dbc)
        {
            this.dbc = dbc;
            loginForm = new LoginForm(this);
        }

        public void Submit(string uname, string pword)
        {
            if (VerifyUser(pword, dbc.GetUser(uname).Password))
            {
                loginForm.Destroy();
                new MainController(dbconn, uname);
            }
            else
                loginForm.DisplayMessage(errorMessage);
        }
    }
}
