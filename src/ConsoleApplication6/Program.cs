using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CDJScheduler
{
    class Program
    {
    	/// <summary>
		/// Starts the application, creating the MasterForm
		/// </summary>
        static void Main(string[] args)
        {
            // for debugging, uncomment these lines to clear the data store and start fresh
            //DBConnector dbClear = new DBConnector();
            //dbClear.DBClear();
            
            Console.WriteLine("CDJ Scheduler started.");
            
            Application.Run(new MasterForm()); 
            
        }
    }//end Program class

    class MasterForm : Form
    {
    	/// <summary>
		/// Creates the MasterForm for holding all of the other functionalities panels
		/// <para/> Also creates the LoginCtlr and DBConnector
		/// </summary>
        public MasterForm()
        {
            Console.WriteLine("MasterForm created.");
            
            this.Text = "CDJ Scheduler";
            this.Size = new Size(375, 300);
            
            new LoginController(new DBConnector(), this);
            
        }//end MasterForm constructor
    }//end MasterForm class
}//end CDJScheduler namespace