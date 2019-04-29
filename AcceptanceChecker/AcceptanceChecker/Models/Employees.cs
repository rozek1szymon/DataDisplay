using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1PackagesSender.Models
{
    [Table("Employees")]
    public class Employees
    {
        [Key]
        [Required]
        [Column("ORG_ID")]
        public int EmoplyeeID { get; set; }

        [Column("ORG_Name")]
        [Required]
        public string Name { get; set; }

        [Column("ORG_Login")]
        [Required]
        public string Login { get; set; }

        public int? ORG_ManagerID { get; set; }
        [ForeignKey("ORG_ManagerID")]
        public virtual Employees employees { get; set; }



       
       
        
        


    }
}
