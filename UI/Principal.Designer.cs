using System.ComponentModel;
using System.Windows.Forms;

namespace UI
{
    partial class Principal
    {
        private IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        
        private void InitializeComponent()
        {
            // Crear TabControl
            ClientSize = new System.Drawing.Size(800, 400);
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // Crear las pestanias
            TabPage tab1 = new TabPage("Articulos");
            TabPage tab2 = new TabPage("Marcas");
            TabPage tab3 = new TabPage("Categorias");

            // Instanciar UserControls
            Articulos vistaClientes = new Articulos();
            vistaClientes.Dock = DockStyle.Fill;
            tab1.Controls.Add(vistaClientes);
            
            Marcas vistaMarcas = new Marcas();
            vistaMarcas.Dock = DockStyle.Fill;
            tab2.Controls.Add(vistaMarcas);
            
            Categorias vistaCategorias = new Categorias();
            vistaCategorias.Dock = DockStyle.Fill;
            tab3.Controls.Add(vistaCategorias);

            // Agregar pestañas
            tabControl.TabPages.Add(tab1);
            tabControl.TabPages.Add(tab2);
            tabControl.TabPages.Add(tab3);

            // Agregar TabControl al form
            this.Controls.Add(tabControl);
        }

        #endregion
    }
}