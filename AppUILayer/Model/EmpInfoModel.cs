using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppUILayer.Model
{
    public class EmpInfoModel
    {
        [Key]
        [EmailAddress(ErrorMessage = "Not a valid email id")]
        [Display(Name = "EmailID:")]
        public string EmailId { get; set; }
        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Joining:")]
        public DateTime DateOfJoining { get; set; }
        [Required]
        //[DataType(DataType.Password)]
        [Display(Name = "Pass-Code:")]
        public int PassCode { get; set; }
    }
}