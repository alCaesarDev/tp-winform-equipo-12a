using Dominio;
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
    public partial class VerArticulo : Form
    {
        private Articulo articulo;
        public VerArticulo()
        {
            InitializeComponent();
        }
        public VerArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void VerArticulo_Load(object sender, EventArgs e)
        {
         if(this.articulo != null)
            {
                lblVerCodigo.Text = articulo.Codigo;
                lblVerNombre.Text = articulo.Nombre;
                lblVerDescripcion.Text = articulo.Descripcion;
                lblVerMarca.Text = articulo.Marca.Descripcion;
                lblVerCategoria.Text = articulo.Categoria.Descripcion;
                lblVerPrecio.Text = articulo.Precio.ToString("C");

            }
        }

        private void btnCerrarVer_Click(object sender, EventArgs e)
        {
            Close();
        }

     
    }
}
