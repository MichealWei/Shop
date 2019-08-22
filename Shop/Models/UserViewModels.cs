using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
