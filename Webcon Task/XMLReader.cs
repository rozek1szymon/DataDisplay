using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Webcon_Task.Builder;

namespace Webcon_Task
{
    public class XmlReader : Builder.Builder
    {

        public Product product = new Product();
        public XmlDocument XmlDoc;
        public string text;

        public void Construct(string PathFile)
        {
            //without validation
            XmlDoc = new XmlDocument();
            XmlDoc.Load(PathFile);
            product.Data.Add("Our XML\n");
            foreach (XmlNode node in XmlDoc.DocumentElement.ChildNodes)
            {

                text = node.InnerText;
                product.Data.Add(text);
            }
        }


        //public int GetNumberOfItems(string name)
        //{
        //    return XmlDoc.GetElementsByTagName(name).Count;
        //}

        //public string GetElementValue(int number, string name)
        //{
        //    return XmlDoc.GetElementsByTagName(name).Item(number).InnerText;
        //}
       

        public Product BuildOutput()
        {
            
            return product;

        }


    }
}
