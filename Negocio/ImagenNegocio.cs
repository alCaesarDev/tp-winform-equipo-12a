using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;
using Infraestructura;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> ListarPorArticulo(int articuloId)
        {
            List<Imagen> lista = new List<Imagen>();
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader lector = null;

            try
            {
                conexion = BaseDeDatos.ObtenerConexion();
                string consulta = "SELECT Id, IdArticulo, Url FROM IMAGENES WHERE IdArticulo = @idArticulo";

                comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@idArticulo", articuloId);

                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Imagen imagen = new Imagen
                    {
                        Id = (int)lector["Id"],
                        IdArticulo = (int)lector["IdArticulo"],
                        ImagenUrl = lector["Url"].ToString()
                    };

                    lista.Add(imagen);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar imágenes", ex);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }

            return lista;
        }
    }
}