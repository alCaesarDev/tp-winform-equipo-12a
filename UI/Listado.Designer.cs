namespace UI
{
    partial class Listado
    {
        private System.ComponentModel.IContainer components = null;

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
            this.tabla = new System.Windows.Forms.DataGridView();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.botonCrear = new System.Windows.Forms.Button();
            this.botonVer = new System.Windows.Forms.Button();
            this.botonEditar = new System.Windows.Forms.Button();
            this.botonEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitulo.Location = new System.Drawing.Point(0, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(800, 40);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Gestión de Artículos";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabla
            // 
            this.tabla.AllowUserToAddRows = false;
            this.tabla.AllowUserToDeleteRows = false;
            this.tabla.MultiSelect = false;
            this.tabla.ReadOnly = true;
            this.tabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabla.Location = new System.Drawing.Point(0, 40);
            this.tabla.Name = "tabla";
            this.tabla.RowTemplate.Height = 25;
            this.tabla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tabla.Size = new System.Drawing.Size(800, 300);
            this.tabla.TabIndex = 0;
            this.tabla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickEnCelda);
            //
            // panelBotones
            // 
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Height = 50;
            this.panelBotones.Padding = new System.Windows.Forms.Padding(10);
            this.panelBotones.Controls.Add(this.botonEliminar);
            this.panelBotones.Controls.Add(this.botonEditar);
            this.panelBotones.Controls.Add(this.botonVer);
            this.panelBotones.Controls.Add(this.botonCrear);
            this.panelBotones.Name = "panelBotones";
            // 
            // botonCrear
            // 
            this.botonCrear.Text = "Crear";
            this.botonCrear.Dock = System.Windows.Forms.DockStyle.Left;
            this.botonCrear.Width = 100;
            this.botonCrear.Click += new System.EventHandler(this.BotonCrearClick);
            // 
            // botonVer
            // 
            this.botonVer.Text = "Ver";
            this.botonVer.Dock = System.Windows.Forms.DockStyle.Left;
            this.botonVer.Width = 100;
            this.botonVer.Enabled = false;
            this.botonVer.Click += new System.EventHandler(this.BotonVerClick);
            // 
            // botonEditar
            // 
            this.botonEditar.Text = "Editar";
            this.botonEditar.Dock = System.Windows.Forms.DockStyle.Left;
            this.botonEditar.Width = 100;
            this.botonEditar.Enabled = false;
            this.botonEditar.Click += new System.EventHandler(this.BotonEditarClick);
            // 
            // botonEliminar
            // 
            this.botonEliminar.Text = "Eliminar";
            this.botonEliminar.Dock = System.Windows.Forms.DockStyle.Left;
            this.botonEliminar.Width = 100;
            this.botonEliminar.Enabled = false;
            // 
            // Listado
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400); // tamaño inicial fijo
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.labelTitulo);
            this.Name = "Listado";
            this.Text = "Gestión de Artículos";
            this.Load += new System.EventHandler(this.Cargar);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button botonCrear;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonEditar;
        private System.Windows.Forms.Button botonVer;
    }
}
