using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsScheduleManager { get; set; }

        public User(string un, string pw, bool sm)
        {
            Username = un;
            Password = pw;
            IsScheduleManager = sm;
        }
    } 

}
