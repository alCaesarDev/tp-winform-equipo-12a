using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dominio;
using Negocio;
using UI.Abstactos;
using UI.DTO;

namespace UI
{
    public class Articulos : Listado<ArticuloDto>
    {
        /**
         * Cargo los articulos para mostrar la tabla
         */
        protected override List<ArticuloDto> ObtenerRegistros()
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            List<Articulo> articulos = articuloNegocio.Listar();

            //Mapeo los resultados de la db con el dto
            return articulos.Select(a => new ArticuloDto
            {
                Id = a.Id,
                Codigo = a.Codigo,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                Marca = a.Marca?.Descripcion,
                Categoria = a.Categoria?.Descripcion,
                Precio = a.Precio.ToString("C2")
            }).ToList();
        }

        protected override string ObtenerTitulo()
        {
            return "Articulos";
        }

        protected override void ClickBotonVer(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca van los detalles del articulo {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonEditar(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va el modal de edicion del articulo {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonEliminar(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va un modal de confirmacion de eliminacion del articulo {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonCrear(object sender, EventArgs e)
        {

            MessageBox.Show($"Aca va el modal de creacion.");
        }
    }
}