using System;
using System.Linq;
using System.Collections.Generic;


// http://msdn.microsoft.com/library/bb308959.aspx

class app
{
    static void Main4()
    {

        string[] names = { "Burke", "Connor", "Frank", 
                       "Everett", "Albert", "George", 
                       "Harris", "David" };

        IEnumerable<string> query = from s in names
                                    where s.Length == 5
                                    orderby s
                                    select s.ToUpper();

        foreach (string item in query)
            Console.WriteLine(item);
        
        //

        Func<string, bool> filter = s => s.Length == 5;

        Func<string, string> extract = delegate(string s)
        {
            return s;
        };

        Func<string, string> project = delegate(string s)
        {
            return s.ToUpper();
        };

        IEnumerable<string> query1 = names.Where(filter)
                                         .OrderBy(extract)
                                         .Select(project);

        foreach (var item in query1)
            Console.WriteLine(item);

        Console.ReadLine();
    }
}