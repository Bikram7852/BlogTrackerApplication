using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class BlogInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BlogId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfCreation { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string BlogUrl { get; set; }
        [EmailAddress(ErrorMessage = "Not a valid email id")]
        public string EmpEmailId { get; set; }
        
        [ForeignKey("EmpEmailId")]
        public virtual EmpInfo Employee { get; set; }
    }
}
