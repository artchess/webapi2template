using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Routing;
using LinqKit;
using Microsoft.Web.Http;
using WebApiTemplate.Models;
using WebApiTemplate.Utils;

namespace WebApiTemplate.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0", Deprecated = true)]
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly UsuarioService _usuarioService = new UsuarioService();
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
            return Ok(_usuarioService.ObtenListaUsuarios());
        }

        /// <summary>
        /// Obtiene la lista de usuarios con opción de paginación
        /// </summary>
        /// <param name="paginado"></param>
        /// <param name="param"></param>
        /// <returns>La página solicitada, si no se manda paginado = true entonces manda toda la lista de usuarios</returns>
        [HttpPost, Route("")]
        public IHttpActionResult PostGet(bool paginado, RequestPaginado param)
        {
            if (paginado == false) // Si no se manda paginado en true entonces obtiene todos los datos sin paginar
                return Get();

            var listaUsuarios = _usuarioService.ObtenListaUsuarios();

            var totalUs = listaUsuarios.Count;

            listaUsuarios = DataTableUtils.FiltrarPorBusqueda(param, listaUsuarios);

            listaUsuarios = DataTableUtils.Ordenar(param, listaUsuarios);

            var datosPagina = listaUsuarios
                                    .Skip(param.Start)
                                    .Take(param.Length)
                                    .ToList();

            var result = new ResultadoPaginado<Usuario>()
            {
                Data = datosPagina,
                Draw = param.Draw,
                RecordsFiltered = listaUsuarios.Count,
                RecordsTotal = totalUs
            };

            return Ok(result);
        }



        /// <summary>
        /// Elimina un usuario
        /// </summary>
        /// <param name="id">El identificador del usuario.</param>
        /// <returns>Id del usuario eliminado.</returns>
        /// <response code="200">Eliminación satisfactoria.</response>
        [HttpDelete, Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(id);
        }
    }
}
