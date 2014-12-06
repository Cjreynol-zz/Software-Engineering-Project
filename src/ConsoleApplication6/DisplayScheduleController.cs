using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDJScheduler
{
    class DisplayScheduleController
    {
        private DBConnector dbConn;
        private DisplayScheduleForm dsForm;
        private MainController mCtlr;
        private MasterForm mf;

        public DisplayScheduleController(DBConnector dbc, MainController mcp, MasterForm mf)
        {
            Console.WriteLine("DisplayScheduleController created.");
            
            this.mf = mf;
            dbConn = dbc;
            mCtlr = mcp;
            
        }//end DisplayScheduleController constructor

        public void Start()
        {
            Console.WriteLine("DisplayScheduleController.Start() called.");
            
            dsForm = new DisplayScheduleForm(this, mf);
            GetSchedule();
        }
        public void Back()
        {
            Console.WriteLine("DisplayScheduleController.Back() called.");
            
            dsForm.Destroy();
            mCtlr.DisplayMainMenu();
        }

        private void GetSchedule()
        {
            Console.WriteLine("DisplayScheduleController.GetSchedule() called.");
            
            List<string>[] schedule = dbConn.GetSchedule();
            if (schedule[0] != null)
                dsForm.DisplaySchedule(schedule);
            else
                dsForm.DisplayError("Error occured, schedule could not be retrieved."); //Make change in Sequence Diagram
        }
        
    }//end DisplayScheduleController class
}//end CDJScheduler namespace