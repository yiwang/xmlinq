using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

// http://www.hookedonlinq.com/WriteLINQQueries.ashx

namespace XmLinq
{
    class LinqQuery
    {
        static void Main(string[] args)
        {
            //Linq2XML.Main0();
            //AlterXML.Main1(args);

            double[] nums = new double[] { 0, 4, 4, 2, 3, 543, 3343.3, 432, -3, 0 };
            var result = from n in nums
                         where n < 5
                         orderby n                         
                         select n;

            //result = nums.Where(b =>b < 5).OrderBy(b=>b);

            var result1 = (from n in nums
                      where n < 5
                      orderby n
                      select n).Distinct();


            var arr = result.ToArray().Reverse();
            var arr1 = result1.ToArray().Reverse();
            printArray(arr);
            printArray(arr1);
            Console.ReadLine();
        }

        private static void printArray(IEnumerable <double> arr)
        {
            foreach (double e in arr)
            {
                Console.Write(e);
                Console.Write(", ");
            }
            Console.WriteLine();
        }

    }
}