using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Categorium
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
