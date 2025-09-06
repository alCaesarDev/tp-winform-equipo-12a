using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;
using Infraestructura;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = null;

            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = @"
                SELECT A.Id          AS Id,
                       Codigo,
                       Nombre,
                       A.Descripcion,
                       M.Descripcion   AS MarcaDescripcion,
                       C.Descripcion AS CategoriaDescripcion,
                       Precio,
                       IdMarca,
                       IdCategoria
                FROM ARTICULOS A
                         JOIN CATEGORIAS C ON C.Id = A.IdCategoria
                         JOIN MARCAS M ON M.Id = A.IdMarca 
                ";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)lector["IdCategoria"];
                    categoria.Descripcion = lector["CategoriaDescripcion"].ToString();

                    Marca marca = new Marca();
                    marca.Id = (int)lector["IdMarca"];
                    marca.Descripcion = lector["MarcaDescripcion"].ToString();

                    Articulo articulo = new Articulo
                    {
                        Id = (int)lector["Id"],
                        Codigo = lector["Codigo"].ToString(),
                        Nombre = lector["Nombre"].ToString(),
                        Descripcion = lector["Descripcion"].ToString(),
                        Precio = (decimal)lector["Precio"],
                        IdMarca = (int)lector["IdMarca"],
                        IdCategoria = (int)lector["IdCategoria"],
                        Marca = marca,
                        Categoria = categoria
                    };

                    lista.Add(articulo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos", ex);
            }
            finally
            {
                conexion?.Close();
            }

            return lista;
        }
    }
}