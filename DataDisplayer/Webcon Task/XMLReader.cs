using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Webcon_Task.Builder;

namespace Webcon_Task
{
    public class XmlReader : Builder.IBuilder
    {

        public Product product = new Product();
        public XmlDocument XmlDoc;
        public string text;

        //without validation
        public void Construct(string PathFile)
        {
            
            XmlDoc = new XmlDocument();
            XmlDoc.Load(PathFile);
            product.Data.Add("Our XML\n");
            foreach (XmlNode node in XmlDoc.DocumentElement.ChildNodes)
            {

                text = node.InnerText;
                product.Data.Add(text);
            }
        }

        public Product BuildOutput()
        {
            
            return product;

        }


    }
}
