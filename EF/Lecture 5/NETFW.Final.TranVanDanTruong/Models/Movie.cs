using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NETFW.Final.TranVanDanTruong.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter title of movie")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter length of movie")]
        public double Length { get; set; }

        [Required(ErrorMessage = "Enter year of movie")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Enter plot outline of movie")]
        public string PlotOuline { get; set; }

        [Required(ErrorMessage = "Enter genre of movie")]
        public string Genre { get; set; }

        /// <summary>
        /// Create foreign key
        /// </summary>

        [Required]
        public int DirectorID { get; set; }

        [Required]
        public int ProductionCompanyID { get; set; }

        [ForeignKey("DirectorID")]
        public Director Director { get; set; }

        [ForeignKey("ProductionCompanyID")]
        public ProductionCompany ProductionCompany { get; set; }

        /// <summary>
        /// Many-to-Many Relationship
        /// </summary>
        public virtual ICollection<Actor> Actors { get; set; }
    }
}