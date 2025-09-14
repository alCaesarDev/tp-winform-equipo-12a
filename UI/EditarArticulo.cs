using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class EditarArticulo : Form
    {
        private Articulo articulo = null;
        public EditarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Editar Articulo";
        }

        private void EditarArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cboEditarArticuloCategoria.DataSource = categoriaNegocio.Listar();
                cboEditarArticuloCategoria.ValueMember = "Id";
                cboEditarArticuloCategoria.DisplayMember = "Descripcion";
                cboMarcaEditarArticulo.DataSource = marcaNegocio.Listar();
                cboMarcaEditarArticulo.ValueMember = "Id";
                cboMarcaEditarArticulo.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtEditarCodigoArticulo.Text = articulo.Codigo;
                    txtEditarNombreArticulo.Text = articulo.Nombre;
                    txtEditarDescripcionArticulo.Text = articulo.Descripcion;
                    txtEditarPrecioArticulo.Text = articulo.Precio.ToString();
                    cboEditarArticuloCategoria.SelectedValue = articulo.Categoria.Id;
                    cboMarcaEditarArticulo.SelectedValue = articulo.Marca.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGuardarArticuloEditado_Click(object sender, EventArgs e)
        {
           ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if(string.IsNullOrWhiteSpace(txtEditarCodigoArticulo.Text) || string.IsNullOrEmpty(txtEditarNombreArticulo.Text))
                {
                    MessageBox.Show("Los campos codigo y nombre son obligatorios");
                    return;
                }

                if(!decimal.TryParse(txtEditarPrecioArticulo.Text, out decimal precio))
                {
                    MessageBox.Show("Ingrese un numero valido en campo precio");
                    return;
                }

                articulo.Codigo = txtEditarCodigoArticulo.Text;
                articulo.Nombre = txtEditarNombreArticulo.Text;
                articulo.Descripcion = txtEditarDescripcionArticulo.Text;
                articulo.Precio = precio;
                articulo.Marca = (Marca)cboMarcaEditarArticulo.SelectedItem;
                articulo.Categoria = (Categoria)cboEditarArticuloCategoria.SelectedItem;
                
                negocio.modificar(articulo);
                MessageBox.Show("Modificado exitosamente");
                Close();

            }

            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio un error: " + ex.Message);
            }
        }
    }
}