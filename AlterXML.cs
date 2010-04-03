using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

// http://stackoverflow.com/questions/331502/linq-to-xml-update-alter-the-nodes-of-an-xml-document

class AlterXML
{
    static void Main(string[] args)
    {
        string xml = @"<data><record id='1' /><record id='2' /><record id='3' /><record id='4' /></data>";
        StringReader sr = new StringReader(xml);
        XDocument d = XDocument.Load(sr);
        Console.WriteLine(xml);
        Console.ReadLine();

    }
}