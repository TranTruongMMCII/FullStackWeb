using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NETFW.Final.TranVanDanTruong.Models
{
    [Table("ProductionCompany")]
    public class ProductionCompany
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage ="Enter name of company")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter address of company")]
        public string Address { get; set; }
    }
}