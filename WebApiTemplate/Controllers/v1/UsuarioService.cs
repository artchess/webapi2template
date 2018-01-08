using System.Collections.Generic;
using WebApiTemplate.Models;

namespace WebApiTemplate.Controllers.v1
{
    public class UsuarioService
    {
        public List<Usuario> ObtenListaUsuarios()
        {
            var listaUsuarios = new List<Usuario>
            {
                new Usuario()
                {
                    Id = 1,
                    Email = "alberto@microsoft.com",
                    Nombre = "Albergo",
                    Apellido = "Gaona"
                },
                new Usuario()
                {
                    Id = 2,
                    Email = "hugo@microsoft.com",
                    Nombre = "Hugo",
                    Apellido = "Salas"
                },
                new Usuario()
                {
                    Id = 3,
                    Email = "pedro@microsoft.com",
                    Nombre = "Pedro",
                    Apellido = "Garduño"
                },
                new Usuario()
                {
                    Id = 4,
                    Email = "paco@microsoft.com",
                    Nombre = "Paco",
                    Apellido = "Dominguez"
                },
                new Usuario()
                {
                    Id = 5,
                    Email = "luis@microsoft.com",
                    Nombre = "Luis",
                    Apellido = "Vilchis"
                },
                new Usuario()
                {
                    Id = 6,
                    Email = "ernesto@microsoft.com",
                    Nombre = "Ernesto",
                    Apellido = "Aguirre"
                },
                new Usuario()
                {
                    Id = 7,
                    Email = "mariana@microsoft.com",
                    Nombre = "Mariana",
                    Apellido = "Domingo"
                },
                new Usuario()
                {
                    Id = 8,
                    Email = "paola@microsoft.com",
                    Nombre = "Paola",
                    Apellido = "Hernandez"
                },
                new Usuario()
                {
                    Id = 9,
                    Email = "antonio@microsoft.com",
                    Nombre = "Antonio",
                    Apellido = "Aguilar"
                },
                new Usuario()
                {
                    Id = 10,
                    Email = "hugo@microsoft.com",
                    Nombre = "Hugo",
                    Apellido = "Quiroz"
                },
                new Usuario()
                {
                    Id = 11,
                    Email = "edmundo@microsoft.com",
                    Nombre = "Edmundo",
                    Apellido = "Olivares"
                },
                new Usuario()
                {
                    Id = 12,
                    Email = "claudia@microsoft.com",
                    Nombre = "Claudia",
                    Apellido = "Ferreiro"
                },
            };
            return listaUsuarios;
        }
    }
}