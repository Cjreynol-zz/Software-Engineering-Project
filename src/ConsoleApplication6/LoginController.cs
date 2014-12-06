using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDJScheduler
{
    class LoginController
    {
        private DBConnector dbconn;
        private LoginForm loginForm;
        private MasterForm mf;

        public LoginController(DBConnector dbc, MasterForm mf)
        {
            Console.WriteLine("LoginController created.");
            
            this.mf = mf;
            this.dbconn = dbc;
            loginForm = new LoginForm(this, mf);
        }//end LoginController constructor

        public void Submit(string uname, string pword)
        {
            Console.WriteLine("LoginController.Submit() called with params:  {0}, {1}", uname, pword);
            
            User user = dbconn.GetUser(uname);
            if (user != null && VerifyUser(pword, user.Password))
            {
                loginForm.Destroy();
                new MainController(dbconn, user, mf);
            }
            else
                loginForm.DisplayMessage("The login information was invalid.");
        }

        public bool VerifyUser(string formpass, string dbpass)
        {
            Console.WriteLine("LoginController.VerifyUser() called with params:  {0}, {1}", formpass, dbpass);
            
            if (formpass == dbpass)
                return true;
            else
                return false;
        }
    }//end LoginController class
}//end CDJScheduler namespace