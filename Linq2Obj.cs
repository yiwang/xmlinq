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

            double[] nums = new double[] { 0, 4, 2, 6, 3, 8, 3, 1 };
            double r = nums.Sum(x => x/2.0);

            Console.WriteLine(r);
            Console.ReadLine();
        }
    }
}