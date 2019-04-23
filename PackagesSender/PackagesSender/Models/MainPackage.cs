using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1PackagesSender.Models
{
    [Table("MainPackages")]
    public class MainPackage
    {

        public MainPackage()
        {
            Deliveries = new List<Delivery>();
        }

        [Key]
        [Column("PK_MainPackages")]
        public int PackageID { get; set; }
        [Column("PACK_NameOfPackage")]
        public string NameOfPackage { get; set; }
        [Column("PACK_DateOfMadeThePackage")]
        public DateTime DateOfMadeThePackage { get; set; }
        [Column("PACK_IsPackageOpen")]
        public bool IsPackageOpen { get; set; }
        [Column("PACK_DateOfCloseThePackage")]
        public DateTime? DateOfCloseThePackage { get; set;}
        [Column("PACK_DestinationCityOfDelivery")]
        public string DestinationCityOfDelivery { get; set; }
        
        public List<Delivery> Deliveries { get; set; }
       
            
     

    }
}
