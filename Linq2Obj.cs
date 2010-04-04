using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;


// http://www.hookedonlinq.com/LINQtoObjects5MinuteOverview.ashx

namespace XmLinq
{
    class Linq2Obj
    {
        public static void Main3(string[] args)
        {
            //Linq2XML.Main0();
            //AlterXML.Main1(args);
            //LinqQuery.Main2(args);

            //nums_sum();
            //contact_sample();
            //group_example();

            use_join();

            Console.ReadLine();
        }

        private static void use_join()
        {
            List<Contacts> contacts = Contacts.SampleData();
            List<CallLog> callLog = CallLog.SampleData();

            var q = from call in callLog
                    join contact in contacts on call.Number equals contact.Phone
                    select new
                    {
                        contact.FirstName,
                        contact.LastName,
                        call.When,
                        call.Duration,
                        call.Number
                    };
            
            foreach (var call in q)
                Console.WriteLine("{0} - {1} {2} ({3}min)  {4}",
                                    call.When.ToString("ddMMM HH:m"),
                                    call.FirstName, call.LastName, call.Duration, call.Number);

        }

        private static void group_example()
        {
            List<Contacts> contacts = Contacts.SampleData();
            var q = from c in contacts
                    group c by c.State;

            foreach (var group in q)
            {
                Console.WriteLine("State: " + group.Key);
                foreach (Contacts c in group)
                    Console.WriteLine("  {0}  {1}", c.FirstName, c.LastName);
            }


        }

        private static void contact_sample()
        {
            List<Contacts> contacts = Contacts.SampleData();

            var q = from c in contacts
                    where c.DateOfBirth.AddYears(100) > DateTime.Now
                    orderby c.DateOfBirth descending
                    select c.FirstName + " " + c.LastName +
                        " b." + c.DateOfBirth.ToString("dd-MMM-yyyy");

            foreach (string s in q)
                Console.WriteLine(s);
        }

        private static void nums_sum()
        {
             double[] nums = new double[] { 0, 4, 2, 6, 3, 8, 3, 1 };
             double r = nums.Sum(x => x/2.0);

             Console.WriteLine(r);
        }
    }

    class CallLog
    {
        public string Number;
        public int Duration;
        public bool Incoming;
        public DateTime When;

        CallLog(string num, int dur, bool inc, DateTime wh){
            Number = num;
            Duration = dur;
            Incoming = inc;
            When = wh;
        }

        public static List<CallLog> SampleData()
        {
            List<CallLog> r = new List<CallLog>();
            r.Add(new CallLog("885 983 8858",1,true,Convert.ToDateTime("7-Aug-2006 18:1")));
            r.Add(new CallLog("885 983 2322", 2, false, Convert.ToDateTime("17-Dec-2009 8:2")));
            r.Add(new CallLog("885 983 8858", 3, true, Convert.ToDateTime("7-Aug-2006 18:3")));
            r.Add(new CallLog("885 983 8858", 4, true, Convert.ToDateTime("7-Aug-2006 18:4")));
            r.Add(new CallLog("885 983 8858", 5, true, Convert.ToDateTime("7-Aug-2006 18:5")));

            //Console.WriteLine(r[0].When);
            return r;
        }

    }
    class Contacts
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;
        public string Phone; 
        public string State;

        Contacts(string fn,string ln,DateTime dob,string ph, string st)
        {
            FirstName = fn;
            LastName = ln;
            DateOfBirth = dob;
            Phone = ph;
            State = st;
        }

        public static List<Contacts> SampleData()
        {
            List<Contacts> r = new List<Contacts>();

            r.Add(new Contacts("0 Barney", "Gottshall", Convert.ToDateTime("19-Oct-1945"), "885 983 8858", "CA"));
            r.Add(new Contacts("1 Yi", "Wang", Convert.ToDateTime("1-May-1993"), "885 983 8858", "TX"));
            r.Add(new Contacts("2", "Gottshall", Convert.ToDateTime("19-Oct-1990"), "885 983 8858", "WA"));
            r.Add(new Contacts("3", "Gottshall", Convert.ToDateTime("19-Oct-1945"), "885 983 8858", "WA"));
            r.Add(new Contacts("4", "Gottshall", Convert.ToDateTime("19-Oct-1945"), "885 983 8858", "WA"));
            r.Add(new Contacts("5", "Gottshall", Convert.ToDateTime("19-Oct-1945"), "885 983 8858", "WA"));

            //Console.WriteLine(r[1].DateOfBirth);
            return r;
        }
    }
}