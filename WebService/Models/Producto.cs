using System;
using System.Collections.Generic;

#nullable disable

namespace WebService.Models
{
    public partial class Producto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Descuento { get; set; }
        public string ImgFront { get; set; }
        public string ImgBack { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
