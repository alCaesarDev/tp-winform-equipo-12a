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
    public class Categorias : Listado<CategoriaDto>
    {
        /**
         * Cargo los categorias para mostrar la tabla
         */
        protected override List<CategoriaDto> ObtenerRegistros()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            List<Categoria> categorias = categoriaNegocio.Listar();

            //Mapeo los resultados de la db con el dto
            return categorias.Select(a => new CategoriaDto
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
            }).ToList();
        }

        protected override string ObtenerTitulo()
        {
            return "Categorias";
        }

        protected override void ClickBotonVer(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca van los detalles de la categoria {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonEditar(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va el modal de edicion de la categoria {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonEliminar(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va un modal de confirmacion de eliminacion de la categoria {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonCrear(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va el modal de creacion.");
        }
    }
}