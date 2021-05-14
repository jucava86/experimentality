using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public partial class IProducto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Descuento { get; set; }
        public string ImgFront { get; set; }
        public string ImgBack { get; set; }
    }
}
