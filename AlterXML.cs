using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

// http://stackoverflow.com/questions/331502/linq-to-xml-update-alter-the-nodes-of-an-xml-document

namespace XmLinq
{
    class AlterXML
    {
        public static void main(string[] args)
        {
            string xml = @"<data><super /><record id='1' /><record id='2' info='old info' /><record id='3' /><record id='4' /></data>";
            StringReader sr = new StringReader(xml);
            XDocument d = XDocument.Load(sr);

            var list = from XElement e in d.Descendants("record")
                       //where e.Attribute("id").Value == "1"
                       select e;

            Console.WriteLine(d);

            foreach (XElement e in list.ToArray())
            {
                e.Add(new XElement("sub-rec"));
                e.SetAttributeValue("K", "value");
                e.SetElementValue("sub-rec-new", "sr");
                //e.Remove();
            }

            d.Descendants("super").Single().Add(new XElement("sub"));
            d.Descendants("record").Where(x => x.Attribute("id").Value == "3").Single().Remove();
            d.Descendants("record").Where(x => x.Attribute("id").Value == "2").Single().SetAttributeValue("info", "new sample info");
            XmlWriter xw = XmlWriter.Create(Console.Out);

            d.WriteTo(xw);
            xw.Flush();

            Console.WriteLine();
            Console.WriteLine(d);

            //Console.WriteLine(list);
            //Console.WriteLine(xml);
            Console.ReadLine();

        }
    }
}