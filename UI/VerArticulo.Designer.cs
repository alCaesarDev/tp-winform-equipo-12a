namespace UI
{
    partial class VerArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblVerPrecio = new System.Windows.Forms.Label();
            this.lblVerCategoria = new System.Windows.Forms.Label();
            this.lblVerMarca = new System.Windows.Forms.Label();
            this.lblVerDescripcion = new System.Windows.Forms.Label();
            this.lblVerNombre = new System.Windows.Forms.Label();
            this.lblVerCodigo = new System.Windows.Forms.Label();
            this.btnCerrarVer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(43, 34);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo:";
            this.lblCodigo.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(39, 77);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
           
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(20, 121);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion:";
       
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(46, 166);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 3;
            this.lblMarca.Text = "Marca:";
           
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(31, 205);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(55, 13);
            this.lblCategoria.TabIndex = 4;
            this.lblCategoria.Text = "Categoria:";
          
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(46, 242);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio:";
            
            // 
            // lblVerPrecio
            // 
            this.lblVerPrecio.Location = new System.Drawing.Point(92, 242);
            this.lblVerPrecio.Name = "lblVerPrecio";
            this.lblVerPrecio.Size = new System.Drawing.Size(143, 15);
            this.lblVerPrecio.TabIndex = 11;
           
            // 
            // lblVerCategoria
            // 
            this.lblVerCategoria.Location = new System.Drawing.Point(93, 205);
            this.lblVerCategoria.Name = "lblVerCategoria";
            this.lblVerCategoria.Size = new System.Drawing.Size(143, 15);
            this.lblVerCategoria.TabIndex = 10;
          
            // 
            // lblVerMarca
            // 
            this.lblVerMarca.Location = new System.Drawing.Point(93, 166);
            this.lblVerMarca.Name = "lblVerMarca";
            this.lblVerMarca.Size = new System.Drawing.Size(143, 15);
            this.lblVerMarca.TabIndex = 9;
           
            // 
            // lblVerDescripcion
            // 
            this.lblVerDescripcion.Location = new System.Drawing.Point(93, 121);
            this.lblVerDescripcion.Name = "lblVerDescripcion";
            this.lblVerDescripcion.Size = new System.Drawing.Size(143, 15);
            this.lblVerDescripcion.TabIndex = 8;
           
            // 
            // lblVerNombre
            // 
            this.lblVerNombre.Location = new System.Drawing.Point(93, 77);
            this.lblVerNombre.Name = "lblVerNombre";
            this.lblVerNombre.Size = new System.Drawing.Size(143, 15);
            this.lblVerNombre.TabIndex = 7;
           
            // 
            // lblVerCodigo
            // 
            this.lblVerCodigo.Location = new System.Drawing.Point(92, 34);
            this.lblVerCodigo.Name = "lblVerCodigo";
            this.lblVerCodigo.Size = new System.Drawing.Size(143, 15);
            this.lblVerCodigo.TabIndex = 6;
          
            // 
            // btnCerrarVer
            // 
            this.btnCerrarVer.Location = new System.Drawing.Point(235, 272);
            this.btnCerrarVer.Name = "btnCerrarVer";
            this.btnCerrarVer.Size = new System.Drawing.Size(127, 61);
            this.btnCerrarVer.TabIndex = 12;
            this.btnCerrarVer.Text = "Cerrar";
            this.btnCerrarVer.UseVisualStyleBackColor = true;
            this.btnCerrarVer.Click += new System.EventHandler(this.btnCerrarVer_Click);
            // 
            // VerArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnCerrarVer);
            this.Controls.Add(this.lblVerPrecio);
            this.Controls.Add(this.lblVerCategoria);
            this.Controls.Add(this.lblVerMarca);
            this.Controls.Add(this.lblVerDescripcion);
            this.Controls.Add(this.lblVerNombre);
            this.Controls.Add(this.lblVerCodigo);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(400, 400);
            this.Name = "VerArticulo";
            this.Text = "VerArticulo";
            this.Load += new System.EventHandler(this.VerArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblVerPrecio;
        private System.Windows.Forms.Label lblVerCategoria;
        private System.Windows.Forms.Label lblVerMarca;
        private System.Windows.Forms.Label lblVerDescripcion;
        private System.Windows.Forms.Label lblVerNombre;
        private System.Windows.Forms.Label lblVerCodigo;
        private System.Windows.Forms.Button btnCerrarVer;
    }
}