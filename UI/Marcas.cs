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
    public class Marcas : Listado<MarcaDto>
    {
        /**
         * Cargo los marcas para mostrar la tabla
         */
        protected override List<MarcaDto> ObtenerRegistros()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            List<Marca> marcas = marcaNegocio.Listar();
            return marcas.Select(a => new MarcaDto()
            {
                Id = a.Id,
                Descripcion = a.Descripcion,
            }).ToList();
        }

        protected override string ObtenerTitulo()
        {
            return "Marcas";
        }

        protected override void ClickBotonVer(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca van los detalles de la marca {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonEditar(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va el modal de edicion de la marca {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonEliminar(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va un modal de confirmacion de eliminacion de la marca {RegistroSeleccionado.Id}.");
        }

        protected override void ClickBotonCrear(object sender, EventArgs e)
        {
            MessageBox.Show($"Aca va el modal de creacion.");
        }
    }
}