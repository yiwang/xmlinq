using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;


// http://www.hookedonlinq.com/JoinOperator.ashx

namespace XmLinq
{
    class JoinSimpleExample
    {
        public static void Main4(string[] args)
        {
            //Linq2XML.Main0();
            //AlterXML.Main1(args);
            //LinqQuery.Main2(args);
            //Linq2Obj.Main3(new string[]{"good"});

            var customers = new List<Customer>() { 
                new Customer {Key = 1, Name = "Gottshall" },
                new Customer {Key = 2, Name = "Valdes" },
                new Customer {Key = 3, Name = "Gauwain" },
                new Customer {Key = 4, Name = "Deane" },
                new Customer {Key = 5, Name = "Zeeman" } 
            };

            var orders = new List<Order>() {
                new Order {Key = 1, OrderNumber = "Order 1" },
                new Order {Key = 1, OrderNumber = "Order 2" },
                new Order {Key = 4, OrderNumber = "Order 3" },
                new Order {Key = 4, OrderNumber = "Order 4" },
                new Order {Key = 5, OrderNumber = "Order 5" },
            };

            var q = from c in customers
                    join o in orders on c.Key equals o.Key
                    select new { c.Name, o.OrderNumber };

            foreach (var i in q)
            {
                Console.WriteLine("Customer: {0}  Order Number: {1}",
                    i.Name.PadRight(11, ' '), i.OrderNumber);
            }

            Console.ReadLine();
        }
    }
public class Customer
{
    public int Key;
    public string Name;
}
 
public class Order
{
    public int Key;
    public string OrderNumber;
}
}