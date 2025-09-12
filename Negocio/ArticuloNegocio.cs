using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
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

        public void agregar(Articulo nuevo)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) " + "VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@idMarca", nuevo.Marca.Id);
                comando.Parameters.AddWithValue("@idCategoria", nuevo.Categoria.Id);
                comando.Parameters.AddWithValue("@precio", nuevo.Precio);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Errror al  agregar el articulo",ex);

            }
            finally
            {
                conexion?.Close();
            }
        }
    
    
        public Articulo buscarPorId(int id)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = @"SELECT A.Id, Codigo, Nombre, A.Descripcion,M.Descripcion 
                                  AS MarcaDescripcion, C.Descripcion AS CategoriaDescripcion,
                                  Precio, IdMarca ,IdCategoria FROM ARTICULOS A JOIN CATEGORIAS C ON C.Id = A.IdCategoria
                                  JOIN MARCAS M ON M.Id = A.IdMarca
                                  WHERE A.Id = @id";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id" , id);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)lector["IdCategoria"];
                    categoria.Descripcion =lector["CategoriaDescripcion"].ToString();
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
                    return articulo;




                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el articulo por ID", ex);
                
            }
            finally
            {
                conexion?.Close();
            }

        }
    
    
    
    
    
    
    
    }
}