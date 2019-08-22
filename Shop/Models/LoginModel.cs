﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [UIHint("Input password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
