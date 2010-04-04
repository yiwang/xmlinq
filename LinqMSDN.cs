using System;
using System.Linq;
using System.Collections.Generic;


// http://msdn.microsoft.com/library/bb308959.aspx

class app
{
    static void Main()
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

        Console.ReadLine();
    }
}