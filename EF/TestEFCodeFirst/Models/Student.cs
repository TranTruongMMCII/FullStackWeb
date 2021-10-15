using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestEFCodeFirst.Models
{
    [Table("Student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Address { get; set; }

        public int ClassID { get; set; }

        public Class Class { get; set; }
    }
}