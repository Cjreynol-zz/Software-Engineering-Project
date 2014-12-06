using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDJScheduler
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsScheduleManager { get; set; }

		/// <summary>
		/// Creates a User object to store all of the information on a particular user of the system.
		/// </summary>
        public User(string un, string pw, bool sm)
        {
            Username = un;
            Password = pw;
            IsScheduleManager = sm;
            
        }//end User constructor

		/// <summary>
		/// Returns a string representation of the user, labeling each attribute
		/// </summary>
        public override string ToString()
        {
            return "Username:  " + Username + ", password:  " + Password + ", is " + (IsScheduleManager ? " " : "not ") + "an SM";
        }
    }//end User class
}//end CDJScheduler namespace