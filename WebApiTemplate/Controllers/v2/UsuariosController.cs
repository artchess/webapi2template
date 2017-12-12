using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Web.Http;

namespace WebApiTemplate.Controllers.v2
{
    /// <summary>
    /// Controlador de usuarios
    /// </summary>
    [ApiVersion("2.0")]
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        /*
         * Mas informacion de ruting: https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
         */

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>Todos los usuarios disponibles.</returns>
        /// <response code="200">Obtención de usuarios satisfactoria.</response>
        [HttpGet, Route("")]
        public IHttpActionResult Get()
        {
            var listaUsuarios = new List<Usuario2>
            {
                new Usuario2()
                {
                    Id = Guid.NewGuid(),
                    Email = "alberto@microsoft.com",
                    Nombre = "Albergo Gaona"
                },
                new Usuario2()
                {
                    Id = Guid.NewGuid(),
                    Email = "Iliana@microsoft.com",
                    Nombre = "Iliana Garduño"
                }
            };

            return Ok(listaUsuarios);
        }

        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <returns>Id del usuario eliminado.</returns>
        /// <response code="200">Eliminación satisfactoria.</response>
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            return Ok(id);
        }

        /// <summary>
        /// Obtener usuario por nombre
        /// </summary>
        /// <returns>El nombre del usuario</returns>
        /// <response code="200">Obtención del usuario satisfactorio.</response>
        [HttpGet, Route("{nombre}")]
        public IHttpActionResult ObtenerPorNombre(string nombre)
        {
            return Ok(nombre);
        }
    }

    public class Usuario2
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
