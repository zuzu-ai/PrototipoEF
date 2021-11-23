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
	public partial class frmBancos : Form
	{
		Bitacora loggear = new Bitacora();
		ControladorFacturacion con = new ControladorFacturacion();
		string estado = "";
		public frmBancos()
		{
			InitializeComponent();

			loggear.guardarEnBitacora(IdUsuario, "2", "0004", "Acceso a Gestión de Bancos");

			actualizardatagriew("bancos", dtgPedidosE);
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
			rbnActiva.Enabled = true;
			rbnVencida.Enabled = true;
			rbnActiva.Checked = false;
			rbnVencida.Checked = false;

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



		private void btnValidarencabezado_Click(object sender, EventArgs e)
		{
			if (txtid.Text == "")
			{
				MessageBox.Show("Debe ingresar un ID para el banco.");
			}
			else if (txtnombre.Text == "")
			{
				MessageBox.Show("Debe ingresar un nombre para el banco.");
			}
			else if (estado == "" || estado == "I")
			{
				MessageBox.Show("Debe seleccionar un estado válido para el banco");
			}
			else
			{

				int ret = con.insertarbanco("bancos", Int32.Parse(txtid.Text), txtnombre.Text, Int32.Parse(estado));

				if (ret == 1)
				{
					loggear.guardarEnBitacora(IdUsuario, "2", "0004", "Banco " + txtnombre.Text + " Ingresado");
					actualizardatagriew("bancos", dtgPedidosE);

					limpiar();
				}
				else
				{
					limpiar();
				}
			}
		}

		private void btncambioestado_Click(object sender, EventArgs e)
		{
			int ret = con.modificarbanco("bancos", Int32.Parse(txtid.Text), txtnombre.Text, Int32.Parse(estado));

			if (ret == 1)
			{
				actualizardatagriew("bancos", dtgPedidosE);
				loggear.guardarEnBitacora(IdUsuario, "2", "0004", "Banco con código " + txtid.Text + " modificado");
				limpiar();
			}
			else
			{
				limpiar();
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			try
			{
				con.eliminar("bancos", txtid.Text, "id");
				loggear.guardarEnBitacora(IdUsuario, "2", "0004", "Banco " + txtid.Text + " eliminado");
			}
			catch (Exception excep)
			{
			}
			actualizardatagriew("bancos", dtgPedidosE);
			limpiar();
		}

		private void btnlimpiar_Click(object sender, EventArgs e)
		{
			limpiar();
		}

		private void btnReporte_Click(object sender, EventArgs e)
		{
			//ReportePedidos pedido = new ReportePedidos();
			//pedido.Show();
			loggear.guardarEnBitacora(IdUsuario, "2", "0002", "Acceso a Reporte");
		}

		private void btnAyuda_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "AyudaBancos/AyudaBancos.chm", "AyudaBancos.html");
			loggear.guardarEnBitacora(IdUsuario, "2", "0004", "Acceso a Ayuda");
		}

		private void rbnActiva_CheckedChanged(object sender, EventArgs e)
		{
			estado = "1";
		}

		private void rbnVencida_CheckedChanged(object sender, EventArgs e)
		{
			estado = "0";
		}

		private void dtgPedidosE_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			txtid.Text = dtgPedidosE.CurrentRow.Cells[0].Value.ToString();
			txtnombre.Text = dtgPedidosE.CurrentRow.Cells[1].Value.ToString();


			string est = dtgPedidosE.CurrentRow.Cells[2].Value.ToString();

			if (est == "1")
			{
				rbnActiva.Checked = true;
			}
			else if (est == "0")
			{
				rbnVencida.Checked = true;
			}
			txtid.Enabled = false;
			loggear.guardarEnBitacora(IdUsuario, "2", "0004", "Banco N° " + txtid.Text + " seleccionada");
		}
	}
}
