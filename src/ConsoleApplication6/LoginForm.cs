using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CDJScheduler
{
    class LoginForm : Panel
    {
        private MasterForm mf;
        private LoginController lictlr;

        private Label titleLabel;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button submit;
        private Label errorLabel;

        public LoginForm(LoginController lictlr, MasterForm mf)
        {
            Console.WriteLine("LoginForm created.");
            
            // form properties
            this.mf = mf;
            this.lictlr = lictlr;
            mf.Text += " - Login";
            this.Size = new Size(375, 300);
            mf.Size = new Size(375, 300);
            mf.BackColor = System.Drawing.Color.White;

            //title label
            titleLabel = new Label();
            titleLabel.Size = new Size(165, 30);
            titleLabel.Location = new Point(5, 5);
            titleLabel.Text = "CDJ Scheduler";
            titleLabel.Font = new Font("Areil", 16);
            titleLabel.ForeColor = System.Drawing.Color.Orange;
            this.Controls.Add(titleLabel);

            // username label
            usernameLabel = new Label();
            usernameLabel.Size = new Size(80, 30);
            usernameLabel.Location = new Point(65, 45);
            usernameLabel.Text = "Username: ";
            usernameLabel.Font = new Font("Arial", 11);
            this.Controls.Add(usernameLabel);

            // password label
            passwordLabel = new Label();
            passwordLabel.Size = new Size(80, 30);
            passwordLabel.Location = new Point(65, 75);
            passwordLabel.Text = "Password: ";
            passwordLabel.Font = new Font("Arial", 11);
            this.Controls.Add(passwordLabel);

            // username textbox
            usernameTextBox = new TextBox();
            usernameTextBox.Size = new Size(100, 30);
            usernameTextBox.Location = new Point(150, 45);
            usernameTextBox.Font = new Font("Arial", 10);
            this.Controls.Add(usernameTextBox);

            // password textbox
            passwordTextBox = new TextBox();
            passwordTextBox.Size = new Size(100, 30);
            passwordTextBox.Location = new Point(150, 75);
            passwordTextBox.Font = new Font("Arial", 10);
            passwordTextBox.UseSystemPasswordChar = true;
            this.Controls.Add(passwordTextBox);

            // submit button
            submit = new Button();
            submit.Size = new Size(100, 30);
            submit.Location = new Point(150, 105);
            submit.Text = "Submit";
            this.Controls.Add(submit);
            submit.BackColor = System.Drawing.Color.Orange;
            submit.ForeColor = System.Drawing.Color.White;
            submit.FlatStyle = FlatStyle.Flat;
            submit.Font = new Font("Arial", 11, FontStyle.Bold);
            submit.TextAlign = ContentAlignment.MiddleCenter;
            submit.Click += new EventHandler(submitButtonHandler);

			// add panel to MasterForm
            mf.Controls.Add(this);
            
        }//end LoginForm constructor

        // -----form methods--------------------------
        
        public void DisplayMessage(string msg)
        {
            Console.WriteLine("LoginForm.DisplayMessage() called with param:  {0}", msg);
            
            //error label
            if (errorLabel != null)
                this.Controls.Remove(errorLabel);
            errorLabel = new Label();
            errorLabel.Size = new Size(300, 20);
            errorLabel.Location = new Point(150, 175);
            errorLabel.Text = msg;
            usernameLabel.Font = new Font("Arial", 11);
            this.Controls.Add(errorLabel);
        }

        public void Destroy()
        {
            Console.WriteLine("LoginForm destroyed.");
            
            mf.Controls.Remove(this);
        }

        public void Submit()
        {
            Console.WriteLine("LoginForm.Submit() called.");
            
            if (usernameTextBox.Text != "" && passwordTextBox.Text != "")
                lictlr.Submit(usernameTextBox.Text, passwordTextBox.Text);
            else
                DisplayMessage("Enter info to submit.");
        }

        // -----button event handlers-----------------
        
        private void submitButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("LoginForm SubmitButton pressed.");
            
            Submit();
        }
    }//end LoginForm class
}//end CDJScheduler namespace