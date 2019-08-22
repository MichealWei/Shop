using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Shop.Models
{
    public class Customer : IdentityUser
    {
        [Required, MaxLength(56)]
        public string Name { get; set; }
        [Required, MaxLength(56)]
        public string SurName { get; set; }
        [Required, MaxLength(56)]
        public string Address { get; set; }
        //[Required, MaxLength(56)]
        //public string Email { get; set; }
        [Required, MaxLength(56)]
        public string Telefone { get; set; }
        //[Required, MaxLength(56)]
        //public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
