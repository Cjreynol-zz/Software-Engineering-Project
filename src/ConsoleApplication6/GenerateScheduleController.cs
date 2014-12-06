using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDJScheduler
{
    class GenerateScheduleController
    {
        private DBConnector dbConn;
        private GenerateScheduleForm gsForm;
        private MainController mCtlr;
        private MasterForm mf;

        public GenerateScheduleController(DBConnector dbc, MainController mcp, MasterForm mf)
        {
            Console.WriteLine("GenerateScheduleController created.");
            this.mf = mf;
            dbConn = dbc;
            mCtlr = mcp;
            
        }//end GenerateScheduleController constructor

        public void Start()
        {
            Console.WriteLine("GenerateScheduleController.Start() called.");
            
            gsForm = new GenerateScheduleForm(this, mf);
        }

        public void Back()
        {
            Console.WriteLine("GenerateScheduleController.Back() called.");
            
            gsForm.Destroy();
            mCtlr.DisplayMainMenu();
        }

        public void Generate(string genType)
        {
            Console.WriteLine("GenerateScheduleController.Generate() called with param:  {0}", genType);
            
            GenerateSchedule(genType, dbConn.GetAllAvailability());
        }

        private void GenerateSchedule(string genType, List<string[]> avail)
        {
            Console.WriteLine("GenerateScheduleController.GenerateSchedule() called with params:  {0}, {1}", genType, avail);
            
            List<string>[] sched = dbConn.GetSchedule();
            switch (genType)
            {
                case "Most Hours": MostHours(avail, sched); break;
                case "Least Hours": LeastHours(avail, sched); break;
                default: throw new ApplicationException("A Priority Needs to be selected");
            }
        }

		/// <summary>
		/// Used to store a username with a number of days, for the purposes of ranking them during scheduler generation
		/// </summary>
        private class emplRanking :IComparable<emplRanking>
        {
            public string uname;
            public int days;

            public emplRanking(string uname, int days)
            {
                this.uname = uname;
                this.days = days;
            }

            public int CompareTo(emplRanking other)
            {
                if (this.days < other.days)
                    return -1;
                else if (this.days > other.days)
                    return 1;
                else
                    return 0;
            }
        }//end emplRanking class
        
        private void MostHours(List<string[]> avail, List<string>[] sched)
        {
        	Console.WriteLine("GenerateScheduleController.MostHours() called with params:  {0}, {1}", avail, sched);

			// rank the employees based on the number of days worked in the previous schedule
            List<emplRanking> emplRank = new List<emplRanking>();
            foreach (string[] name in avail)
            {
                string uname = name[0];
                int days = 0;
                for (int i = 0; i < sched.Length; i++) // mon - sun
                    foreach (string entry in sched[i]) // each employee working that day in sched
                        if (uname == entry)
                            days += 1;
                emplRank.Add(new emplRanking(uname, days));
            }
            emplRank.Sort();
            
            // use ranked list to create schedule, keeping track of number of workers each day
            int[] workersPerDay = { 0, 0, 0, 0, 0, 0, 0 };
            // create empty list in each spot of the array, for storing the employees in the schedule
            List<string>[] schedule = new List<string>[7];
            for (int i = 0; i < schedule.Length; i++)
                schedule[i] = new List<string>();
            
            for (int num = 0; num < emplRank.Count; num++)
            {
                foreach (var record in avail)
                	// match employee in rank list with their availability
                    if (emplRank[num].uname == record[0])
                    	// assign worker all of their availability from the avail list
                        for (int i = 1; i < record.Length; i++) 
                            if ((string) record[i] == "1" && workersPerDay[i - 1] < 2)
                            {
                            // availability starts at 1, sched and workerPerDay start at 0
                            // so the index must be subtracted to match up the lists/arrays
                                schedule[i - 1].Add(emplRank[num].uname);
                                workersPerDay[i - 1] += 1;
                            }
            }
            
            // schedule is now generated, check for empty days
            bool check = true;
            string failDay = "";
            for (int i = 0; i < workersPerDay.Length; i++)
                if (workersPerDay[i] == 0)
                {
                    check = false;
                    switch (i)
                    {
                        case 0:
                            failDay += "Monday" + ", ";
                            break;
                        case 1:
                            failDay += "Tuesday" + ", ";
                            break;
                        case 2:
                            failDay += "Wednesday" + ", ";
                            break;
                        case 3:
                            failDay += "Thursday" + ", ";
                            break;
                        case 4:
                            failDay += "Friday" + ", ";
                            break;
                        case 5:
                            failDay += "Saturday" + ", ";
                            break;
                        case 6:
                            failDay += "Sunday" + ", ";
                            break;
                        default:
                            Console.WriteLine("Dammit");
                            break;
                    }
                }

			// if schedule is valid (all days have a worker) then store it, otherwise display an error
            if (check)
            {
                dbConn.StoreSchedule(schedule);
                gsForm.DisplayMessage("Schedule has been created and stored.");
            }
            else
            {
                string errorMsg = "Schedule could not be created, days that had no workers:  " + failDay.Substring(0, failDay.Length - 2);
                gsForm.DisplayMessage(errorMsg);
            }
        }

        private void LeastHours(List<string[]> avail, List<string>[] sched)
        {
            Console.WriteLine("GenerateScheduleController.MostHours() called with params:  {0}, {1}", avail, sched);

			// rank the employees based on the number of days worked in the previous schedule
            List<emplRanking> emplRank = new List<emplRanking>();
            foreach (string[] name in avail)
            {
                string uname = name[0];
                int days = 0;
                for (int i = 0; i < sched.Length; i++) // mon - sun
                    foreach (string entry in sched[i]) // each employee working that day in sched
                        if (uname == entry)
                            days += 1;
                emplRank.Add(new emplRanking(uname, days));
            }
            emplRank.Sort();
            
            // use ranked list to create schedule, keeping track of number of workers each day
            int[] workersPerDay = { 0, 0, 0, 0, 0, 0, 0 };
            // create empty list in each spot of the array, for storing the employees in the schedule
            List<string>[] schedule = new List<string>[7];
            for (int i = 0; i < schedule.Length; i++)
                schedule[i] = new List<string>();
            
            for (int num = 0; num < emplRank.Count; num++)
            {
                foreach (var record in avail)
                	// match employee in rank list with their availability
                    if (emplRank[num].uname == record[0])
                    	// assign worker all of their availability from the avail list
                        for (int i = 1; i < record.Length; i++) 
                            if ((string) record[i] == "1" && workersPerDay[i - 1] < 2)
                            {
                            // availability starts at 1, sched and workerPerDay start at 0
                            // so the index must be subtracted to match up the lists/arrays
                                schedule[i - 1].Add(emplRank[num].uname);
                                workersPerDay[i - 1] += 1;
                            }
            }
            
            // schedule is now generated, check for empty days
            bool check = true;
            string failDay = "";
            for (int i = 0; i < workersPerDay.Length; i++)
                if (workersPerDay[i] == 0)
                {
                    check = false;
                    switch (i)
                    {
                        case 0:
                            failDay += "Monday" + ", ";
                            break;
                        case 1:
                            failDay += "Tuesday" + ", ";
                            break;
                        case 2:
                            failDay += "Wednesday" + ", ";
                            break;
                        case 3:
                            failDay += "Thursday" + ", ";
                            break;
                        case 4:
                            failDay += "Friday" + ", ";
                            break;
                        case 5:
                            failDay += "Saturday" + ", ";
                            break;
                        case 6:
                            failDay += "Sunday" + ", ";
                            break;
                        default:
                            Console.WriteLine("Dammit");
                            break;
                    }
                }

			// if schedule is valid (all days have a worker) then store it, otherwise display an error
            if (check)
            {
                dbConn.StoreSchedule(schedule);
                gsForm.DisplayMessage("Schedule has been created and stored.");
            }
            else
            {
                string errorMsg = "Schedule could not be created, days that had no workers:  " + failDay.Substring(0, failDay.Length - 2);
                gsForm.DisplayMessage(errorMsg);
            }
        }
    }//end GenerateScheduleController class
}//end CDJScheduler namespace