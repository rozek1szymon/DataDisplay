using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webcon_Task.Builder
{
     public interface IBuilder
    {
       
        void Construct(string path);
        Product BuildOutput();
            
    }
}
