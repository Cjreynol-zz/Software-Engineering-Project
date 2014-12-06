using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CDJScheduler
{
    class MainMenuForm : Panel
    {
        private MasterForm mf;
        private MainController mcp;
        private User cUser;
        private Label titleLabel;
        private Label hiUser;
        private Button aaButton, dsButton, gsButton, loButton;

		/// <summary>
		/// Creates the MMForm as a panel, with all of its widgets, and adds itself to the MasterForm
		/// </summary>
        public MainMenuForm(User cUser, MainController mcp, MasterForm mf)
        {
            Console.WriteLine("MainMenuForm created by user {0}.", cUser.Username);
            
            // form properties
            this.mf = mf;
            this.mcp = mcp;
            this.cUser = cUser;
            mf.Text = "CDJ Scheduler";
            this.Size = new Size(375, 300);
            mf.Size = new Size(375, 300);

            //title label
            titleLabel = new Label();
            titleLabel.Size = new Size(165, 30);
            titleLabel.Location = new Point(5, 5);
            titleLabel.Text = "Main Menu";
            titleLabel.Font = new Font("Areil", 16);
            titleLabel.ForeColor = System.Drawing.Color.Orange;
            this.Controls.Add(titleLabel);

            // all users - AlterAvailability, DisplaySchedule, LogOut Buttons
            aaButton = new Button();
            aaButton.Size = new Size(155, 30);
            aaButton.Location = new Point(30, 55);
            aaButton.Text = "Alter Availability";
            aaButton.Click += new EventHandler(aaButtonHandler);
            aaButton.BackColor = System.Drawing.Color.Orange;
            aaButton.ForeColor = System.Drawing.Color.White;
            aaButton.FlatStyle = FlatStyle.Flat;
            aaButton.Font = new Font("Arial", 11, FontStyle.Bold);
            aaButton.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(aaButton);

            dsButton = new Button();
            dsButton.Size = new Size(155, 30);
            dsButton.Location = new Point(195, 55);
            dsButton.Text = "Display Schedule";
            dsButton.Click += new EventHandler(dsButtonHandler);
            dsButton.BackColor = System.Drawing.Color.Orange;
            dsButton.ForeColor = System.Drawing.Color.White;
            dsButton.FlatStyle = FlatStyle.Flat;
            dsButton.Font = new Font("Arial", 11, FontStyle.Bold);
            dsButton.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(dsButton);

            loButton = new Button();
            loButton.Size = new Size(155, 30);
            loButton.Location = new Point(110, 95);
            loButton.Text = "Log Out";
            loButton.Click += new EventHandler(loButtonHandler);
            loButton.BackColor = System.Drawing.Color.Orange;
            loButton.ForeColor = System.Drawing.Color.White;
            loButton.FlatStyle = FlatStyle.Flat;
            loButton.Font = new Font("Arial", 11, FontStyle.Bold);
            loButton.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(loButton);

            // schedule manager users only - GenerateSchedule Button and adjust LogOut Button position
            if (this.cUser.IsScheduleManager)
            {
                Console.WriteLine("MainMenu User is a ScheduleManager.");

                gsButton = new Button();
                gsButton.Size = new Size(155, 30);
                gsButton.Location = new Point(30, 105);
                gsButton.Text = "Generate Schedule";
                gsButton.Click += new EventHandler(gsButtonHandler);
                gsButton.BackColor = System.Drawing.Color.Orange;
                gsButton.ForeColor = System.Drawing.Color.White;
                gsButton.FlatStyle = FlatStyle.Flat;
                gsButton.Font = new Font("Arial", 11, FontStyle.Bold);
                gsButton.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(gsButton);             
                loButton.Location = new Point(195, 105);
            }

			// add panel to MasterForm
            mf.Controls.Add(this);
            
        }//end MainMenuForm constructor

        // -----form methods--------------------------
        
        public void StartLogOut()
        {
            Console.WriteLine("MainMenuForm.StartLogOut() called.");
            
            mcp.StartLogOut();        
        }

        public void StartSelectEmployee()
        {
            Console.WriteLine("MainMenuForm.StartSelectEmployee() called.");
            
            mcp.StartSelectEmployee();    
        }

        public void StartAlterAvailability()
        {
            Console.WriteLine("MainMenuForm.StartAlterAvailability() called.");
            
            mcp.StartAlterAvailability();          
        }

        public void StartGenerateSchedule()
        {
            Console.WriteLine("MainMenuForm.StartGenerateSchedule() called.");
            
            mcp.StartGenerateSchedule();   
        }

        public void StartDisplaySchedule()
        {
            Console.WriteLine("MainMenuForm.StartDisplaySchedule() called.");
            
            mcp.StartDisplaySchedule();          
        }

        public void Destroy()
        {
            Console.WriteLine("MainMenuForm destroyed.");
            
            mf.Controls.Remove(this);   
        }

        // -----button event handlers-----------------------
        
        private void aaButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("MainMenuForm AlterAvailabilityButton pressed.");
            
            if (cUser.IsScheduleManager)
                StartSelectEmployee();
            else
                StartAlterAvailability();       
        }

        private void dsButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("MainMenuForm DisplayScheduleButton pressed.");
            
            StartDisplaySchedule();      
        }

        private void loButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("MainMenuForm LogOutButton pressed.");
            
            StartLogOut();   
        }

        private void gsButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("MainMenuForm GenerateScheduleButton pressed.");
            
            StartGenerateSchedule();   
        }
    }//end MainMenuForm class
}//end CDJScheduler namespace