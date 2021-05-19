using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        // GET: api/<ProductosController>
        [HttpGet]
        public Response Get()
        {
            Response result = new Response();
            try
            {
                using (StoreContext conexion = new StoreContext())
                {
                    var item = conexion.Productos.Where(p => p.Estado == true).ToList();

                    if (item.Count > 0)
                    {
                        result.Success = true;
                        result.Message = "se encontraron registros";
                        result.Data = item;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "no se encontraron registros";
                        result.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public Response Get(int id)
        {
            Response result = new Response();
            try
            {
                using (StoreContext conexion = new StoreContext())
                {
                    Producto item = conexion.Productos.Where(p => p.Id == id && p.Estado == true).FirstOrDefault();

                    if (item != null)
                    {
                        result.Success = true;
                        result.Message = "se encontraron registros";
                        result.Data = item;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "no se encontraron registros";
                        result.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }

        // GET api/<ProductosController>/5
        [Route("ConsultarNombre")]
        [HttpGet]
        [Authorize]
        public Response ConsultarNombre(string nombre)
        {
            Response result = new Response();
            try
            {
                using (StoreContext conexion = new StoreContext())
                {
                    var item = conexion.Productos.Where(p => p.Nombre.Contains(nombre) && p.Estado == true).ToList();

                    if (item.Count > 0)
                    {
                        result.Success = true;
                        result.Message = "se encontraron registros";
                        result.Data = item;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "no se encontraron registros";
                        result.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }

        // POST api/<ProductosController>
        [HttpPost]
        public Response Post([FromBody] IProducto producto)
        {
            Response result = new Response();
            try
            {
                using (StoreContext conexion = new StoreContext())
                {
                    Producto item = new Producto();
                    item.Nombre = producto.Nombre;
                    item.Precio = producto.Precio;
                    item.Descuento = producto.Descuento;
                    item.ImgFront = producto.ImgFront;
                    item.ImgBack = producto.ImgBack;
                    item.Estado = true;
                    item.FechaCreacion = DateTime.Now;

                    conexion.Productos.Add(item);
                    conexion.SaveChanges();

                    result.Success = true;
                    result.Message = "se guardo registros";
                    result.Data = item;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] IProducto producto)
        {
            Response result = new Response();
            try
            {
                using (StoreContext conexion = new StoreContext())
                {
                    Producto item = conexion.Productos.Where(p => p.Id == id && p.Estado == true).FirstOrDefault();

                    if (item != null)
                    {
                        item.Nombre = producto.Nombre;
                        item.Precio = producto.Precio;
                        item.Descuento = producto.Descuento;
                        item.ImgFront = producto.ImgFront;
                        item.ImgBack = producto.ImgBack;

                        conexion.SaveChanges();

                        result.Success = true;
                        result.Message = "se guardo registros";
                        result.Data = item;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "no se guardo registros";
                        result.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            Response result = new Response();
            try
            {
                using (StoreContext conexion = new StoreContext())
                {
                    var item = conexion.Productos.Where(p => p.Id == id && p.Estado == true).FirstOrDefault();

                    if (item != null)
                    {
                        item.Estado = false;
                        conexion.SaveChanges();

                        result.Success = true;
                        result.Message = "se borro el registros";
                        result.Data = null;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "no se borro el registros";
                        result.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }


        // GET api/<ProductosController>/5
        [Route("CargueInicial")]
        [HttpGet]
        public Response CargueInicial()
        {
            Response result = new Response();
            try
            {
                using (StoreContext conexion = new StoreContext())
                {
                    List<Categorium> arrayCategorias = new List<Categorium>();
                    arrayCategorias.Add(new Categorium { Nombre = "Hombre", FechaCreacion = DateTime.Now, Estado = true });
                    arrayCategorias.Add(new Categorium { Nombre = "Mujer", FechaCreacion = DateTime.Now, Estado = true });
                    arrayCategorias.Add(new Categorium { Nombre = "Junior", FechaCreacion = DateTime.Now, Estado = true });
                    arrayCategorias.Add(new Categorium { Nombre = "Niños", FechaCreacion = DateTime.Now, Estado = true });
                    arrayCategorias.Add(new Categorium { Nombre = "Oferta", FechaCreacion = DateTime.Now, Estado = true });
                    arrayCategorias.Add(new Categorium { Nombre = "Accesorios", FechaCreacion = DateTime.Now, Estado = true });

                    conexion.Categoria.AddRange(arrayCategorias);
                    conexion.SaveChanges();

                    List<Producto> arrayProductos = new List<Producto>();
                    arrayProductos.Add(new Producto { Nombre = "Blusa rosa", Precio = 34.5, Descuento = 5, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "Pantalon gris dama", Precio = 22, Descuento = 5, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "Chaleco", Precio = 15, Descuento = 0, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "Chaqueta", Precio = 60, Descuento = 30, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "Blusa verde", Precio = 34.5, Descuento = 5, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "Pantalon jean", Precio = 22, Descuento = 5, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "camiseta", Precio = 15, Descuento = 0, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "zapatos", Precio = 60, Descuento = 30, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "gorra", Precio = 34.5, Descuento = 5, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "camisa niño", Precio = 22, Descuento = 5, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "cinturon", Precio = 15, Descuento = 0, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });
                    arrayProductos.Add(new Producto { Nombre = "reloj", Precio = 60, Descuento = 30, ImgFront = "", ImgBack = "", FechaCreacion = DateTime.Now, Estado = true });

                    conexion.Productos.AddRange(arrayProductos);
                    conexion.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Data = null;
            }
            return result;
        }

        public static async Task<bool> ProdutoExiste(string nombre)
        {
            bool result = false;
            var tarea = new Task(() => {
                using (StoreContext conexion = new StoreContext())
                {
                    var validar = conexion.Productos.Where(p => p.Nombre == nombre && p.Estado == true).FirstOrDefault();
                    if (validar != null)
                    {
                        result = true;
                    }
                }
            });

            tarea.Start();
            await tarea;

            return result;
        }
    }
}
