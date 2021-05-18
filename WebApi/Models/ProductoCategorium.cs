using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class ProductoCategorium
    {
        public long Id { get; set; }
        public long ProductoId { get; set; }
        public long CategoriaId { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
