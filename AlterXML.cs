using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

// http://stackoverflow.com/questions/331502/linq-to-xml-update-alter-the-nodes-of-an-xml-document

class AlterXML
{
    static void Main(string[] args)
    {
        string xml = @"<data><record id='1' /><record id='2' /><record id='3' /><record id='4' /></data>";
        StringReader sr = new StringReader(xml);
        XDocument d = XDocument.Load(sr);

        var list = from XElement e in d.Descendants("record")
                   where e.Attribute("id").Value == "2"
                   select e;

        Console.WriteLine(d);

        foreach (XElement e in list.ToArray())
        {
            e.Remove();
        }

        d.Descendants("record").Where(x => x.Attribute("id").Value == "3").Single().Remove();

        XmlWriter xw = XmlWriter.Create(Console.Out);
        d.WriteTo(xw);
        xw.Flush();

        Console.WriteLine(d);

        //Console.WriteLine(list);
        //Console.WriteLine(xml);
        Console.ReadLine();

    }
}