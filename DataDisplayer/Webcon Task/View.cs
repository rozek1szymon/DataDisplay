using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webcon_Task.Builder;

namespace Webcon_Task
{
    public  class View
    {
        public Product data;
       
       
        public static void MyDataInfo(Product data)
        {
            foreach (string item in data.Data)
            {
                Console.WriteLine(item);
            }
        }
    }
}
