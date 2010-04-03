using System;
using System.Xml.Linq;
// A "Hello World"
namespace HelloWorld
{
    class Hello
    {
        static void Main()
        {
            System.Console.WriteLine("HW");
            createXElem();
            //createXDoc();
            Console.ReadLine();
        }
        private static void createXDoc()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes")
            );
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