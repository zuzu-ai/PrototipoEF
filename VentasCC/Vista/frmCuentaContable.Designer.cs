
namespace CapaVistaMVentasCC
{
	partial class frmCuentaContable
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentaContable));
			this.btnAyuda = new System.Windows.Forms.Button();
			this.btnReporte = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.dtgPedidosE = new System.Windows.Forms.DataGridView();
			this.txtnombre = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnlimpiar = new System.Windows.Forms.Button();
			this.btncambioestado = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnValidarencabezado = new System.Windows.Forms.Button();
			this.txtBodega2 = new System.Windows.Forms.TextBox();
			this.cbxBodega2 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.rbnVencida = new System.Windows.Forms.RadioButton();
			this.rbnActiva = new System.Windows.Forms.RadioButton();
			this.txtid = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lblIdcotizacion = new System.Windows.Forms.Label();
			this.lblIdEmpleado = new System.Windows.Forms.Label();
			this.lblIdcliente = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dtgPedidosE)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAyuda
			// 
			this.btnAyuda.Image = ((System.Drawing.Image)(resources.GetObject("btnAyuda.Image")));
			this.btnAyuda.Location = new System.Drawing.Point(93, 5);
			this.btnAyuda.Name = "btnAyuda";
			this.btnAyuda.Size = new System.Drawing.Size(75, 54);
			this.btnAyuda.TabIndex = 19;
			this.btnAyuda.UseVisualStyleBackColor = true;
			this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
			// 
			// btnReporte
			// 
			this.btnReporte.Image = global::CapaVistaMVentasCC.Properties.Resources.reportes;
			this.btnReporte.Location = new System.Drawing.Point(12, 5);
			this.btnReporte.Name = "btnReporte";
			this.btnReporte.Size = new System.Drawing.Size(75, 54);
			this.btnReporte.TabIndex = 18;
			this.btnReporte.UseVisualStyleBackColor = true;
			this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Location = new System.Drawing.Point(469, 52);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(105, 13);
			this.label14.TabIndex = 16;
			this.label14.Text = "Cuentas Registradas";
			// 
			// dtgPedidosE
			// 
			this.dtgPedidosE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgPedidosE.Location = new System.Drawing.Point(338, 68);
			this.dtgPedidosE.Name = "dtgPedidosE";
			this.dtgPedidosE.Size = new System.Drawing.Size(396, 198);
			this.dtgPedidosE.TabIndex = 14;
			this.dtgPedidosE.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtgPedidosE_RowHeaderMouseClick);
			// 
			// txtnombre
			// 
			this.txtnombre.Location = new System.Drawing.Point(85, 34);
			this.txtnombre.Name = "txtnombre";
			this.txtnombre.Size = new System.Drawing.Size(145, 20);
			this.txtnombre.TabIndex = 18;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(4, 34);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(47, 13);
			this.label12.TabIndex = 13;
			this.label12.Text = "Nombre:";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.btnlimpiar);
			this.panel1.Controls.Add(this.btncambioestado);
			this.panel1.Controls.Add(this.btnCancelar);
			this.panel1.Controls.Add(this.btnValidarencabezado);
			this.panel1.Controls.Add(this.txtBodega2);
			this.panel1.Controls.Add(this.cbxBodega2);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.rbnVencida);
			this.panel1.Controls.Add(this.rbnActiva);
			this.panel1.Controls.Add(this.txtid);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.txtnombre);
			this.panel1.Controls.Add(this.lblIdcotizacion);
			this.panel1.Controls.Add(this.lblIdEmpleado);
			this.panel1.Controls.Add(this.lblIdcliente);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(19, 61);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(313, 205);
			this.panel1.TabIndex = 16;
			// 
			// btnlimpiar
			// 
			this.btnlimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnlimpiar.Image")));
			this.btnlimpiar.Location = new System.Drawing.Point(214, 120);
			this.btnlimpiar.Name = "btnlimpiar";
			this.btnlimpiar.Size = new System.Drawing.Size(69, 62);
			this.btnlimpiar.TabIndex = 36;
			this.btnlimpiar.UseVisualStyleBackColor = true;
			this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click_1);
			// 
			// btncambioestado
			// 
			this.btncambioestado.Image = ((System.Drawing.Image)(resources.GetObject("btncambioestado.Image")));
			this.btncambioestado.Location = new System.Drawing.Point(71, 120);
			this.btncambioestado.Name = "btncambioestado";
			this.btncambioestado.Size = new System.Drawing.Size(62, 62);
			this.btncambioestado.TabIndex = 35;
			this.btncambioestado.UseVisualStyleBackColor = true;
			this.btncambioestado.Click += new System.EventHandler(this.btncambioestado_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.Location = new System.Drawing.Point(139, 120);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(69, 62);
			this.btnCancelar.TabIndex = 34;
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnValidarencabezado
			// 
			this.btnValidarencabezado.Image = global::CapaVistaMVentasCC.Properties.Resources.guardar;
			this.btnValidarencabezado.Location = new System.Drawing.Point(7, 120);
			this.btnValidarencabezado.Name = "btnValidarencabezado";
			this.btnValidarencabezado.Size = new System.Drawing.Size(58, 62);
			this.btnValidarencabezado.TabIndex = 25;
			this.btnValidarencabezado.UseVisualStyleBackColor = true;
			this.btnValidarencabezado.Click += new System.EventHandler(this.btnValidarencabezado_Click);
			// 
			// txtBodega2
			// 
			this.txtBodega2.Location = new System.Drawing.Point(244, 61);
			this.txtBodega2.Name = "txtBodega2";
			this.txtBodega2.Size = new System.Drawing.Size(19, 20);
			this.txtBodega2.TabIndex = 24;
			// 
			// cbxBodega2
			// 
			this.cbxBodega2.FormattingEnabled = true;
			this.cbxBodega2.Location = new System.Drawing.Point(85, 60);
			this.cbxBodega2.Name = "cbxBodega2";
			this.cbxBodega2.Size = new System.Drawing.Size(145, 21);
			this.cbxBodega2.TabIndex = 22;
			this.cbxBodega2.SelectedIndexChanged += new System.EventHandler(this.cbxBodega2_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 66);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 13);
			this.label5.TabIndex = 21;
			this.label5.Text = "Tipo de Cuenta:";
			// 
			// rbnVencida
			// 
			this.rbnVencida.AutoSize = true;
			this.rbnVencida.Location = new System.Drawing.Point(119, 97);
			this.rbnVencida.Name = "rbnVencida";
			this.rbnVencida.Size = new System.Drawing.Size(63, 17);
			this.rbnVencida.TabIndex = 14;
			this.rbnVencida.TabStop = true;
			this.rbnVencida.Text = "Inactiva";
			this.rbnVencida.UseVisualStyleBackColor = true;
			this.rbnVencida.CheckedChanged += new System.EventHandler(this.rbnVencida_CheckedChanged);
			// 
			// rbnActiva
			// 
			this.rbnActiva.AutoSize = true;
			this.rbnActiva.Location = new System.Drawing.Point(62, 97);
			this.rbnActiva.Name = "rbnActiva";
			this.rbnActiva.Size = new System.Drawing.Size(55, 17);
			this.rbnActiva.TabIndex = 13;
			this.rbnActiva.TabStop = true;
			this.rbnActiva.Text = "Activo";
			this.rbnActiva.UseVisualStyleBackColor = true;
			this.rbnActiva.CheckedChanged += new System.EventHandler(this.rbnActiva_CheckedChanged);
			// 
			// txtid
			// 
			this.txtid.Location = new System.Drawing.Point(85, 4);
			this.txtid.Name = "txtid";
			this.txtid.Size = new System.Drawing.Size(145, 20);
			this.txtid.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 97);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Estado:";
			// 
			// lblIdcotizacion
			// 
			this.lblIdcotizacion.AutoSize = true;
			this.lblIdcotizacion.Location = new System.Drawing.Point(634, 7);
			this.lblIdcotizacion.Name = "lblIdcotizacion";
			this.lblIdcotizacion.Size = new System.Drawing.Size(0, 13);
			this.lblIdcotizacion.TabIndex = 16;
			// 
			// lblIdEmpleado
			// 
			this.lblIdEmpleado.AutoSize = true;
			this.lblIdEmpleado.Location = new System.Drawing.Point(230, 60);
			this.lblIdEmpleado.Name = "lblIdEmpleado";
			this.lblIdEmpleado.Size = new System.Drawing.Size(0, 13);
			this.lblIdEmpleado.TabIndex = 16;
			// 
			// lblIdcliente
			// 
			this.lblIdcliente.AutoSize = true;
			this.lblIdcliente.Location = new System.Drawing.Point(221, 29);
			this.lblIdcliente.Name = "lblIdcliente";
			this.lblIdcliente.Size = new System.Drawing.Size(0, 13);
			this.lblIdcliente.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "ID:";
			// 
			// frmCuentaContable
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::CapaVistaMVentasCC.Properties.Resources._90_Simple_Backgrounds_Edit_and_Download_Visual_Learning_Center;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(746, 269);
			this.Controls.Add(this.btnAyuda);
			this.Controls.Add(this.btnReporte);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dtgPedidosE);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmCuentaContable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cuentas Contables";
			((System.ComponentModel.ISupportInitialize)(this.dtgPedidosE)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnAyuda;
		private System.Windows.Forms.Button btnReporte;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.DataGridView dtgPedidosE;
		private System.Windows.Forms.TextBox txtnombre;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btncambioestado;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnValidarencabezado;
		private System.Windows.Forms.TextBox txtBodega2;
		private System.Windows.Forms.ComboBox cbxBodega2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RadioButton rbnVencida;
		private System.Windows.Forms.RadioButton rbnActiva;
		private System.Windows.Forms.TextBox txtid;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblIdcotizacion;
		private System.Windows.Forms.Label lblIdEmpleado;
		private System.Windows.Forms.Label lblIdcliente;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnlimpiar;
	}
}