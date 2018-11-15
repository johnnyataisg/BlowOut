using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int clientID { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [RegularExpression(@"^[A-Z]([a-z])*([\s][A-Z][a-z]*)*", ErrorMessage = "Please enter a valid first name")]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [RegularExpression(@"^[A-Z]([a-z])*([\s][A-Z][a-z]*)*", ErrorMessage = "Please enter a valid last name")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Please enter your address")]
        [DisplayName("Street Address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        [RegularExpression(@"^[A-Z][a-z]*", ErrorMessage = "Please enter a valid city")]
        [DisplayName("City")]
        public string city { get; set; }
        [Required(ErrorMessage = "Please enter your state")]
        [RegularExpression(@"^[A-Z]([A-Z]|[a-z])*", ErrorMessage = "Please enter a valid state")]
        [DisplayName("State")]
        public string state { get; set; }
        [Required(ErrorMessage = "Please enter your zip code")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Please enter a valid zip code")]
        [DisplayName("Zip Code")]
        public string zip { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [DisplayName("Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Please enter a valid phone number")]
        [DisplayName("Phone Number")]
        public string phone { get; set; }

        [ForeignKey("Product")]
        public virtual int? instrumentID { get; set; }
        public virtual Product Product { get; set; }
    }
}