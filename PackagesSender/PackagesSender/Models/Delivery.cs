using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1PackagesSender.Models
{
    [Table("Deliveries")]
    public class Delivery
    {
        [Key]
        [Column("PK_Deliveries")]
        public int DeliveryID { get; set; }
        [Column("DEL_NameOfPackage")]
        public string NameOfParcel { get; set; }
        [Column("DEL_AddressOfDestination")]
        public string AddressOfDestination { get; set; }
        [Column("DEL_DateOfMade")]
        public DateTime DateOfMade { get; set; }
        [Column("DEL_WeightOfDelivery ")]
        public double WeightOfDelivery { get; set; }
        [Column("FK_Deliveries_MainPackages")]
        public int PackageID { get; set; }
        
       
    }
}
