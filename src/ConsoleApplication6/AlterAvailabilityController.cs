using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDJScheduler
{
    class AlterAvailabilityController
    {
        private DBConnector dbc;
        private MainController mcp;
        private AlterAvailabilityForm aaForm;
        private MasterForm mf;

        public AlterAvailabilityController(DBConnector dbc, MainController mcp, MasterForm mf)
        {
            Console.WriteLine("AlterAvailabilityController created.");
            this.mf = mf;
            this.dbc = dbc;
            this.mcp = mcp;
            
        }//end AlterAvailabilityController constructor

        public void Start(User user)
        {
            Console.WriteLine("AlterAvailabilityController.Start() called with param:  {0}", user);
            
            aaForm = new AlterAvailabilityForm(this, mf, user);
            aaForm.PopulateData(dbc.GetAvailability(user));
        }

        public void Submit()
        {
            Console.WriteLine("AlterAvailabilityController.Submit() called.");
            
            Save(aaForm.GetAvailability());
            aaForm.DisplayMessage("Your schedule is saved.");
        }
        public void Back()
        {
            Console.WriteLine("AlterAvailabilityController.Back() called.");
            
            aaForm.Destroy();
            mcp.DisplayMainMenu();
        }

        public void Save(string[] avail)
        {
            Console.WriteLine("AlterAvailabilityController.Save() called with param:  {0}", avail);
            
            dbc.StoreAvailability(avail);
        }
    }//end AlterAvailabilityController class
}//end CDJScheduler namespace