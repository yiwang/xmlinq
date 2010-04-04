using System;
using System.Xml.Linq;

// http://www.hookedonlinq.com/LINQtoXML5MinuteOverview.ashx

namespace XmLinq
{
    class Linq2XML
    {
        public static void Main0()
        {
            System.Console.WriteLine("LINQ to XML - 5 Minute Overview");
            //createXElem();
            //createXDoc();
            loadXDoc();
            Console.ReadLine();
        }

        private static void loadXDoc()
        {
            XDocument xdoc = XDocument.Load("sample.xml");
            Console.WriteLine(xdoc);

        }

        private static void createXDoc()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("this is a comment"),
                new XElement("rss",
                    new XAttribute("ver", "0.0.0"),
                    new XElement("channel",
                        new XElement("title", "Channel Title"),
                        new XElement("desc", "Channel Description"),
                        new XAttribute("rss-channel-attr", "value")
                        
                    )
                )
            );
            Console.WriteLine(doc);
            doc.Save("sample.xml");
        }

        private static void createXElem() {
            XElement xml = new XElement("contacts",
                                new XElement("contact",
                                    new XAttribute("contactID", "2"),
                                    new XElement("firstName", "Barry")
                                ),
                                new XElement("contact",
                                    new XAttribute("contactID", "3"),
                                    new XAttribute("ff", "BB")
                                )
                           );
            Console.WriteLine(xml);
        }
    }
}
