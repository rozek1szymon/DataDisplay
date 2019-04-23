using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1PackagesSender.Models
{
    public  class MainPackagesIndexData
    {       
        public MainPackage MainPackage { get; set; }
        public Delivery Delivery { get; set; }
        public List<Delivery> Deliveries { get; set; }
       
        public MainPackagesIndexData()
        {
            Deliveries = new List<Delivery>();                    
        }

    }
}
