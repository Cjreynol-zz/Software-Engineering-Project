using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CDJScheduler
{
    class  AlterAvailabilityForm : Panel
    {
        private AlterAvailabilityController aactlr;
        private MasterForm mf;
        private User user;

        private Label titleLabel;
        private Label mondayLabel;
        private Label tuesdayLabel;
        private Label wednesdayLabel;
        private Label thursdayLabel;
        private Label fridayLabel;
        private Label saturdayLabel;
        private Label sundayLabel;

        private CheckBox mondayCheckBox;
        private CheckBox tuesdayCheckBox;
        private CheckBox wednesdayCheckBox;
        private CheckBox thursdayCheckBox;
        private CheckBox fridayCheckBox;
        private CheckBox saturdayCheckBox;
        private CheckBox sundayCheckBox;

        private Button save;
        private Button back;
        private Label messageLabel;

        public AlterAvailabilityForm(AlterAvailabilityController aactlr, MasterForm mf, User user)
        {
            Console.WriteLine("AlterAvailabilityForm created.");

            // form properties
            this.mf = mf;
            this.aactlr = aactlr;
            this.user = user;
            mf.Text += " - Alter Availability";
            this.Size = new Size(375, 300);
            mf.Size = new Size(375, 300);

            //title label
            titleLabel = new Label();
            titleLabel.Size = new Size(165, 30);
            titleLabel.Location = new Point(5, 5);
            titleLabel.Text = "Alter Availabilty";
            titleLabel.Font = new Font("Areil", 16);
            titleLabel.ForeColor = System.Drawing.Color.Orange;
            this.Controls.Add(titleLabel);

            //monday label
            mondayLabel = new Label();
            mondayLabel.Size = new Size(85, 20);
            mondayLabel.Location = new Point(90, 40);
            mondayLabel.Text = "Monday";
            mondayLabel.Font = new Font("Arial", 11);
            this.Controls.Add(mondayLabel);

            //tuesday label
            tuesdayLabel = new Label();
            tuesdayLabel.Size = new Size(85, 20);
            tuesdayLabel.Location = new Point(220, 40);
            tuesdayLabel.Text = "Tuesday";
            tuesdayLabel.Font = new Font("Arial", 11);
            this.Controls.Add(tuesdayLabel);

            //wednesday label
            wednesdayLabel = new Label();
            wednesdayLabel.Size = new Size(85, 20);
            wednesdayLabel.Location = new Point(90, 80);
            wednesdayLabel.Text = "Wednesday";
            wednesdayLabel.Font = new Font("Arial", 11);
            this.Controls.Add(wednesdayLabel);

            //thursday label
            thursdayLabel = new Label();
            thursdayLabel.Size = new Size(85, 20);
            thursdayLabel.Location = new Point(220, 80);
            thursdayLabel.Text = "Thursday";
            thursdayLabel.Font = new Font("Arial", 11);
            this.Controls.Add(thursdayLabel);

            //friday label
            fridayLabel = new Label();
            fridayLabel.Size = new Size(85, 20);
            fridayLabel.Location = new Point(90, 120);
            fridayLabel.Text = "Friday";
            fridayLabel.Font = new Font("Arial", 11);
            this.Controls.Add(fridayLabel);

            //saturday label
            saturdayLabel = new Label();
            saturdayLabel.Size = new Size(85, 20);
            saturdayLabel.Location = new Point(220, 120);
            saturdayLabel.Text = "Saturday";
            saturdayLabel.Font = new Font("Arial", 11);
            this.Controls.Add(saturdayLabel);

            //sunday label
            sundayLabel = new Label();
            sundayLabel.Size = new Size(85, 20);
            sundayLabel.Location = new Point(90, 160);
            sundayLabel.Text = "Sunday";
            sundayLabel.Font = new Font("Arial", 11);
            this.Controls.Add(sundayLabel);

            //monday CheckBox
            mondayCheckBox = new CheckBox();
            mondayCheckBox.Size = new Size(20, 20);
            mondayCheckBox.Location = new Point(65, 40);
            this.Controls.Add(mondayCheckBox);

            //tuesday CheckBox
            tuesdayCheckBox = new CheckBox();
            tuesdayCheckBox.Size = new Size(20, 20);
            tuesdayCheckBox.Location = new Point(200, 40);
            this.Controls.Add(tuesdayCheckBox);

            //wednesday CheckBox
            wednesdayCheckBox = new CheckBox();
            wednesdayCheckBox.Size = new Size(20, 20);
            wednesdayCheckBox.Location = new Point(65, 80);
            this.Controls.Add(wednesdayCheckBox);

            //thursday CheckBox
            thursdayCheckBox = new CheckBox();
            thursdayCheckBox.Size = new Size(20, 20);
            thursdayCheckBox.Location = new Point(200, 80);
            this.Controls.Add(thursdayCheckBox);

            //friday CheckBox
            fridayCheckBox = new CheckBox();
            fridayCheckBox.Size = new Size(20, 20);
            fridayCheckBox.Location = new Point(65, 120);
            this.Controls.Add(fridayCheckBox);

            //saturday CheckBox
            saturdayCheckBox = new CheckBox();
            saturdayCheckBox.Size = new Size(20, 20);
            saturdayCheckBox.Location = new Point(200, 120);
            this.Controls.Add(saturdayCheckBox);

            //sunday CheckBox
            sundayCheckBox = new CheckBox();
            sundayCheckBox.Size = new Size(20, 20);
            sundayCheckBox.Location = new Point(65, 160);
            this.Controls.Add(sundayCheckBox);

            // back button
            back = new Button();
            back.Size = new Size(75, 30);
            back.Location = new Point(150, 195);
            back.Text = "Back";
            this.Controls.Add(back);
            back.Click += new EventHandler(backButtonHandler);
            back.BackColor = System.Drawing.Color.Orange;
            back.ForeColor = System.Drawing.Color.White;
            back.FlatStyle = FlatStyle.Flat;
            back.Font = new Font("Arial", 11, FontStyle.Bold);
            back.TextAlign = ContentAlignment.MiddleCenter;

            // save button
            save = new Button();
            save.Size = new Size(75, 30);
            save.Location = new Point(65, 195);
            save.Text = "Save";
            this.Controls.Add(save);
            save.Click += new EventHandler(saveButtonHandler);
            save.BackColor = System.Drawing.Color.Orange;
            save.ForeColor = System.Drawing.Color.White;
            save.FlatStyle = FlatStyle.Flat;
            save.Font = new Font("Arial", 11, FontStyle.Bold);
            save.TextAlign = ContentAlignment.MiddleCenter;

			// add panel to MasterForm
            mf.Controls.Add(this);
            
        }//end AlterAvailabilityForm constructor

        // -----form methods---------------------
        
        public string[] GetAvailability()
        {
			Console.WriteLine("AlterAvailabilityForm.GetAvailability() called.");
			
            string[] avail = new string[8];
            avail[0] = user.Username;

            if (mondayCheckBox.Checked == true)
                avail[1] = "1";
            else 
                avail[1] = "0";

            if (tuesdayCheckBox.Checked == true)
                avail[2] = "1";
            else 
                avail[2] = "0";

            if (wednesdayCheckBox.Checked == true)
                avail[3] = "1";
            else 
                avail[3] = "0";

            if (thursdayCheckBox.Checked == true)
                avail[4] = "1";
            else 
                avail[4] = "0";

            if (fridayCheckBox.Checked == true)
                avail[5] = "1";
            else 
                avail[5] = "0";

            if (saturdayCheckBox.Checked == true)
                avail[6] = "1";
            else 
                avail[6] = "0";

            if (sundayCheckBox.Checked == true)
                avail[7] = "1";
            else 
                avail[7] = "0";

            return avail;
        }

        public void PopulateData(string[] avail)
        {

            Console.WriteLine("AlterAvailabilityForm.PopulateData() called with param:  {0}", avail);
            
            if (avail[0] != null)
            {
                if (avail[1] == "1")
                    mondayCheckBox.Checked = true;
                if (avail[2] == "1")
                    tuesdayCheckBox.Checked = true;
                if (avail[3] == "1")
                    wednesdayCheckBox.Checked = true;
                if (avail[4] == "1")
                    thursdayCheckBox.Checked = true;
                if (avail[5] == "1")
                    fridayCheckBox.Checked = true;
                if (avail[6] == "1")
                    saturdayCheckBox.Checked = true;
                if (avail[7] == "1")
                    sundayCheckBox.Checked = true;
            }
        }

        public void DisplayMessage(string msg)
        {
            Console.WriteLine("AlterAvailabilityForm.DisplayMessage() called with param:  {0}", msg);
            
            //message label
            messageLabel = new Label();
            messageLabel.Size = new Size(300, 20);
            messageLabel.Location = new Point(65, 240);
            messageLabel.Text = msg;
            messageLabel.Font = new Font("Arial", 11);
            this.Controls.Add(messageLabel);
        }

        public void Destroy()
        {
            Console.WriteLine("AlterAvailabilityForm destroyed.");
            
            mf.Controls.Remove(this);
        }

        public void Save()
        {
            Console.WriteLine("AlterAvailabilityForm.Save() called.");
            
            aactlr.Save(GetAvailability());
        }

        public void Back()
        {
            Console.WriteLine("AlterAvailabilityForm.Back() called.");
            
            aactlr.Back();
        }

        // -----button event handlers-------------------
        
        private void backButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("AlterAvailabilityForm BackButton pressed.");
            
            Back();
        }
        private void saveButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("AlterAvailabilityForm SaveButton pressed.");
            
            Save();
        }
    }//end AlterAvailabilityForm class
}//end CDJScheduler namespace