using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webcon_Task.Builder
{
    interface Builder
    {
       
        void Construct(string path);
        Product BuildOutput();
            
    }
}
