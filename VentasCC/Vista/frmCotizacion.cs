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
	public partial class frmCotizacion : Form
	{
		Bitacora loggear = new Bitacora();
		string estado = "";
		string ps = "";
		float total = 0;
		float sub = 0;


		string tablas;
		string DB;


		public string tablaAyuda = "Aplicacion";
		public string campoAyuda = "pkid";
		//public ReporteCotizacion formReporte = new ReporteCotizacion();
		public string idAplicacion = "3002";
		string permisos = "";

		ControladorFacturacion con = new ControladorFacturacion();

		public Boolean permisoIngreso = true;  //Valor que debe llegar de seguridad
		public Boolean permisoModificar = true;  //Valor que debe llegar de seguridad
		public Boolean permisoEliminar = true;  //Valor que debe llegar de seguridad
		public Boolean permisoConsultar = true;  //Valor que debe llegar de seguridad
		public Boolean permisoReporteador = true;  //Valor que debe llegar de seguridad

		public frmCotizacion()
		{
			InitializeComponent();

			//string Usuario = "admin";
			//IdUsuario = loggear.obtenerIdDeUsuario(Usuario);
			loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Acceso a Cotización");

			permisos = bloqueo(IdUsuario, "3002");
			funActualizarPermisos();

			actualizardatagriew("CotizacionEncabezado", "CotizacionDetalle", dtgEncabezado, dtgDetalle);

			llenarcbxna(cbxCliente, "Cliente", "estatus", "Seleccione un Cliente", 1, 3);
			llenarcbx(cbxNombre, "Cliente", "estatus", "Elija un Cliente", 1);
			llenarcbx(cbxApellido, "Cliente", "estatus", "Elija un Cliente", 3);
			llenarcbx(cbxMoneda, "Moneda", "estadomoneda", "Elija una Moneda", 1);


			txtTotal.Enabled = false;
			txtSubtotal.Enabled = false;
			btncambioestado.Enabled = false;
			btncancelarcambio.Enabled = false;
			btnCancelar.Enabled = false;
			txtFkfactura.Enabled = false;
			txtStock.Enabled = false;
			txtcambio.Enabled = false;


			txtTotal.Text = "0.00";
		}

		public void llenarcbx(ComboBox cbx, string tabla, string estatus, string inicial, int i)
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

		public void llenarcbxe(ComboBox cbx, string tabla, string inicial, int i)
		{

			try
			{
				cbx.Items.Clear();
				OdbcDataReader datareader = con.llenarcbxse(tabla);
				cbx.Items.Add(inicial);
				while (datareader.Read())
				{
					cbx.Items.Add(datareader[i].ToString());
				}
				cbx.SelectedIndex = 0;
			}
			catch (Exception ex) { MessageBox.Show("Error: " + ex); }
		}


		public void llenarcbxna(ComboBox cbx, string tabla, string estatus, string inicial, int i, int j)
		{

			try
			{
				cbx.Items.Clear();
				OdbcDataReader datareader = con.llenarcbxna(tabla, estatus);
				cbx.Items.Add(inicial);
				while (datareader.Read())
				{
					cbx.Items.Add(datareader[i].ToString() + " " + datareader[j].ToString());
				}
				cbx.SelectedIndex = 0;
			}
			catch (Exception ex) { MessageBox.Show("Error: " + ex); }
		}

		public void llenarcbxtc(ComboBox cbx, string tabla, string id, string inicial, int i)
		{

			try
			{
				cbx.Items.Clear();
				OdbcDataReader datareader = con.llenarcbxtc(tabla, id);
				cbx.Items.Add(inicial);
				while (datareader.Read())
				{
					cbx.Items.Add(datareader[i].ToString());
				}
				cbx.SelectedIndex = 0;
			}
			catch (Exception ex) { MessageBox.Show("Error: " + ex); }
		}

		public void llenarcbxse(ComboBox cbx, string tabla, string inicial, int i, int j)
		{

			try
			{
				cbx.Items.Clear();
				OdbcDataReader datareader = con.llenarcbxse(tabla);
				cbx.Items.Add(inicial);
				while (datareader.Read())
				{
					cbx.Items.Add(datareader[i].ToString() + " " + datareader[j].ToString());
				}
				cbx.SelectedIndex = 0;
			}
			catch (Exception ex) { MessageBox.Show("Error: " + ex); }
		}

		public void consultaId(TextBox txt, string tabla, string nombre, string apellido, string dato)
		{
			con.consultaid(txt, tabla, nombre, apellido, dato);
		}
		public void consultaIda(TextBox txt, string tabla, string nombre, string dato, string condicion)
		{
			con.consultaida(txt, tabla, nombre, dato, condicion);
		}

		public void limpiar()
		{
			txtIdfactura.Text = "";
			txtIdfactura.Enabled = true;
			cbxCliente.SelectedIndex = 0;
			cbxCliente.Enabled = true;
			dtpFechaemision.Text = string.Empty;
			dtpFechaemision.Enabled = true;
			dtpFechavencimiento.Text = string.Empty;
			dtpFechavencimiento.Enabled = true;
			txtTotal.Text = "0.00";
			rbnActiva.Checked = false;
			rbnActiva.Enabled = true;
			rbnVencida.Checked = false;
			rbnVencida.Enabled = true;
			estado = "";
			cbxMoneda.SelectedIndex = 0;
			cbxMoneda.Enabled = true;
			txtcambio.Text = "";
			cbxTipocambio.Items.Clear();
			cbxidcambio.Items.Clear();

			txtIddetalle.Text = "";
			txtFkfactura.Text = "";
			rbnProducto.Checked = false;
			rbnServicio.Checked = false;
			ps = "";
			cbxPS.Items.Clear();
			txtSubtotal.Text = "";
			txtStock.Text = "";
			txtCantidad.Text = "";


			total = 0;
			sub = 0;

		}

		public void bloquear()
		{
			txtIdfactura.Enabled = false;
			cbxCliente.Enabled = false;
			dtpFechaemision.Enabled = false;
			dtpFechavencimiento.Enabled = false;
			rbnActiva.Enabled = false;
			rbnVencida.Enabled = false;
			cbxMoneda.Enabled = false;


			igualarid();
		}

		public void actualizardatagriew(string tabla1, string tabla2, DataGridView dtg1, DataGridView dtg2)
		{
			DataTable dt = con.llenarDataGrid(tabla1);
			dtg1.DataSource = dt;
			DataTable dt1 = con.llenarDataGrid(tabla2);
			dtg2.DataSource = dt1;
		}

		public void igualarid()
		{
			txtFkfactura.Text = txtIdfactura.Text;
		}

		public string bloqueo(string id, string app)
		{
			string cadena = con.bloqueo(id, app);


			return cadena;
		}

		public void funActualizarPermisos() //Liam Patrick Bernard García 0901-18-10092, Jaime López 0901-18-735
		{

			if (permisos.Length < 5)
			{
				MessageBox.Show("El Usuario no tiene permisos para esta aplicacion.");
				this.Close();
				return;
			}

			if (permisos[0] == '1')
			{
				permisoIngreso = true;
			}
			else
			{
				permisoIngreso = false;
			}

			if (permisos[1] == '1')
			{

			}
			else
			{
				MessageBox.Show("Usted No Tiene Permisos de Lectura");
				this.Close();
			}

			if (permisos[2] == '1')
			{
				permisoReporteador = true;
			}
			else
			{
				permisoReporteador = false;
			}

			if (permisos[3] == '1')
			{
				permisoEliminar = true;
			}
			else
			{
				permisoEliminar = false;
			}

			if (permisos[4] == '1')
			{
				permisoModificar = true;
			}
			else
			{
				permisoModificar = false;
			}

			//btnGuardar.Enabled = false;
			//btnCancelar.Enabled = false;

			//Habilitación de Permisos

			if (permisoIngreso == false)
			{
				btnValidar.Enabled = false;
				btnInsertar.Enabled = false;
				btnModificar.Enabled = false;
			}
			else
			{
				btnValidar.Enabled = true;
				btnInsertar.Enabled = true;
				btnModificar.Enabled = true;
			}

			if (permisoModificar == false)
			{
				dtgEncabezado.Enabled = false;
				dtgDetalle.Enabled = false;
			}
			else
			{
				dtgEncabezado.Enabled = true;
				dtgDetalle.Enabled = false;
			}

			if (permisoReporteador == false)
			{
				btnReporte.Enabled = false;
			}
			else
			{
				btnReporte.Enabled = true;
			}
		}

		private void btnReporte_Click(object sender, EventArgs e)
		{
			//ReporteCotizacion cotizacion = new ReporteCotizacion();
			//cotizacion.Show();
			loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Acceso a Reporte");
		}

		private void btnAyuda_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "G:/Git/HSC INDIVIDUAL/Ayuda/VentasCC/AyudaCotizacion/AyudaCotizacion.chm", "AyudaCotizacion.html");
			loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Acceso a Ayuda");
		}

		private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtfechaemision.Text = dtpFechaemision.Value.ToString("yyyy-MM-dd");
			txtfechavencimiento.Text = dtpFechavencimiento.Value.ToString("yyyy-MM-dd");
			if (cbxCliente.SelectedIndex != 0)
			{
				int seleccion = cbxCliente.SelectedIndex;
				cbxNombre.SelectedIndex = seleccion;
				cbxApellido.SelectedIndex = seleccion;
				consultaId(txtidcliente, "Cliente", cbxNombre.Text, cbxApellido.Text, "Pkid");
			}
			else
			{
				txtidcliente.Text = "";
			}
		}

		private void dtpFechaemision_ValueChanged(object sender, EventArgs e)
		{
			txtfechaemision.Text = dtpFechaemision.Value.ToString("yyyy-MM-dd");
		}

		private void dtpFechavencimiento_ValueChanged(object sender, EventArgs e)
		{
			txtfechavencimiento.Text = dtpFechavencimiento.Value.ToString("yyyy-MM-dd");
		}

		private void rbnActiva_CheckedChanged(object sender, EventArgs e)
		{
			estado = "A";
		}

		private void rbnVencida_CheckedChanged(object sender, EventArgs e)
		{
			estado = "I";
		}

		private void txtTotal_TextChanged(object sender, EventArgs e)
		{
			decimal dec = Convert.ToDecimal(total);
			txtTotal.Text = dec.ToString("0.00");
		}

		private void cbxMoneda_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxMoneda.SelectedIndex != 0)
			{
				consultaIda(txtidmoneda, "Moneda", cbxMoneda.Text, "pkid", "nombremoneda");
				llenarcbxtc(cbxTipocambio, "tipocambio", txtidmoneda.Text, "Seleccione un Cambio", 3);
				cbxTipocambio.SelectedIndex = cbxTipocambio.Items.Count - 1;
				llenarcbxtc(cbxidcambio, "tipocambio", txtidmoneda.Text, "Seleccione un Cambio", 0);
				cbxidcambio.SelectedIndex = cbxidcambio.Items.Count - 1;
				txtcambio.Text = cbxTipocambio.Text;
				txtidcambio.Text = cbxidcambio.Text;
			}
			else
			{
				cbxTipocambio.Items.Clear();
				cbxidcambio.Items.Clear();

				txtcambio.Text = "";
				txtidcambio.Text = "";
				txtidmoneda.Text = "";
			}
		}

		private void cbxPS_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ps == "p")
			{
				if (cbxPS.SelectedIndex != 0)
				{
					consultaIda(txtidps, "Producto", cbxPS.Text, "pkid", "nombre");
					consultaIda(txtSubtotal, "Producto", cbxPS.Text, "precio", "nombre");
					consultaIda(txtStock, "Producto", cbxPS.Text, "stock", "nombre");
				}
				else
				{
					txtidps.Text = "";
				}
			}
			else if (ps == "s")
			{
				if (cbxPS.SelectedIndex != 0)
				{
					consultaIda(txtidps, "TipoServicio", cbxPS.Text, "idtiposervicio", "nombre");
					consultaIda(txtSubtotal, "TipoServicio", cbxPS.Text, "precio", "nombre");
				}
				else
				{
					txtidps.Text = "";
				}
			}
		}

		private void rbnProducto_CheckedChanged(object sender, EventArgs e)
		{
			ps = "p";
			txtidps.Text = "";
			llenarcbxe(cbxPS, "Producto", "Elija un Producto", 2);
		}

		private void rbnServicio_CheckedChanged(object sender, EventArgs e)
		{
			ps = "s";
			txtidps.Text = "";
			llenarcbxe(cbxPS, "TipoServicio", "Elija un Servicio", 1);
		}

		private void btnValidar_Click(object sender, EventArgs e)
		{
			if (txtIdfactura.Text == "")
			{
				MessageBox.Show("Debes ingresar un ID para la cotización");
			}
			else if (cbxCliente.SelectedIndex == 0)
			{
				MessageBox.Show("Debes seleccionar un cliente.");
			}
			else if (dtpFechaemision.Value >= dtpFechavencimiento.Value)
			{
				MessageBox.Show("Debe seleccionarse una fecha de vencimiento próxima a la de emisión.");
			}
			else if (estado == "" || estado == "I")
			{
				MessageBox.Show("El estado que seleccionó no es valido para la acción o debe seleccionar uno.");
			}
			else if (txtidcliente.Text == "")
			{
				MessageBox.Show("Debe seleccionar una moneda para la cotización.");
			}
			else
			{
				int ret = con.insertarEncabezadoC("CotizacionEncabezado", txtIdfactura.Text, txtidcliente.Text, txtfechaemision.Text, txtfechavencimiento.Text, txtTotal.Text, txtidcambio.Text, estado);

				if (ret == 1)
				{
					actualizardatagriew("CotizacionEncabezado", "CotizacionDetalle", dtgEncabezado, dtgDetalle);
					bloquear();
					btnValidar.Enabled = false;
					if (permisoEliminar == false)
					{
						btnCancelar.Enabled = false;
					}
					else
					{
						btnCancelar.Enabled = true;
					}
					loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Cotización " + txtIdfactura.Text + " Ingresada");
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
				con.eliminar("CotizacionDetalle", txtFkfactura.Text, "fkidencabezado");
				loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Cotización N° " + txtIdfactura.Text + " cancelada con sus detalles relacionados");
			}
			catch (Exception exep)
			{
				MessageBox.Show("No hay registros vinculados a la cotización eliminada");
				loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Cotización N° " + txtIdfactura.Text + " cancelada sin detalles relacionados");
			}
			con.eliminar("CotizacionEncabezado", txtIdfactura.Text, "pkid");
			actualizardatagriew("CotizacionEncabezado", "CotizacionDetalle", dtgEncabezado, dtgDetalle);
			limpiar();
			btnCancelar.Enabled = false;
			btnValidar.Enabled = true;
		}

		private void btncambioestado_Click(object sender, EventArgs e)
		{
			int ret =0; //con.modifEncabezadoP("CotizacionEncabezado", txtIdfactura.Text, estado);

			if (ret == 1)
			{
				actualizardatagriew("CotizacionEncabezado", "CotizacionDetalle", dtgEncabezado, dtgDetalle);
				loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Estado de la Cotización N° " + txtIdfactura.Text + " modificado");
				limpiar();
				btnCancelar.Enabled = false;
				btnValidar.Enabled = true;
				btncambioestado.Enabled = false;
				btncancelarcambio.Enabled = false;
			}
			else
			{
				limpiar();
				btnCancelar.Enabled = false;
				btnValidar.Enabled = true;
				btncambioestado.Enabled = false;
				btncancelarcambio.Enabled = false;
			}
			limpiar();
		}

		private void btncancelarcambio_Click(object sender, EventArgs e)
		{
			loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Modificación del estado de la Cotización N° " + txtIdfactura.Text + " cancelada");
			btnCancelar.Enabled = false;
			btnValidar.Enabled = true;
			btncambioestado.Enabled = false;
			btncancelarcambio.Enabled = false;
			total = 0;
			txtTotal.Text = "0.00";
			txtTotal.Text = total.ToString();
			limpiar();
		}

		private void btnInsertar_Click(object sender, EventArgs e)
		{
			if (txtIddetalle.Text == "")
			{
				MessageBox.Show("Debe ingresar un ID para el artículo que desea agregar.");
			}
			else if (txtFkfactura.Text == "")
			{
				MessageBox.Show("Debe crear una cotización antes de insertar artículos");
			}
			else if (ps == "")
			{
				MessageBox.Show("Debe seleccionar un tipo de artículo para añadir.");
			}
			else if (cbxPS.SelectedIndex == 0)
			{
				MessageBox.Show("Debe seleccionar un artículo para añadir.");
			}
			else
			{
				sub = (float.Parse(txtSubtotal.Text) * Int32.Parse(txtCantidad.Text));
				total = total + ((float.Parse(txtCantidad.Text) * float.Parse(txtSubtotal.Text)) / float.Parse(txtcambio.Text));
				txtTotal.Text = total.ToString();//ntotal.ToString();
				if (ps == "p")
				{
					con.insertarDetalleC("CotizacionDetalle", txtIddetalle.Text, txtFkfactura.Text, txtCantidad.Text, txtidps.Text, "", sub.ToString(), ps);
					loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Detalle de cotización N° " + txtIddetalle.Text + " añadido");
				}
				else if (ps == "s")
				{
					con.insertarDetalleC("CotizacionDetalle", txtIddetalle.Text, txtFkfactura.Text, txtCantidad.Text, "", txtidps.Text, sub.ToString(), ps);
					loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Detalle de cotización N° " + txtIddetalle.Text + " añadido");
				}

				txtIddetalle.Text = "";
				cbxPS.SelectedIndex = 0;
				txtSubtotal.Text = "";
				txtStock.Text = "";
				txtCantidad.Text = "";
				actualizardatagriew("CotizacionEncabezado", "CotizacionDetalle", dtgEncabezado, dtgDetalle);
			}
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			int ret = con.actualizarTotalC("CotizacionEncabezado", txtIdfactura.Text, txtTotal.Text);

			if (ret == 1)
			{
				loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Cotización N° " + txtIdfactura.Text + " finalizada");
				actualizardatagriew("CotizacionEncabezado", "CotizacionDetalle", dtgEncabezado, dtgDetalle);
				limpiar();
				btncancelarcambio.Enabled = false;
				btncambioestado.Enabled = false;
				btnCancelar.Enabled = true;
				btnValidar.Enabled = true;
			}
			else
			{
				limpiar();
				btncancelarcambio.Enabled = false;
				btncambioestado.Enabled = false;
				btnCancelar.Enabled = true;
				btnValidar.Enabled = true;
			}

			limpiar();
		}

		private void btnLimpiar_Click(object sender, EventArgs e)
		{
			txtIddetalle.Text = "";
			txtFkfactura.Text = "";
			rbnProducto.Checked = false;
			rbnServicio.Checked = false;
			ps = "";
			cbxPS.Items.Clear();
			txtSubtotal.Text = "";
			txtStock.Text = "";
			txtCantidad.Text = "";

			total = 0;
			sub = 0;

			loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Sección de detalle de cotización limpiado.");
		}

		private void dtgEncabezado_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			txtIdfactura.Text = dtgEncabezado.CurrentRow.Cells[0].Value.ToString();
			txtidcliente.Text = dtgEncabezado.CurrentRow.Cells[1].Value.ToString();

			cbxNombre.SelectedIndex = int.Parse(txtidcliente.Text);
			cbxApellido.SelectedIndex = int.Parse(txtidcliente.Text);
			int seleccion = cbxNombre.SelectedIndex;
			cbxCliente.SelectedIndex = seleccion;

			dtpFechaemision.Text = dtgEncabezado.CurrentRow.Cells[2].Value.ToString();
			dtpFechavencimiento.Text = dtgEncabezado.CurrentRow.Cells[3].Value.ToString();

			total = float.Parse(dtgEncabezado.CurrentRow.Cells[4].Value.ToString());
			txtTotal.Text = dtgEncabezado.CurrentRow.Cells[4].Value.ToString();
			txtidcambio.Text = dtgEncabezado.CurrentRow.Cells[5].Value.ToString();
			if (txtidcambio.Text != "")
			{
				consultaIda(txtidmoneda, "Tipocambio", txtidcambio.Text, "fkidmoneda", "idtipoc");
				llenarcbxtc(cbxidcambio, "tipocambio", txtidmoneda.Text, "Seleccione un Cambio", 0);
				llenarcbxtc(cbxTipocambio, "tipocambio", txtidmoneda.Text, "Seleccione un Cambio", 3);
				consultaIda(txtcambio, "Tipocambio", txtidcambio.Text, "cambiotipoc", "idtipoc");
			}


			string est = dtgEncabezado.CurrentRow.Cells[6].Value.ToString();

			if (est == "A")
			{
				rbnActiva.Checked = true;
			}
			else if (est == "I")
			{
				rbnVencida.Checked = true;
			}
			txtIdfactura.Enabled = false;
			cbxCliente.Enabled = false;
			dtpFechavencimiento.Enabled = false;
			dtpFechaemision.Enabled = false;
			cbxMoneda.Enabled = false;

			btncambioestado.Enabled = true;
			btncancelarcambio.Enabled = true;
			btnCancelar.Enabled = false;
			btnValidar.Enabled = false;

			loggear.guardarEnBitacora(IdUsuario, "3001", "3002", "Encabezado de cotización N° " + txtIdfactura.Text + " seleccionado");
		}
	}
}
