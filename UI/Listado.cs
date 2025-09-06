using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace UI
{
    public partial class Listado : Form
    {
        private List<Articulo> articulos;
        private ArticuloView articuloSeleccionado;

        public Listado()
        {
            InitializeComponent();
        }

        /**
         * Cargo los articulos para mostrar la tabla
         */
        private void Cargar(object sender, EventArgs e)
        {
            try
            {
                var articuloNegocio = new ArticuloNegocio();
                articulos = articuloNegocio.Listar();
                var articulosView = articulos.Select(a => new ArticuloView
                {
                    Id = a.Id,
                    Codigo = a.Codigo,
                    Nombre = a.Nombre,
                    Descripcion = a.Descripcion,
                    Marca = a.Marca?.Descripcion,
                    Categoria = a.Categoria?.Descripcion,
                    Precio = a.Precio.ToString("C2")
                }).ToList();

                tabla.DataSource = articulosView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClickEnCelda(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // me fijo que no haya clickeado en el header
            {
                //agarro el articulo de la celda
                articuloSeleccionado = (ArticuloView)tabla.Rows[e.RowIndex].DataBoundItem;
                botonVer.Enabled = true;
                botonEditar.Enabled = true;
                botonEliminar.Enabled = true;
            }
        }

        private void BotonCrearClick(object sender, EventArgs e)
        {
            MessageBox.Show("Click en CREAR");
        }

        private void BotonEditarClick(object sender, EventArgs e)
        {
            MessageBox.Show($"Editar articulo con id {articuloSeleccionado.Id.ToString()}");
        }
        
        private void BotonVerClick(object sender, EventArgs e)
        {
            MessageBox.Show($"Ver articulo con id {articuloSeleccionado.Id.ToString()}");
        }
    }
}