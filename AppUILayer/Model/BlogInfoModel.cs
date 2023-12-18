using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogDAL;

namespace AppUILayer.Model
{
    public class BlogInfoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int BlogId { get; set; }
        [Required]
        [Display(Name = "Title:")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Subject:")]
        public string Subject { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Creation:")]
        public DateTime DateOfCreation { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Blog Url:")]
        public string BlogUrl { get; set; }
        [EmailAddress(ErrorMessage = "Not a valid email id")]
        public string EmpEmailId { get; set; }
        // Property for selected user type
        public UserType SelectedUserType { get; set; }

        // Property for available user types (used for dropdown list)
        public SelectList AvailableUserTypes { get; set; }
    }
}