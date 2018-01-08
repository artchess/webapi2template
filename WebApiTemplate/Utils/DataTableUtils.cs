using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using WebApiTemplate.Models;

namespace WebApiTemplate.Utils
{
    public static class DataTableUtils
    {
        public static List<TEntity>  Ordenar<TEntity>(RequestPaginado param, List<TEntity> listaUsuarios)
        {
            var propiedades = typeof(TEntity).GetProperties();

            //por cada propiedad revisa si hay que aplicar ordenamiento
            foreach (var propertyInfo in propiedades)
            {
                if (param.Columns[param.Order[0].Column].Data.ToUpper() == propertyInfo.Name.ToUpper() &&
                    param.Order[0].Dir == "asc")
                    listaUsuarios = listaUsuarios.OrderBy(x => x.GetType().GetProperty(propertyInfo.Name)?.GetValue(x, null))
                        .ToList();
                if (param.Columns[param.Order[0].Column].Data.ToUpper() == propertyInfo.Name.ToUpper() &&
                    param.Order[0].Dir == "desc")
                    listaUsuarios = listaUsuarios
                        .OrderByDescending(x => x.GetType().GetProperty(propertyInfo.Name)?.GetValue(x, null)).ToList();
            }

            return listaUsuarios;
        }

        public static List<TEntity> FiltrarPorBusqueda<TEntity>(RequestPaginado param, List<TEntity> lista)
        {
            if (string.IsNullOrEmpty(param.Search.Value)) return lista;

            Expression<Func<TEntity, bool>> expr = x => false;
            var propiedades = typeof(TEntity).GetProperties();

            //Por cada propiedad hace el filtrado
            foreach (var propertyInfo in propiedades)
            {
                //Se usa LinqKit para poder usar metodo Or
                expr = expr.Or(x => x.GetType().GetProperty(propertyInfo.Name).GetValue(x, null) != null &&
                                    x.GetType().GetProperty(propertyInfo.Name).GetValue(x, null).ToString()
                                        .Contains(param.Search.Value));
            }

            lista = lista.AsQueryable()
                .Where(expr)
                .ToList();

            return lista;
        }
    }
}