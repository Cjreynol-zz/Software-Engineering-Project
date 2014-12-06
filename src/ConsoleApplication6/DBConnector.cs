using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CDJScheduler
{
    class DBConnector
    { 
        private SQLiteConnection db;

        /// <summary>
        /// Creates the connection to the data store and manages formatting of data between the controllers and that data store. 
        /// </summary>
        public DBConnector()
        {
            Console.WriteLine("DBConnector created.");

            db = new SQLiteConnection("Data Source=CDJDB.sqlite;Version=3;");
            db.Open();
        }//end DBConnector constructor

        /// <summary>
        /// Debug function, only for testing.
        /// <para/>Executes a non-SELECT statement in the data store.
        /// </summary>
        public int RunCommand(string command)
        {
            SQLiteCommand cmd = new SQLiteCommand(command, db);
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Debug function, only for testing.
        /// <para/>Deletes the availability and schedule from the data store.
        /// </summary>
        public void DBClear()
        {
            Console.WriteLine("DBConnector.DBClear() called.");

            RunCommand("DELETE FROM AVAILABILITY;");
            RunCommand("DELETE FROM SCHEDULE;");
        }

        /// <summary>
        /// Returns a User object if one is associated with that username in the data store.
        /// <para/> Otherwise returns null.
        /// </summary>
        public User GetUser(string uname)
        {
            Console.WriteLine("DBConnector.GetUser() called with param:  {0}", uname);

            User result;
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM USERS WHERE username = '" + uname + "';", db);

            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                result = new User((string)reader["username"], (string)reader["password"], (Convert.ToInt32(reader["isSM"]) == 1 ? true : false));
            else
                result = null;

            return result;
        }

        /// <summary>
        /// Returns a list of all the employee usernames in the data store.
        /// </summary>
        public List<string> GetEmployees()
        {
            Console.WriteLine("DBConnector.GetEmployees() called.");

            List<string> empls = new List<string>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT username FROM USERS where isSM = 0;", db);

            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                empls.Add((string)reader["username"]);

            return empls;
        }

        /// <summary>
        /// Returns availability for the given user from the data store.
        /// <para/> Availability is in the form of {username,mon,tue,...,sun}.
        /// </summary>
        public string[] GetAvailability(User user)
        {
            Console.WriteLine("DBConnector.GetAvailability() called with param:  {0}", user);

            string[] avail = new string[8];
            avail[0] = user.Username;
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM AVAILABILITY WHERE username = '" + user.Username + "';", db);

            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int i = 1;
                for (int j = 1; j < reader.FieldCount; j++)
                    avail[i++] = (string)reader[j];
            }

            return avail;
        }

        /// <summary>
        /// Returns all of the availability from the data store.
        /// <para/> All in the form of a List of availabilities ({username,mon,tue,...,sun})
        /// </summary>
        public List<string[]> GetAllAvailability()
        {
            Console.WriteLine("DBConnector.GetAllAvailability() called.");

            List<string[]> allAvail = new List<string[]>();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM AVAILABILITY;", db);

            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string[] avail = new string[8];
                avail[0] = (string)reader[0];

                int i = 1;
                for (int j = 1; j < reader.FieldCount; j++)
                    avail[i++] = (string)reader[j];
                allAvail.Add(avail);
            }

            return allAvail;
        }

        /// <summary>
        /// Stores the given availability in the data store.
        /// <para/>First deletes the previous availability from the data store.
        /// </summary>
        public void StoreAvailability(string[] availability)
        {
            Console.WriteLine("DBConnector.StoreAvailability() called with param:  {0}", availability);

            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM AVAILABILITY WHERE username = '" + availability[0] + "';", db);
            cmd.ExecuteNonQuery();

            cmd = new SQLiteCommand("INSERT INTO AVAILABILITY(username, mon, tue, wed, thu, fri, sat, sun) VALUES('" + availability[0] 
                                    + "', '" + availability[1] + "', '" + availability[2] + "', '" + availability[3] + "', '" + availability[4] + "', '" 
                                    + availability[5] + "', '" + availability[6] + "', '" + availability[7] + "');", db);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Returns the schedule from the data store.
        /// <para/>Schedule is in the form of an array, with an index for each day of the week.
        /// <para/>Each index stores a list of the usernames of employees working that day.
        /// </summary>
        public List<string>[] GetSchedule()
        {
            Console.WriteLine("DBConnector.GetSchedule() called.");

            List<string>[] sched = new List<string>[7];
            int i = 0;
            SQLiteCommand cmd;

            foreach (string day in new string[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" })
            {
                List<string> list = new List<string>();
                cmd = new SQLiteCommand("SELECT * FROM SCHEDULE WHERE day = '" + day + "';", db);

                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add((string)reader["username"]);
                sched[i++] = list;
            }

            return sched;
        }

        /// <summary>
        /// Stores the given schedule in the data store.
        /// <para/>First deletes the previous schedule from the data store.
        /// </summary>
        public void StoreSchedule(List<string>[] schedule)
        {
            Console.WriteLine("DBConnector.StoreSchedule() called with param:  {0}", schedule);

            SQLiteCommand cmd = new SQLiteCommand("DELETE FROM SCHEDULE;", db);
            cmd.ExecuteNonQuery();

            int i = 0;
            foreach (string day in new string[] { "mon", "tue", "wed", "thu", "fri", "sat", "sun" })
            {
                foreach (var uname in schedule[i])
                {
                    cmd = new SQLiteCommand("INSERT INTO SCHEDULE(day, username) VALUES('" + day + "', '" + uname + "');", db);
                    cmd.ExecuteNonQuery();
                }
                i++;
            }
        }
    }//end DBConnector class
}//end CDJScheduler namespace

/* Reference Articles
http://blog.tigrangasparian.com/2012/02/09/getting-started-with-sqlite-in-c-part-one/
https://www.sqlite.org/datatype3.html
http://www.dreamincode.net/forums/topic/157830-using-sqlite-with-c%23/
*/