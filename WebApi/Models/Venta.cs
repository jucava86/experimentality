using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Venta
    {
        public long Id { get; set; }
        public long ProductoId { get; set; }
        public long Cantidad { get; set; }
        public double Valor { get; set; }
        public int Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}
