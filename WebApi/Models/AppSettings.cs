using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AppSettings
    {
        public string Secreto { get; set; }
    }

    public class AuthRequest
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Password { get; set;  }
    }
}
