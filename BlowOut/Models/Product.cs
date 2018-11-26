using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Instrument ID")]
        public int instrumentID { get; set; }
        [DisplayName("Instrument Name")]
        public string desc { get; set; }
        [DisplayName("New/Used")]
        public string type { get; set; }
        [DisplayName("Price")]
        public int price { get; set; }
        [DisplayName("Image URL")]
        public string image { get; set; }
    }
}