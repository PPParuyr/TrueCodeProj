﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCodeProj.Models
{
    public class TagToUser
    {
        [Key]
        public Guid EntityId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Required]
        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }

}
