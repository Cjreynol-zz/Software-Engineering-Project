using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDJScheduler
{
    class MainController
    {
        private MasterForm mf;
        private MainMenuForm mmform;
        private DBConnector dbc;

        private SelectEmployeeController sectlr;
        private AlterAvailabilityController aactlr;
        private GenerateScheduleController gsctlr;
        private DisplayScheduleController dsctlr;

        private User curUser;
   
		/// <summary>
		/// Creates the MainCtlr, which handles the MainMenu functionality and form
		/// </summary>
        public MainController(DBConnector dbc, User user, MasterForm mf)
        {
            Console.WriteLine("MainController created.");
            
            this.mf = mf;
            this.dbc = dbc;

            curUser = user;

            sectlr = new SelectEmployeeController(dbc, this, mf);
            aactlr = new AlterAvailabilityController(dbc, this, mf);
            gsctlr = new GenerateScheduleController(dbc, this, mf);
            dsctlr = new DisplayScheduleController(dbc, this, mf);

            mmform = new MainMenuForm(curUser, this, mf);
            
        }//end MainController constructor

        public void DisplayMainMenu()
        {
            Console.WriteLine("MainController.DisplayMainMenu() called.");
            
            mmform = new MainMenuForm(curUser, this, mf);
        }

        public void StartLogOut()
        {
            Console.WriteLine("MainController.StartLogOut() called.");
            
            mmform.Destroy();
            new LoginController(dbc, mf);
        }

        public void StartAlterAvailability()
        {
            Console.WriteLine("MainController.StartAlterAvailability() called.");
            
            mmform.Destroy();
            aactlr.Start(curUser);
        }

        public void StartAlterAvailability(User user)
        {
            Console.WriteLine("MainController.StartAlterAvailability() called with param:  {0}", user);
            
            mmform.Destroy();
            aactlr.Start(user);
        }

        public void StartGenerateSchedule()
        {
            Console.WriteLine("MainController.StartGenerateSchedule() called.");
            
            mmform.Destroy();
            gsctlr.Start();
        }

        public void StartSelectEmployee()
        {
            Console.WriteLine("MainController.StartSelectEmployee() called.");
            
            mmform.Destroy();
            sectlr.Start();
        }

        public void StartDisplaySchedule()
        {
            Console.WriteLine("MainController.StartDisplaySchedule() called.");
            
            mmform.Destroy();
            dsctlr.Start();
        }
    }//end MainController class
}//end CDJScheduler namespace
