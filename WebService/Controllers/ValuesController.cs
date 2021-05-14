using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public Response Get()
        {
            Response Result = new Response();
            try
            {
                using (Models.StoreContext Conexion = new Models.StoreContext())
                {
                    var array = Conexion.Productos.Where(p => p.Estado == true).ToList();

                    if (array.Count > 0)
                    {
                        Result.Success = true;
                        Result.Message = "registros encontrados";
                        Result.Data = array;
                    }
                    else
                    {
                        Result.Success = false;
                        Result.Message = "no hay registros";
                        Result.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }
            return Result;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Response Get(int id)
        {
            Response Result = new Response();
            try
            {
                using (Models.StoreContext Conexion = new Models.StoreContext())
                {
                    var item = Conexion.Productos.Where(p => p.Id == id && p.Estado == true).FirstOrDefault();

                    if (item != null)
                    {
                        Result.Success = true;
                        Result.Message = "registro encontrado";
                        Result.Data = item;
                    }
                    else
                    {
                        Result.Success = false;
                        Result.Message = "registro no encontrado";
                        Result.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }
            return Result;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Response Post([FromBody] string value)
        {
            Response Result = new Response();
            try
            {
                using (Models.StoreContext Conexion = new Models.StoreContext())
                {
                    var result = Conexion.Productos.Where(p => p.Estado == true).ToList();
                }
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }
            return Result;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] string value)
        {
            Response Result = new Response();
            try
            {
                using (Models.StoreContext Conexion = new Models.StoreContext())
                {
                    var result = Conexion.Productos.Where(p => p.Estado == true).ToList();
                }
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }
            return Result;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            Response Result = new Response();
            try
            {
                using (Models.StoreContext Conexion = new Models.StoreContext())
                {
                    var result = Conexion.Productos.Where(p => p.Estado == true).ToList();
                }
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
            }
            return Result;
        }
    }
}
