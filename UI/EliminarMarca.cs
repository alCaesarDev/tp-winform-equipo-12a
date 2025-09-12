using Dominio;
using Negocio;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class EliminarMarca : Form
    {
        private readonly Marca marcaAEliminar;

        public EliminarMarca(Marca marca)
        {
            InitializeComponent();
            marcaAEliminar = marca;
            this.Load += new System.EventHandler(this.EliminarMarca_Load);
        }

        private void EliminarMarca_Load(object sender, EventArgs e)
        {
            if (marcaAEliminar != null)
            {
                txtbDescripcionEliminarMarca.Text = marcaAEliminar.Descripcion;
                txtbDescripcionEliminarMarca.ReadOnly = true;
            }


        }

        private void button1_Click(object sender, EventArgs e) // Botón Eliminar
        {
            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminar(marcaAEliminar.Id);
                DialogResult = DialogResult.OK;
                Close();
                MessageBox.Show("¡Eliminado exitosamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar la marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Abort;



                Close();

            }
        }

        private void button2_Click(object sender, EventArgs e) // Botón Cancelar
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}