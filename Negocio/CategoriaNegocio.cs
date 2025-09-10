using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;
using Infraestructura;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public Categoria Buscar(int id)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                var consulta = "SELECT Id, Descripcion FROM CATEGORIAS WHERE Id = @id";

                var comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", id);

                var lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    return new Categoria()
                    {
                        Id = (int)lector["Id"],
                        Descripcion = lector["Descripcion"].ToString()
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar categoria", ex);
            }
            finally
            {
                conexion?.Close();
            }
        }

        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            SqlConnection conexion = null;

            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = @"
                SELECT Id,
                       Descripcion
                FROM CATEGORIAS 
                ";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Categoria categoria = new Categoria
                    {
                        Id = (int)lector["Id"],
                        Descripcion = lector["Descripcion"].ToString(),
                    };

                    lista.Add(categoria);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar categorias", ex);
            }
            finally
            {
                conexion?.Close();
            }

            return lista;
        }
    }
}