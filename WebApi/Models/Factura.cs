using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Factura
    {
        public long Id { get; set; }
        public string Nit { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Referencia { get; set; }
    }
}
