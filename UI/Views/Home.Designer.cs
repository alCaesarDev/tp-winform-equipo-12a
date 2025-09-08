using System.ComponentModel;
using System.Windows.Forms;

namespace UI.Views
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

            // Crear las pestañas
            TabPage tab1 = new TabPage("Articulos");
            TabPage tab2 = new TabPage("Marcas");
            TabPage tab3 = new TabPage("Categorias");

            // Instanciar UserControls
            Listado vistaClientes = new Listado();
            vistaClientes.Dock = DockStyle.Fill; // Para que ocupe todo el tab
            tab1.Controls.Add(vistaClientes);

            // VistaProductos vistaProductos = new VistaProductos();
            // vistaProductos.Dock = DockStyle.Fill;
            // tab2.Controls.Add(vistaProductos);

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