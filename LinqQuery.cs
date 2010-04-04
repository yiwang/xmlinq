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
        public static void main(string[] args)
        {
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

            foreach (double d in result)
            {
                Console.WriteLine(d);
            }

            var arr = result.ToArray().Reverse();
            var arr1 = result1.ToArray().Reverse();
            printArray(result);
            printArray2(arr1);
            Console.ReadLine();
        }

        private static void printArray2(IEnumerable<double> arr)
        {
            foreach (var e in arr)
            {
                Console.Write(e);
                Console.Write(", ");
            }
            Console.WriteLine();
        }

        public static void printArray<T>(IEnumerable <T> arr)
        {
            foreach (T e in arr)
            {                
                Console.Write(e);
                if (!arr.Last().Equals(e)) 
                    Console.Write(", ");
            }
            Console.WriteLine();
        }

    }
}