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
	public partial class frmFacturacion : Form
	{
		Bitacora loggear = new Bitacora();

		string estado = "";
		string ps = "";
		string p = "";
		float total = 0;
		float sub = 0;
		int stock = 0;
		double ivaporpagar = 0;
		string polizactual = "";
		string permisos = "";

		public Boolean permisoIngreso = true;  //Valor que debe llegar de seguridad
		public Boolean permisoModificar = true;  //Valor que debe llegar de seguridad
		public Boolean permisoEliminar = true;  //Valor que debe llegar de seguridad
		public Boolean permisoConsultar = true;  //Valor que debe llegar de seguridad
		public Boolean permisoReporteador = true;  //Valor que debe llegar de seguridad

		ControladorFacturacion con = new ControladorFacturacion();
		public frmFacturacion()
		{
			InitializeComponent();

			//string Usuario = "admin";
			//IdUsuario = loggear.obtenerIdDeUsuario(Usuario);


			loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Acceso a Facturación");

			permisos = bloqueo(IdUsuario, "3003");
			funActualizarPermisos();

			actualizardatagriew("FacturacionEncabezado", "FacturacionDetalle", dtgEncabezado, dtgDetalle);

			llenarcbxed(cbxCliente, "Cliente", "Seleccione un cliente", 1, 3);
			llenarcbxe(cbxNombre, "Cliente", "Seleccione un empleado", 1);
			llenarcbxe(cbxApellido, "Cliente", "Seleccione un empleado", 3);

			llenarcbxed(cbxEmpleado, "Empleado", "Seleccione un empleado", 1, 2);
			llenarcbxe(cbxNE, "Empleado", "Seleccione un empleado", 1);
			llenarcbxe(cbxAE, "Empleado", "Seleccione un empleado", 2);

			llenarcbx(cbxfpago, "FormaPago", "estatus", "Elija una Forma de Pago", 1);
			llenarcbx(cbxMoneda, "Moneda", "estadomoneda", "Elija una Moneda", 1);


			txtTotal.Enabled = false;
			txtSubtotal.Enabled = false;
			btncambioestado.Enabled = false;
			btncancelarcambio.Enabled = false;
			txtFkfactura.Enabled = false;
			txtStock.Enabled = false;
			txtcambio.Enabled = false;
			cbxPrevia.Enabled = false;

			txtTotal.Text = "0.00";

			llenarcbxmp();
		}

		public void actualizardatagriew(string tabla1, string tabla2, DataGridView dtg1, DataGridView dtg2)
		{
			DataTable dt = con.llenarDataGrid(tabla1);
			dtg1.DataSource = dt;
			DataTable dt1 = con.llenarDataGrid(tabla2);
			dtg2.DataSource = dt1;
		}

		public void llenarcbxed(ComboBox cbx, string tabla, string inicial, int i, int j)
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

		public void consultaId(TextBox txt, string tabla, string nombre, string apellido, string dato)
		{
			con.consultaid(txt, tabla, nombre, apellido, dato);
		}

		public void consultaIda(TextBox txt, string tabla, string nombre, string dato, string condicion)
		{
			con.consultaida(txt, tabla, nombre, dato, condicion);
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

		public void llenarcbxmp()
		{
			cbxMediopago.Items.Clear();
			cbxMediopago.Items.Add("Seleccione un Medio de Pago");
			cbxMediopago.Items.Add("Efectivo");
			cbxMediopago.Items.Add("Cheque");
			cbxMediopago.SelectedIndex = 0;
		}

		public void llenarcbxprevia(ComboBox cbx, string tabla, string comparacion, string comparado, string estatus, string estadoc, string inicial, int i)
		{
			try
			{
				cbx.Items.Clear();
				OdbcDataReader datareader = con.llenarcbxprevia(tabla, comparacion, comparado, estatus, estadoc);
				cbx.Items.Add(inicial);
				while (datareader.Read())
				{
					cbx.Items.Add(datareader[i].ToString());
				}
				cbx.SelectedIndex = 0;
			}
			catch (Exception ex) { MessageBox.Show("Error: " + ex); }
		}
		public void bloqueardetalle()
		{
			txtIdfactura.Enabled = false;
			cbxEmpleado.Enabled = false;

			dtpFechaemision.Enabled = false;
			rbnActiva.Enabled = false;
			rbnVencida.Enabled = false;
			cbxfpago.Enabled = false;
			cbxMoneda.Enabled = false;

			txtIddetalle.Enabled = false;
			rbnProducto.Enabled = false;
			rbnServicio.Enabled = false;
			cbxPS.Enabled = false;
			txtCantidad.Enabled = false;
			btnLimpiar.Enabled = false;
			btnInsertar.Enabled = false;
			btnValidar.Enabled = false;
			btnCancelar.Enabled = true;
			btnInsertar.Enabled = false;
			btnLimpiar.Enabled = false;
		}

		public void limpiar()
		{
			txtIdfactura.Text = "";
			txtIdfactura.Enabled = true;
			cbxCliente.SelectedIndex = 0;
			cbxCliente.Enabled = true;
			cbxEmpleado.SelectedIndex = 0;
			cbxEmpleado.Enabled = true;
			cbxfpago.SelectedIndex = 0;
			cbxfpago.Enabled = true;
			dtpFechaemision.Text = string.Empty;
			dtpFechaemision.Enabled = true;
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
			rbnr.Checked = false;
			rbnr.Enabled = true;
			rbnc.Checked = false;
			rbnc.Enabled = true;

			cbxPrevia.Items.Clear();
			cbxPrevia.Enabled = false;

			cbxMediopago.Enabled = true;
			cbxMediopago.SelectedIndex = 0;


			total = 0;
			sub = 0;
			stock = 0;
			ivaporpagar = 0;
			polizactual = "";

			btnValidar.Enabled = true;
			btnCancelar.Enabled = false;
			btncancelarcambio.Enabled = false;
			btncambioestado.Enabled = false;
			btnModificar.Enabled = true;
			btnLimpiar.Enabled = true;
			btnInsertar.Enabled = true;

		}

		public void bloquear()
		{
			txtIdfactura.Enabled = false;
			cbxCliente.Enabled = false;
			cbxEmpleado.Enabled = false;
			dtpFechaemision.Enabled = false;

			rbnActiva.Enabled = false;
			rbnVencida.Enabled = false;
			cbxfpago.Enabled = false;
			cbxMoneda.Enabled = false;
			cbxMediopago.Enabled = false;


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
				dtgDetalle.Enabled = true;
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
			//ReporteFacturacion facturacion = new ReporteFacturacion();
			//facturacion.Show();
			loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Acceso a Reporte");
		}

		private void btnAyuda_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, "G:/Git/HSC INDIVIDUAL/Ayuda/VentasCC/AyudaFacturacion/AyudaFacturacion.chm", "AyudaFacturacion.html");
			loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Acceso a Ayuda");
		}

		private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ps == "")
			{
				txtfechaemision.Text = dtpFechaemision.Value.ToString("yyyy-MM-dd");
				//txtfechavencimiento.Text = dtpFechavencimiento.Value.ToString("yyyy-MM-dd");
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
			else if (ps == "c")
			{
				if (cbxCliente.SelectedIndex != 0)
				{
					int seleccion = cbxCliente.SelectedIndex;
					cbxNombre.SelectedIndex = seleccion;
					cbxApellido.SelectedIndex = seleccion;
					consultaId(txtidcliente, "Cliente", cbxNombre.Text, cbxApellido.Text, "Pkid");

					llenarcbxprevia(cbxPrevia, "CotizacionEncabezado", "fkidcliente", txtidcliente.Text, "A", "estado", "Seleccione una Cotización", 0);
				}
				else
				{
					txtidcliente.Text = "";
				}
			}
			else if (ps == "r")
			{
				if (cbxCliente.SelectedIndex != 0)
				{
					int seleccion = cbxCliente.SelectedIndex;
					cbxNombre.SelectedIndex = seleccion;
					cbxApellido.SelectedIndex = seleccion;
					consultaId(txtidcliente, "Cliente", cbxNombre.Text, cbxApellido.Text, "Pkid");

					llenarcbxprevia(cbxPrevia, "Reservacion", "idcliente", txtidcliente.Text, "A", "estatus", "Seleccione una Reservación", 0);
				}
				else
				{
					txtidcliente.Text = "";
				}
			}
		}

		private void cbxEmpleado_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxEmpleado.SelectedIndex != 0)
			{
				int seleccion = cbxEmpleado.SelectedIndex;
				cbxNE.SelectedIndex = seleccion;
				cbxAE.SelectedIndex = seleccion;
				consultaId(txtidempleado, "Empleado", cbxNE.Text, cbxAE.Text, "Pkidempleado");
			}
			else
			{
				txtidempleado.Text = "";
			}
		}

		private void cbxfpago_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxfpago.SelectedIndex != 0)
			{
				consultaIda(txtidfpago, "FormaPago", cbxfpago.Text, "pkid", "nombre");
			}
			else
			{
				txtidfpago.Text = "";
			}
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

		private void dtpFechaemision_ValueChanged(object sender, EventArgs e)
		{
			txtfechaemision.Text = dtpFechaemision.Value.ToString("yyyy-MM-dd");
		}

		private void rbnActiva_CheckedChanged(object sender, EventArgs e)
		{
			estado = "A";
		}

		private void rbnVencida_CheckedChanged(object sender, EventArgs e)
		{
			estado = "I";
		}

		private void cbxMediopago_SelectedIndexChanged(object sender, EventArgs e)
		{
			decimal dec = Convert.ToDecimal(total);
			txtTotal.Text = dec.ToString("0.00");
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

		private void btnValidar_Click(object sender, EventArgs e)
		{
			if (txtIdfactura.Text == "")
			{
				MessageBox.Show("Debes ingresar un ID para la factura");
			}
			else if (cbxCliente.SelectedIndex == 0)
			{
				MessageBox.Show("Debes seleccionar un cliente.");
			}
			else if (cbxEmpleado.SelectedIndex == 0)
			{
				MessageBox.Show("Debe seleccionar un empleado.");
			}
			else if (estado == "" || estado == "I")
			{
				MessageBox.Show("El estado que seleccionó no es valido para la acción o debe seleccionar uno.");
			}
			else if (txtidcliente.Text == "")
			{
				MessageBox.Show("Debe seleccionar una moneda para la cotización.");
			}
			else if (txtidfpago.Text == "")
			{
				MessageBox.Show("Debe seleccionar una forma de pago.");
			}
			else if (cbxMediopago.SelectedIndex == 0)
			{
				MessageBox.Show("Debe seleccionar un medio de pago.");
			}
			else
			{
				string ultima = con.ultimapoliza();
				//MessageBox.Show(ultima);
				int nuevapoliza = ((Int32.Parse(ultima)) + 1);
				string fecha = txtfechaemision.Text;
				string idtipopoliza = con.tipopoliza();
				polizactual = nuevapoliza.ToString();
				con.insertarPolizaE(nuevapoliza.ToString(), fecha, idtipopoliza);

				int ret = con.insertarEncabezadoF("FacturacionEncabezado", txtIdfactura.Text, txtidcliente.Text, txtidempleado.Text, txtfechaemision.Text, "", "", "", txtidcambio.Text, txtidfpago.Text, estado, total.ToString(), p, ps, txtidprevia.Text);

				if (ret == 1)
				{
					actualizardatagriew("FacturacionEncabezado", "FacturacionDetalle", dtgEncabezado, dtgDetalle);
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
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Factura " + txtIdfactura.Text + " Ingresada");
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
				con.eliminar("FacturacionDetalle", txtFkfactura.Text, "fkencabezado");
				loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Factura N° " + txtIdfactura.Text + " cancelada con sus detalles relacionados");

			}
			catch (Exception excep)
			{
				MessageBox.Show("´No hay artículos vinculados a la cotización eliminada");
				loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Factura N° " + txtIdfactura.Text + " cancelada sin detalles relacionados");
			}

			con.eliminar("FacturacionEncabezado", txtIdfactura.Text, "pkid");
			actualizardatagriew("FacturacionEncabezado", "FacturacionDetalle", dtgEncabezado, dtgDetalle);
			limpiar();
			btnCancelar.Enabled = false;
			btnValidar.Enabled = true;
		}

		private void btncambioestado_Click(object sender, EventArgs e)
		{
			int ret = 0; //con.modifEncabezadoP("FacturacionEncabezado", txtIdfactura.Text, estado);

			if (ret == 1)
			{
				actualizardatagriew("FacturacionEncabezado", "FacturacionDetalle", dtgEncabezado, dtgDetalle);
				loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Estado de la Factura N° " + txtIdfactura.Text + " modificado");
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

		private void btncambioestado_Click_1(object sender, EventArgs e)
		{
			int ret = 0;// con.modifEncabezadoP("FacturacionEncabezado", txtIdfactura.Text, estado);

			if (ret == 1)
			{
				actualizardatagriew("FacturacionEncabezado", "FacturacionDetalle", dtgEncabezado, dtgDetalle);
				loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Estado de la Factura N° " + txtIdfactura.Text + " modificado");
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
			btnCancelar.Enabled = false;
			btnValidar.Enabled = true;
			btncambioestado.Enabled = false;
			btncancelarcambio.Enabled = false;
			total = 0;
			txtTotal.Text = "0.00";
			txtTotal.Text = total.ToString();
			loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Modificación del estado de la Factura N° " + txtIdfactura.Text + " cancelada");
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
					stock = (Int32.Parse(txtStock.Text) - Int32.Parse(txtCantidad.Text));
				}

				double iva = total * 0.12;
				ivaporpagar = ivaporpagar + iva;


				if (ps == "p")
				{
					con.insertarDetalleF("FacturacionDetalle", txtIddetalle.Text, txtFkfactura.Text, txtCantidad.Text, txtidps.Text, "", txtSubtotal.Text, iva.ToString(), ps);
					con.modificarstock("Producto", txtidps.Text, "pkid", stock.ToString(), "stock");
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Detalle de factura N° " + txtIddetalle.Text + " añadido");
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Stock del producto N°" + txtidps.Text + " reducido en " + txtCantidad.Text + " unidades");
				}
				else if (ps == "s")
				{
					con.insertarDetalleF("FacturacionDetalle", txtIddetalle.Text, txtFkfactura.Text, txtCantidad.Text, "", txtidps.Text, txtSubtotal.Text, iva.ToString(), ps);
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Detalle de factura N° " + txtIddetalle.Text + " añadido");
				}


				txtIddetalle.Text = "";
				cbxPS.SelectedIndex = 0;
				txtSubtotal.Text = "";
				txtStock.Text = "";
				txtCantidad.Text = "";
				actualizardatagriew("FacturacionEncabezado", "FacturacionDetalle", dtgEncabezado, dtgDetalle);
			}
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			int ret = con.actualizarTotalC("FacturacionEncabezado", txtIdfactura.Text, txtTotal.Text);
			double saldo = (double.Parse(txtTotal.Text) - ivaporpagar);

			if (cbxfpago.Text == "Contado")
			{
				if (cbxMediopago.Text == "Efectivo")
				{
					string idcaja = con.idcuenta("Caja");
					string idiva = con.idcuenta("IVA por Pagar");
					string idventas = con.idcuenta("Venta");

					string iddebe = con.tipoperacion("debe", "cargo");
					string idhaber = con.tipoperacion("haber", "abono");

					con.insertarPolizaD(polizactual, txtfechaemision.Text, idcaja, txtTotal.Text, iddebe, "Por venta al contado y pago en efectivo");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idiva, ivaporpagar.ToString(), idhaber, "Por venta al contado y pago en efectivo");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idventas, saldo.ToString(), idhaber, "Por venta al contado y pago en efectivo");
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Detalles de póliza con referencia a la póliza N° " + polizactual);
				}
				else if (cbxMediopago.Text == "Cheque")
				{
					string idbancos = con.idcuenta("Banco");
					string idiva = con.idcuenta("IVA por Pagar");
					string idventas = con.idcuenta("Venta");

					string iddebe = con.tipoperacion("debe", "cargo");
					string idhaber = con.tipoperacion("haber", "abono");

					con.insertarPolizaD(polizactual, txtfechaemision.Text, idbancos, txtTotal.Text, iddebe, "Por venta al contado y pago con cheque");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idiva, ivaporpagar.ToString(), idhaber, "Por venta al contado y pago con cheque");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idventas, saldo.ToString(), idhaber, "Por venta al contado y pago con cheque");
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Detalles de póliza con referencia a la póliza N° " + polizactual);
				}
			}
			else if (cbxfpago.Text == "Crédito")
			{
				if (cbxMediopago.Text == "Efectivo")
				{
					string idcaja = con.idcuenta("Caja");
					string idclientes = con.idcuenta("Cliente");
					string idiva = con.idcuenta("IVA por Pagar");
					string idventas = con.idcuenta("Venta");

					string iddebe = con.tipoperacion("debe", "cargo");
					string idhaber = con.tipoperacion("haber", "abono");

					con.insertarPolizaD(polizactual, txtfechaemision.Text, idcaja, ivaporpagar.ToString(), iddebe, "Por venta al crédito y pago en efectivo");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idclientes, saldo.ToString(), iddebe, "Por venta al crédito y pago en efectivo");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idiva, ivaporpagar.ToString(), idhaber, "Por venta al crédito y pago en efectivo");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idventas, saldo.ToString(), idhaber, "Por venta al crédito y pago en efectivo");
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Detalles de póliza con referencia a la póliza N° " + polizactual);
				}
				else if (cbxMediopago.Text == "Cheque")
				{
					string idbancos = con.idcuenta("Bancos");
					string idclientes = con.idcuenta("Cliente");
					string idiva = con.idcuenta("IVA por Pagar");
					string idventas = con.idcuenta("Venta");

					string iddebe = con.tipoperacion("debe", "cargo");
					string idhaber = con.tipoperacion("haber", "abono");

					con.insertarPolizaD(polizactual, txtfechaemision.Text, idbancos, ivaporpagar.ToString(), iddebe, "Por venta al crédito y pago con cheque");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idclientes, saldo.ToString(), iddebe, "Por venta al crédito y pago con cheque");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idiva, ivaporpagar.ToString(), idhaber, "Por venta al crédito y pago con cheque");
					con.insertarPolizaD(polizactual, txtfechaemision.Text, idventas, saldo.ToString(), idhaber, "Por venta al crédito y pago con cheque");
					loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Detalles de póliza con referencia a la póliza N° " + polizactual);
				}
			}


			if (ret == 1)
			{
				loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Factura N° " + txtIdfactura.Text + " finalizada");
				actualizardatagriew("FacturacionEncabezado", "FacturacionDetalle", dtgEncabezado, dtgDetalle);
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
			stock = 0;
			loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Sección de detalle de factura limpiado.");
		}

		private void dtgEncabezado_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			txtIdfactura.Text = dtgEncabezado.CurrentRow.Cells[0].Value.ToString();
			txtidcliente.Text = dtgEncabezado.CurrentRow.Cells[1].Value.ToString();

			cbxNombre.SelectedIndex = int.Parse(txtidcliente.Text);
			cbxApellido.SelectedIndex = int.Parse(txtidcliente.Text);
			int seleccion = cbxNombre.SelectedIndex;
			cbxCliente.SelectedIndex = seleccion;

			txtidempleado.Text = dtgEncabezado.CurrentRow.Cells[2].Value.ToString();
			cbxNE.SelectedIndex = int.Parse(txtidempleado.Text);
			cbxAE.SelectedIndex = int.Parse(txtidempleado.Text);
			int se = cbxNE.SelectedIndex;
			cbxEmpleado.SelectedIndex = se;

			dtpFechaemision.Text = dtgEncabezado.CurrentRow.Cells[3].Value.ToString();

			txtidcambio.Text = dtgEncabezado.CurrentRow.Cells[7].Value.ToString();
			if (txtidcambio.Text != "")
			{
				consultaIda(txtidmoneda, "Tipocambio", txtidcambio.Text, "fkidmoneda", "idtipoc");
				llenarcbxtc(cbxidcambio, "tipocambio", txtidmoneda.Text, "Seleccione un Cambio", 0);
				llenarcbxtc(cbxTipocambio, "tipocambio", txtidmoneda.Text, "Seleccione un Cambio", 3);
				consultaIda(txtcambio, "Tipocambio", txtidcambio.Text, "cambiotipoc", "idtipoc");
			}

			txtidfpago.Text = dtgEncabezado.CurrentRow.Cells[8].Value.ToString();
			cbxfpago.SelectedIndex = Int32.Parse(txtidfpago.Text);

			string est = dtgEncabezado.CurrentRow.Cells[9].Value.ToString();

			if (est == "A")
			{
				rbnActiva.Checked = true;
			}
			else if (est == "I")
			{
				rbnVencida.Checked = true;
			}

			total = float.Parse(dtgEncabezado.CurrentRow.Cells[10].Value.ToString());
			txtTotal.Text = dtgEncabezado.CurrentRow.Cells[10].Value.ToString();
			bloquear();

			rbnActiva.Enabled = true;
			rbnVencida.Enabled = true;

			btncambioestado.Enabled = true;
			btncancelarcambio.Enabled = true;
			btnCancelar.Enabled = false;
			btnValidar.Enabled = false;
			loggear.guardarEnBitacora(IdUsuario, "3001", "3003", "Encabezado de factura N° " + txtIdfactura.Text + " seleccionado");
		}
	}
}
