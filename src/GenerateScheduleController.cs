using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class GenerateScheduleController
    {
        private DBConnector dbConn;
        private GenerateScheduleForm gsForm;
        private MainController mCtlr;
        public void Start()
        {
            gsForm = new GenerateScheduleForm(this);
        }
        public void Back()
        {
            gsForm.Destory();
            mCtlr.DisplayMainMenu();
        }
        public void Generate(string genType)
        {
            generateSchedule(genType, dbConn.getAllAvailability());
        }
        private void generateSchedule(string genType, string result)
        {
            switch (genType)
            {
                case "Option1": Algorithm1(result); break;
                case "Option2": Algorithm2(result); break;
                case "Option3": Algorithm3(result); break;
                default: throw new ApplicationException("A Priority Needs to be selected");
            }
        }
        private void Algorithm1(string result)
        {
            string schedule = null;
            //Algorithm goes here
            if (passalgorithm)
            {
                dbConn.StoreSchedule(schedule);
                gsForm.DisplayMessage("successMessage");
            }
            else
                gsForm.DisplayMessage("errorMessage");
        }
        private void Algorithm2(string result)
        {
            string schedule = null;
            //Algorithm goes here
            if (passalgorithm)
            {
                dbConn.StoreSchedule(schedule);
                gsForm.DisplayMessage("successMessage");
            }
            else
                gsForm.DisplayMessage("errorMessage");
        }
        private void Algorithm3(string result)
        {
            string schedule = null;
            //Algorithm goes here
            if (passalgorithm)
            {
                dbConn.StoreSchedule(schedule);
                gsForm.DisplayMessage("successMessage");
            }
            else
                gsForm.DisplayMessage("errorMessage");
        }
        public GenerateScheduleController(DBConnector dbc, MainController mcp)
        {
            dbConn = dbc;
            mCtlr = mcp;
        }
    }
}
