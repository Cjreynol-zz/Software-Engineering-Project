using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CDJScheduler
{
    class SelectEmployeeForm : Panel
    {
        private MasterForm mf;
        private SelectEmployeeController sectlr;

        private Label titleLabel;
        private Label dropDownLabel;
        private ComboBox employeeList;
        private Button submit;

		/// <summary>
		/// Creates the SEForm as a panel, with all of its widgets, and adds itself to the MasterForm
		/// </summary>
        public SelectEmployeeForm(SelectEmployeeController sectlr, MasterForm mf)
        {
            Console.WriteLine("SelectEmployeeForm created.");
            // form properties
            this.mf = mf;
            this.sectlr = sectlr;
            mf.Text += " - Select Employee";
            this.Size = new Size(375, 300);
            mf.Size = new Size(375, 300);

            //title label
            titleLabel = new Label();
            titleLabel.Size = new Size(195, 30);
            titleLabel.Location = new Point(5, 5);
            titleLabel.Text = "Select Employee";
            titleLabel.Font = new Font("Areil", 16);
            titleLabel.ForeColor = System.Drawing.Color.Orange;
            this.Controls.Add(titleLabel);

            // label and drop down menu for the list of employees
            dropDownLabel = new Label();
            dropDownLabel.Size = new Size(80, 50);
            dropDownLabel.Location = new Point(5, 40);
            dropDownLabel.Text = "Choose Employee:";
            dropDownLabel.Font = new Font("Arial", 11);
            this.Controls.Add(dropDownLabel);

            employeeList = new ComboBox();
            employeeList.DropDownStyle = ComboBoxStyle.DropDownList;
            employeeList.Size = new Size(200, 30);
            employeeList.Location = new Point(90, 50);
            employeeList.Font = new Font("Arial", 11);
            this.Controls.Add(employeeList);

            // submit button
            submit = new Button();
            submit.Size = new Size(100, 30);
            submit.Location = new Point(90, 85);
            submit.Text = "Submit";
            submit.Click += new EventHandler(submitButtonHandler);
            submit.BackColor = System.Drawing.Color.Orange;
            submit.ForeColor = System.Drawing.Color.White;
            submit.FlatStyle = FlatStyle.Flat;
            submit.Font = new Font("Arial", 11, FontStyle.Bold);
            submit.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(submit);

			// add panel to MasterForm
            mf.Controls.Add(this);
            
        }//end SelectEmployeeForm constructor


        // -----form methods------------------------------------

		/// <summary>
		/// Sets the employee drop down box to be filled with a given list of employees
		/// </summary>
        public void Populate(List<string> employees)
        {
            Console.WriteLine("SelectEmployeeForm.Populate() called with param:  {0}", employees);
            
            employeeList.DataSource = employees;  
        }

		/// <summary>
		/// Passes the user choice of employee to the SECtlr to move on to AlterAvailability
		/// </summary>
        public void Submit()
        {
            Console.WriteLine("SelectEmployeeForm.Submit() called.");
            
            if (employeeList.Text != "")
            	sectlr.Submit(new User(employeeList.Text, "", false));   	
        }

		/// <summary>
		/// Removes the panel from the form, clearing it for other functionalities
		/// </summary>
        public void Destroy()
        {
            Console.WriteLine("SelectEmployeeForm destroyed.");
            
            mf.Controls.Remove(this);    
        }

        // -----button event handlers---------------------

		/// <summary>
		/// Captures submit button press, calls this class' associated method
		/// </summary>
        private void submitButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("SelectEmployeeForm SubmitButton pressed.");
            
            Submit();
        }
    }//end SelectEmployeeForm class
}//end CDJScheduler namespace