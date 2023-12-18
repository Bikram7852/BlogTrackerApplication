using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppUILayer.Model
{
    public class AdminInfoModel
    {
        [Key]
        [EmailAddress(ErrorMessage = "Not a valid email id")]
        public string EmailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}