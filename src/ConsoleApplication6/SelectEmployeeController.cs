using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDJScheduler
{
    class SelectEmployeeController
    {
        private MasterForm mf;
        private DBConnector dbc;
        private MainController mcp;
        private SelectEmployeeForm seform;

		/// <summary>
		/// Creates the SECtlr, which handles the SelectEmployee functionality and form
		/// </summary>
        public SelectEmployeeController(DBConnector dbc, MainController mcp, MasterForm mf)
        {
            Console.WriteLine("SelectEmployeeController created.");
            
            this.dbc = dbc;
            this.mcp = mcp;
            this.mf = mf;
            
        }//end SelectEmployeeController constructor

		/// <summary>
		/// Calls the SECtlr to activate and add SEForm to the MasterForm 
		/// </summary>
        public void Start()
        {
            Console.WriteLine("SelectEmployeeController.Start() called.");
            
            seform = new SelectEmployeeForm(this, mf);
            seform.Populate(dbc.GetEmployees());   
        }

		/// <summary>
		/// Takes the user choice from the form and passes it to AlterAvailability
		/// </summary>
        public void Submit(User user)
        {
            Console.WriteLine("SelectEmployeeController.Start() called with param:  {0}", user);
            
            seform.Destroy();
            mcp.StartAlterAvailability(user);   
        }
    }//end SelectEmployeeController class
}//end CDJScheduler namespace