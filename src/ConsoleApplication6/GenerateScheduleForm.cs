using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CDJScheduler
{
    class GenerateScheduleForm : Panel
    {
        private MasterForm mf;
        private GenerateScheduleController gsctlr;

        private Label titleLabel;
        private Label dropDownLabel;
        private ComboBox priority;
        private Button genSched;
        private Button back;
        private Label msgLabel;

        public GenerateScheduleForm(GenerateScheduleController gsctlr, MasterForm mf)
        {
            Console.WriteLine("GenerateScheduleForm created.");
            
            // form properties
            this.mf = mf;
            this.gsctlr = gsctlr;
            mf.Text += " - Generate Schedule";
            this.Size = new Size(375, 300);
            mf.Size = new Size(375, 300);

            //title label
            titleLabel = new Label();
            titleLabel.Size = new Size(300, 30);
            titleLabel.Location = new Point(5, 5);
            titleLabel.Text = "Generate Schedule";
            titleLabel.Font = new Font("Areil", 16);
            titleLabel.ForeColor = System.Drawing.Color.Orange;
            this.Controls.Add(titleLabel);

            // priority drop down label
            dropDownLabel = new Label();
            dropDownLabel.Size = new Size(80, 50);
            dropDownLabel.Location = new Point(5, 40);
            dropDownLabel.Text = "Select Priority: ";
            dropDownLabel.Font = new Font("Arial", 11);
            this.Controls.Add(dropDownLabel);

            // priority select
            priority = new ComboBox();
            priority.DropDownStyle = ComboBoxStyle.DropDownList;
            priority.Size = new Size(200, 30);
            priority.Location = new Point(90, 50);
            priority.Font = new Font("Arial", 11);
            List<string> priorities = new List<string>();
            priorities.Add("Most Hours");
            priorities.Add("Least Hours");
            priority.DataSource = priorities;
            this.Controls.Add(priority);

            // generate schedule button
            genSched = new Button();
            genSched.Size = new Size(100, 60);
            genSched.Location = new Point(90, 85);
            genSched.Text = "Generate Schedule";
            this.Controls.Add(genSched);
            genSched.Click += new EventHandler(genSchedButtonHandler);
            genSched.BackColor = System.Drawing.Color.Orange;
            genSched.ForeColor = System.Drawing.Color.White;
            genSched.FlatStyle = FlatStyle.Flat;
            genSched.Font = new Font("Arial", 11, FontStyle.Bold);
            genSched.TextAlign = ContentAlignment.MiddleCenter;

            // back button
            back = new Button();
            back.Size = new Size(100, 60);
            back.Location = new Point(190, 85);
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
            
        }//end GenerateScheduleForm constructor

        // -----form methods----------------------------
        public void Destroy()
        {
            Console.WriteLine("GenerateScheduleForm destroyed.");
            
            mf.Controls.Remove(this);
        }

        public void DisplayMessage(string msg)
        {
            Console.WriteLine("GenerateScheduleForm.DisplayMessage() called with param:  {0}", msg);
            
            //message label
            msgLabel = new Label();
            msgLabel.Size = new Size(230, 100);
            msgLabel.Location = new Point(90, 160);
            msgLabel.Text = msg;
            msgLabel.Font = new Font("Arial", 11);
            this.Controls.Add(msgLabel);
        }

        public void Generate()
        {
            Console.WriteLine("GenerateScheduleForm.Generate() called.");
            
            gsctlr.Generate(priority.Text);
        }

        public void Back()
        {
            Console.WriteLine("GenerateScheduleForm.Back() called.");
            
            gsctlr.Back();
        }

        // -----button event handlers-----------------------
        
        private void genSchedButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("GenerateScheduleForm GenerateButton pressed.");
            
            Generate();
        }

        private void backButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("GenerateScheduleForm BackButton pressed.");
            
            Back();
        }
    }//end GenerateScheduleForm class
}//end CDJScheduler namespace