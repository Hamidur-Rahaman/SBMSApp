﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMProjectModel.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [StringLength(10)]
        public string Password { get; set; }
        public int StatusId { get; set; }
    }
}
