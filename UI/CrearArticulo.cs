using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace UI
{
    public partial class CrearArticulo : Form
    {
        public CrearArticulo()
        {
            InitializeComponent();
        }

        private void CrearArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.Listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.Listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelarArticulo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardarArticulo_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (string.IsNullOrWhiteSpace(txtCrearCodigoArticulo.Text) ||
                    string.IsNullOrWhiteSpace(txtCrearNombreArticulo.Text))
                {
                    MessageBox.Show("Los campos codigo y nombre son obligatorios");
                    return;
                }

                nuevo.Codigo = txtCrearCodigoArticulo.Text;
                nuevo.Nombre = txtCrearNombreArticulo.Text;
                nuevo.Descripcion = txtCrearDescripcionArticulo.Text;

                if (!decimal.TryParse(txtCrearPrecioArticulo.Text, out decimal precio))
                {
                    MessageBox.Show("Por favor ,ingrese un numerovalido en el campo precio");
                    return;
                }

                nuevo.Precio = precio;
                nuevo.Marca = (Marca)cboMarca.SelectedItem;
                nuevo.Categoria = (Categoria)cboCategoria.SelectedItem;
                negocio.agregar(nuevo);
                MessageBox.Show("Articulo agregado Exitosamente");
                Close();
            }


            
            
            catch (Exception ex)
            {
               
                MessageBox.Show("Ocurrio un error al cargar los datos"+ ex.Message);

            }
        }
    }
}
