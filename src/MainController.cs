using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class MainController
    {
        private User curUser;

        private DBConnector dbc;
        private SelectEmployeeController sectlr;
        private AlterAvailabilityController aactlr;

        private GenerateScheduleController gsctlr;
        private DisplayScheduleController dsctlr;

        private MainMenuForm mmform;

        public MainController(DBConnector dbc, string user)
        {
            curUser = dbc.GetUser(user);

            this.dbc = dbc;
            sectlr = new SelectEmployeeController(dbc, this);
            aactlr = new AlterAvailabilityController(dbc, this);
            gsctlr = new GenerateScheduleController(dbc, this);
            dsctlr = new DisplayScheduleController(dbc, this);

            mmform = new MainMenuForm(curUser, this);
        }

        public void DisplayMainMenu()
        {
            mmform = new MainMenuForm(curUser, this);
        }

        public void StartLogout()
        {
            mmform.Destroy();
            // maybe some cleanup to get rid of all the controllers
            new LoginController();
        }

        public void StartAlterAvailability()
        {
            mmform.Destroy();
            aactlr.Start(curUser) ;
        }

        public void StartAlterAvailability(User user)
        {
            mmform.Destroy();
            aactlr.Start(user);
        }

        public void StartGenerateSchedule()
        {
            mmform.Destroy();
            gsctlr.Start();
        }

        public void StartSelectEmployee()
        {
            mmform.Destroy();
            sectlr.Start();
        }

        public void StartDisplaySchedule()
        {
            mmform.Destroy();
            dsctlr.Start();
        }
    }
}
