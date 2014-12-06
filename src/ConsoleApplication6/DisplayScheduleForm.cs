using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CDJScheduler
{
    class DisplayScheduleForm : Panel
    {
        private MasterForm mf;
        private DisplayScheduleController dsctlr;

        private Label titleLabel;
        private Label displayScheduleLabel;
        private Button back;
        private Label errorLabel;

        public DisplayScheduleForm(DisplayScheduleController dsctlr, MasterForm mf)
        {
            Console.WriteLine("DisplayScheduleForm created.");
            // form properties
            this.mf = mf;
            this.dsctlr = dsctlr;
            mf.Text += " - Display Schedule";
            this.Size = new Size(375, 340);
            mf.Size = new Size(375, 340);

            //title label
            titleLabel = new Label();
            titleLabel.Size = new Size(195, 30);
            titleLabel.Location = new Point(5, 5);
            titleLabel.Text = "Display Schedule";
            titleLabel.Font = new Font("Areil", 16);
            titleLabel.ForeColor = System.Drawing.Color.Orange;
            this.Controls.Add(titleLabel);

            // displayScheduleLabel
            displayScheduleLabel = new Label();
            displayScheduleLabel.Size = new Size(290, 260);
            displayScheduleLabel.Location = new Point(50, 10);
            displayScheduleLabel.Font = new Font("Arial", 11);
            this.Controls.Add(displayScheduleLabel);

            // back button
            back = new Button();
            back.Size = new Size(75, 30);
            back.Location = new Point(50, 275);
            back.Text = "Back";
            this.Controls.Add(back);
            back.Click += new EventHandler(backButtonHandler);
            back.BackColor = System.Drawing.Color.Orange;
            back.ForeColor = System.Drawing.Color.White;
            back.FlatStyle = FlatStyle.Flat;
            back.Font = new Font("Arial", 11, FontStyle.Bold);
            back.TextAlign = ContentAlignment.MiddleCenter;

			// add panel to MasterForm
            mf.Controls.Add(this);
            
        }//end DisplayScheduleForm constructor

		/// <summary>
		/// Format the schedule from the data store as an easily readable string to display on the form
		/// </summary>
        public void DisplaySchedule(List<string>[] sched)
        {
            Console.WriteLine("DisplayScheduleForm.DisplaySchedule() called with param:  {0}", sched);
            
            string schedule = "";
            for (int i = 0; i < sched.Length; i++)
            {
                int index = i;
                string weekDay = "";
                switch (index)
                {
                    case 0:
                        weekDay = "Monday";
                        break;
                    case 1:
                        weekDay = "Tuesday";
                        break;
                    case 2:
                        weekDay = "Wednesday";
                        break;
                    case 3:
                        weekDay = "Thursday";
                        break;
                    case 4:
                        weekDay = "Friday";
                        break;
                    case 5:
                        weekDay = "Saturday";
                        break;
                    case 6:
                        weekDay = "Sunday";
                        break;
                    default:
                        Console.WriteLine("Dammit");
                        break;
                }
                schedule += "\n\n" + weekDay + ": ";

                foreach (var j in sched[i])
                {
                    schedule += j + ", ";
                }
                // remove the trailing comma
                schedule = schedule.Substring(0, schedule.Length - 2);
            }

            displayScheduleLabel.Text = schedule;
        }

        // form methods
        public void DisplayError(string msg)
        {
            Console.WriteLine("LoginForm.DisplayMessage() called with param:  {0}", msg);
            
            // error label
            errorLabel = new Label();
            errorLabel.Size = new Size(75, 30);
            errorLabel.Location = new Point(5, 5);
            errorLabel.Text = msg;
            this.Controls.Add(errorLabel);
        }

        public void Destroy()
        {
            Console.WriteLine("DisplayScheduleForm destroyed.");
            
            mf.Controls.Remove(this);
        }

        public void Back()
        {
            Console.WriteLine("DisplayScheduleForm.Back() called.");
            
            dsctlr.Back();
        }

        // button event handlers
        private void backButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("DisplayScheduleForm BackButton pressed.");
            
            Back();
        }
    }//end DisplaySchedulerForm class
}//end CDJScheduler namespace