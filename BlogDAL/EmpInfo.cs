using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class EmpInfo
    {
        [Key]
        [EmailAddress(ErrorMessage = "Not a valid email id")]
        public string EmailId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public int PassCode { get; set; }
        public virtual ICollection<BlogInfo> Blogs { get; set; }
    }
}
