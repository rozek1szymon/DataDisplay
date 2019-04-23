using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace Webcon_Task
{
    class Program
    {
        
    static void Main(string[] args)
        {           
            XmlReader xmlReader= new XmlReader();
            JSONReader jSONReader = new JSONReader();

            xmlReader.Construct("myXml.xml");
            jSONReader.Construct("json1.json");

            View.MyDataInfo(xmlReader.BuildOutput());
            View.MyDataInfo(jSONReader.BuildOutput());

            Console.ReadKey();
        }
    }
}





