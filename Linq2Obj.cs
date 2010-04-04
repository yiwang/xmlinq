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
        public static void Main(string[] args)
        {
            //Linq2XML.Main0();
            //AlterXML.Main1(args);
            //LinqQuery.Main2(args);

            //nums_sum();
            //contact_sample();

            Console.ReadLine();
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

    class Contacts
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;

        Contacts(string fn,string ln,DateTime dob)
        {
            FirstName = fn;
            LastName = ln;
            DateOfBirth = dob;
        }

        public static List<Contacts> SampleData()
        {
            List<Contacts> r = new List<Contacts>();
            
            r.Add(new Contacts("Barney","Gottshall",Convert.ToDateTime("19-Oct-1945")));
            r.Add(new Contacts("Yi", "Wang", Convert.ToDateTime("1-May-1993")));
            r.Add(new Contacts("2", "Gottshall", Convert.ToDateTime("19-Oct-1990")));
            r.Add(new Contacts("3", "Gottshall", Convert.ToDateTime("19-Oct-1945")));
            r.Add(new Contacts("4", "Gottshall", Convert.ToDateTime("19-Oct-1945")));
            r.Add(new Contacts("5", "Gottshall", Convert.ToDateTime("19-Oct-1945")));

            //Console.WriteLine(r[1].DateOfBirth);
            return r;
        }
    }
}