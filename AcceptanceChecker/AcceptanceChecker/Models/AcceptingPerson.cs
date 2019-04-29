using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1PackagesSender.Models
{
    [Table("AcceptingPeople")]
    public class AcceptingPerson
    {
        [Key]
        [Required]
        [Column("ACP_ID")]
        public int AcceptingPersonID { get; set; }

        [Required]
        [Column("ACP_Category")]
        public string Category { get; set; }

        [Required]
        [Column("ACP_Login")]
        public string Login { get; set; }

        [Required]
        [Column("ACP_Limit")]
        public decimal Limit { get; set; }

        
        [Column("ACP_SubstituteLogin")]
        public string SubstituteLogin { get; set; }

        [Column("ACP_SubstituteLimit")]
        public decimal? SubstituteLimit { get; set; }

    }
}
