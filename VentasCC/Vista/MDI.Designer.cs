
namespace CapaVistaMVentasCC
{
    partial class MDI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cerarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inventariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tipoInventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tipoMovimientoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gestiónDeMovimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.catalogosToolStripMenuItem,
            this.procesosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem,
            this.cerarSesiónToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
			this.archivoToolStripMenuItem.Text = "Archivo";
			// 
			// salirToolStripMenuItem
			// 
			this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
			this.salirToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.salirToolStripMenuItem.Text = "Salir";
			this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
			// 
			// cerarSesiónToolStripMenuItem
			// 
			this.cerarSesiónToolStripMenuItem.Name = "cerarSesiónToolStripMenuItem";
			this.cerarSesiónToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.cerarSesiónToolStripMenuItem.Text = "Cerar Sesión ";
			this.cerarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerarSesiónToolStripMenuItem_Click);
			// 
			// catalogosToolStripMenuItem
			// 
			this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.inventariosToolStripMenuItem});
			this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
			this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
			this.catalogosToolStripMenuItem.Text = "Catalogos";
			// 
			// clientesToolStripMenuItem
			// 
			this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
			this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.clientesToolStripMenuItem.Text = "Cuentas Contables";
			this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
			// 
			// inventariosToolStripMenuItem
			// 
			this.inventariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoInventarioToolStripMenuItem,
            this.inventarioToolStripMenuItem});
			this.inventariosToolStripMenuItem.Name = "inventariosToolStripMenuItem";
			this.inventariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.inventariosToolStripMenuItem.Text = "Bancos";
			// 
			// tipoInventarioToolStripMenuItem
			// 
			this.tipoInventarioToolStripMenuItem.Name = "tipoInventarioToolStripMenuItem";
			this.tipoInventarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.tipoInventarioToolStripMenuItem.Text = "Gestión de Bancos";
			this.tipoInventarioToolStripMenuItem.Click += new System.EventHandler(this.tipoInventarioToolStripMenuItem_Click);
			// 
			// inventarioToolStripMenuItem
			// 
			this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
			this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.inventarioToolStripMenuItem.Text = "Cuentas Bancarias";
			this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);
			// 
			// procesosToolStripMenuItem
			// 
			this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidosToolStripMenuItem});
			this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
			this.procesosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.procesosToolStripMenuItem.Text = "Procesos";
			// 
			// pedidosToolStripMenuItem
			// 
			this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipoMovimientoToolStripMenuItem,
            this.gestiónDeMovimientosToolStripMenuItem});
			this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
			this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.pedidosToolStripMenuItem.Text = "Movimiento Bancario";
			this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
			// 
			// tipoMovimientoToolStripMenuItem
			// 
			this.tipoMovimientoToolStripMenuItem.Name = "tipoMovimientoToolStripMenuItem";
			this.tipoMovimientoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.tipoMovimientoToolStripMenuItem.Text = "Tipo Movimiento";
			this.tipoMovimientoToolStripMenuItem.Click += new System.EventHandler(this.tipoMovimientoToolStripMenuItem_Click);
			// 
			// gestiónDeMovimientosToolStripMenuItem
			// 
			this.gestiónDeMovimientosToolStripMenuItem.Name = "gestiónDeMovimientosToolStripMenuItem";
			this.gestiónDeMovimientosToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.gestiónDeMovimientosToolStripMenuItem.Text = "Gestión de Movimientos";
			// 
			// txtUsuario
			// 
			this.txtUsuario.Enabled = false;
			this.txtUsuario.Location = new System.Drawing.Point(688, 0);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(100, 20);
			this.txtUsuario.TabIndex = 5;
			this.txtUsuario.Visible = false;
			// 
			// MDI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Name = "MDI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Prototipo Final";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MDIVentas_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoInventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerarSesiónToolStripMenuItem;
        private System.Windows.Forms.TextBox txtUsuario;
		private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tipoMovimientoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gestiónDeMovimientosToolStripMenuItem;
	}
}