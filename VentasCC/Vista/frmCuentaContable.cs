using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaControladorMVentasCC;
using BitacoraUsuario;
using static datosUsuario;
using System.Data.Odbc;
//Heydi Quemé 9959-18-5335
namespace CapaVistaMVentasCC
{
	public partial class frmCuentaContable : Form
	{
		Bitacora loggear = new Bitacora();
		ControladorFacturacion con = new ControladorFacturacion();
		string estado = "";

	

		public frmCuentaContable()
		{
			InitializeComponent();

			//string Usuario = "admin";
			//IdUsuario = loggear.obtenerIdDeUsuario(Usuario);

			loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Acceso a Cuentas Contables");

			llenarcbx(cbxBodega2, "tipocuenta", "id", "nombre", "estado", "Seleccione un Tipo", 1);
			actualizardatagriew("cuenta", dtgPedidosE);
		}

		
		public void consultaIda(TextBox txt, string tabla, string nombre, string dato, string condicion)
		{
			con.consultaida(txt, tabla, nombre, dato, condicion);
		}
		public void llenarcbx(ComboBox cbx, string tabla, string value, string display, string estatus, string inicial, int i)
		{

			try
			{
				cbx.Items.Clear();
				OdbcDataReader datareader = con.llenarcbxna(tabla, estatus);
				cbx.Items.Add(inicial);
				while (datareader.Read())
				{
					cbx.Items.Add(datareader[i].ToString());
				}
				cbx.SelectedIndex = 0;
			}
			catch (Exception ex) { MessageBox.Show("Error: " + ex); }
		}

		public void actualizardatagriew(string tabla1, DataGridView dtg1)
		{
			DataTable dt = con.llenarDataGrid(tabla1);
			dtg1.DataSource = dt;
		}

		public void limpiar()
		{
			txtid.Enabled = true;
			txtid.Text = "";
			txtnombre.Text = "";
			cbxBodega2.Enabled = true;
			rbnActiva.Enabled = true;
			rbnVencida.Enabled = true;
			rbnActiva.Checked = false;
			rbnVencida.Checked = false;
			cbxBodega2.SelectedIndex = 0;

			estado = "";

			//focus
			txtid.Focus();
		}

		public void bloquear()
		{
			txtid.Enabled = false;

			//focus
			txtnombre.Focus();
		}


		private void btnReporte_Click(object sender, EventArgs e)
		{
			//ReportePedidos pedido = new ReportePedidos();
			//pedido.Show();
			loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Acceso a Reporte");
		}

		private void btnAyuda_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "AyudaCuentas/AyudaCuentas.chm", "AyudaCuentas.html");
			loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Acceso a Ayuda");
		}

		private void cbxBodega_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void cbxBodega2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxBodega2.SelectedIndex!=0)
			{
				consultaIda(txtBodega2, "tipocuenta", cbxBodega2.Text, "id", "nombre");
			}
			else
			{
				txtBodega2.Text = "";
			}
		}

		private void dtpFechapedido_ValueChanged(object sender, EventArgs e)
		{
			
		}

		private void rbnActiva_CheckedChanged(object sender, EventArgs e)
		{
			estado = "1";
			
		}

		private void rbnVencida_CheckedChanged(object sender, EventArgs e)
		{
			estado = "0";
		}

		private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		private void dtpfechaVencimiento_ValueChanged(object sender, EventArgs e)
		{
			
		}

		private void btnValidarencabezado_Click(object sender, EventArgs e)
		{
			if (txtid.Text == "")
			{
				MessageBox.Show("Debe ingresar un ID para la cuenta.");
			}
			else if (txtnombre.Text=="")
			{
				MessageBox.Show("Debe ingresar un nombre para la cuenta.");
			}
			else if (cbxBodega2.SelectedIndex == 0)
			{
				MessageBox.Show("Debe seleccionar un tipo de cuenta.");
			}
			else if (estado == "" || estado == "I")
			{
				MessageBox.Show("Debe seleccionar un estado válido para la cuenta");
			}
			else
			{

				int ret = con.insertarcuenta("cuenta", Int32.Parse(txtid.Text), txtnombre.Text, Int32.Parse(txtBodega2.Text), Int32.Parse(estado));

				if (ret == 1)
				{
					loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Cuenta " + txtnombre.Text + " Ingresada");
					actualizardatagriew("cuenta", dtgPedidosE);

					limpiar();
				}
				else
				{
					limpiar();
				}
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			try
			{
				con.eliminar("cuenta", txtid.Text, "id");
				loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Cuenta " + txtid.Text + " eliminada");
			}
			catch (Exception excep)
			{
			}
			actualizardatagriew("cuenta", dtgPedidosE);
			limpiar();
		}

		private void btncambioestado_Click(object sender, EventArgs e)
		{
			int ret = con.modificarcuenta("cuenta", Int32.Parse(txtid.Text),txtnombre.Text,Int32.Parse(txtBodega2.Text), Int32.Parse(estado));

			if (ret == 1)
			{
				actualizardatagriew("cuenta", dtgPedidosE);
				loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Cuenta con código " + txtid.Text + " modificada");
				limpiar();
			}
			else
			{
				limpiar();
			}
		}

		private void btncancelarcambio_Click(object sender, EventArgs e)
		{
		}

		private void btnInsertar_Click(object sender, EventArgs e)
		{
			
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
		}

		private void dtgPedidosE_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			txtid.Text = dtgPedidosE.CurrentRow.Cells[0].Value.ToString();
			txtnombre.Text = dtgPedidosE.CurrentRow.Cells[1].Value.ToString();
			
			txtBodega2.Text = dtgPedidosE.CurrentRow.Cells[2].Value.ToString();
			cbxBodega2.SelectedIndex = int.Parse(txtBodega2.Text);
			
			string est = dtgPedidosE.CurrentRow.Cells[3].Value.ToString();

			if (est == "1")
			{
				rbnActiva.Checked = true;
			}
			else if (est == "0")
			{
				rbnVencida.Checked = true;
			}
			txtid.Enabled = false;
			loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Cuenta N° " + txtid.Text + " seleccionada");
		}

		private void btnlimpiar_Click_1(object sender, EventArgs e)
		{
			limpiar();
		}
	}
}
