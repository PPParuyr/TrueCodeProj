using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCodeProj.Models
{
    public class Tag
    {
        public Guid TagId { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Domain { get; set; }

        public List<TagToUser> TagToUsers { get; set; }
    }

}
