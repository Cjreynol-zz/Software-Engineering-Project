using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class DisplayScheduleController
    {
        private DBConnector dbConn;
        private DisplayScheduleForm dsForm;
        private MainController mCtlr;
        public void Start()
        {
            dsForm = new DisplayScheduleForm(this);
            GetSchedule();
        }
        public void Back()
        {
            dsForm.Destory();
            mCtlr.DisplayMainMenu();
        }

        private void GetSchedule()
        {
            string schedule = dbConn.getSchedule();
            if (schedule != null)
                dsForm.DisplaySchedule(schedule);
            else
                dsForm.DisplayError(); //Make change in Sequence Diagram
        }
        public DisplayScheduleController(DBConnector dbc, MainController mcp)
        {
            dbConn = dbc;
            mCtlr = mcp;
        }
    }
}
