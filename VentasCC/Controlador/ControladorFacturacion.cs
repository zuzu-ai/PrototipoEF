using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaModeloMVentasCC;


namespace CapaControladorMVentasCC
{
	public class ControladorFacturacion
	{
		//Heydi Quemé 9959-18-5335
		SentenciasFacturacion sn = new SentenciasFacturacion();
		public void consultaid(TextBox txt, string tabla, string nombre, string apellido, string dato)
		{
			sn.consultaid(txt, tabla, nombre, apellido, dato);
		}

		public void consultaida(TextBox txt, string tabla, string nombre, string dato, string condicion)
		{
			sn.consultaida(txt, tabla, nombre, dato, condicion);
		}


		public OdbcDataReader llenarcbxna(string tabla, string estatus)
		{

			return sn.llenarcbxna(tabla, estatus);

		}

		public OdbcDataReader llenarcbxse(string tabla)
		{

			return sn.llenarcbxse(tabla);

		}

		public OdbcDataReader llenarcbxse(string tabla, string id)
		{

			return sn.llenarcbxna(tabla, id);

		}

		public DataTable llenarDataGrid(string tabla)
		{
			DataTable table = new DataTable();
			table = sn.llenarTabla(tabla);
			return table;
		}

		public int insertarcuenta(string tabla, int id, string nombre, int tipo, int estado)
		{
			int ret = sn.insertarcuenta(tabla, id, nombre, tipo, estado);
			return ret;
		}
		public int insertarcuentab(string tabla, int id, string nombre, int tipo, int estado,int numero)
		{
			int ret = sn.insertarcuentab(tabla, id, nombre, tipo, estado,numero);
			return ret;
		}
		public void eliminar(string tabla, string id, string condicion)
		{
			sn.eliminar(tabla, id, condicion);
		}

		public int insertarbanco(string tabla, int id, string nombre, int estado)
		{
			int ret = sn.insertarbanco(tabla, id, nombre, estado);
			return ret;
		}

		public int modificarcuenta(string tabla, int id,string nombre, int tipo, int estado)
		{
			int ret = sn.modificarcuenta(tabla, id,nombre,tipo,estado);
			return ret;
		}
		public int modificarbanco(string tabla, int id, string nombre, int estado)
		{
			int ret = sn.modificarbanco(tabla, id, nombre, estado);
			return ret;
		}
		public int modificarcuentab(string tabla, int id, string nombre, int tipo, int estado,int numero)
		{
			int ret = sn.modificarcuentab(tabla, id, nombre, tipo, estado,numero);
			return ret;
		}
		public int insertarEncabezadoC(string tabla, string id, string cliente, string emision, string vencimiento, string total, string tipocambio, string estado)
		{
			int ret = sn.insertarEncabezadoC(tabla, id, cliente, emision, vencimiento, total, tipocambio, estado);
			return ret;
		}

		public int insertarDetalleC(string tabla, string id, string cotizacion, string cantidad, string producto, string servicio, string subtotal, string ps)
		{
			int ret = sn.insertarDetalleC(tabla, id, cotizacion, cantidad, producto, servicio, subtotal, ps);
			return ret;
		}

		public int actualizarTotalC(string tabla, string id, string total)
		{
			int ret = sn.actualizarTotalC(tabla, id, total);
			return ret;
		}

		public OdbcDataReader llenarcbxtc(string tabla, string id)
		{
			return sn.llenarcbxtc(tabla, id);
		}

		public OdbcDataReader llenarcbxprevia(string tabla, string comparacion, string comparado, string estatus, string estadoc)
		{
			return sn.llenarcbxprevia(tabla, comparacion, comparado, estatus, estadoc);
		}

		public int insertarEncabezadoF(string tabla, string id, string cliente, string empleado, string emision, string cotizacion, string reservacion, string turismo, string tipocambio, string formapago, string estado, string total, string p, string ps, string nombre)
		{
			int ret = sn.insertarEncabezadoF(tabla, id, cliente, empleado, emision, cotizacion, reservacion, turismo, tipocambio, formapago, estado, total, p, ps, nombre);
			return ret;
		}

		public void insertarDetalleF(string tabla, string pkid, string fkencabezado, string cantidad, string fkidproducto, string fkservicio, string subtotal, string iva, string ps)
		{
			sn.insertarDetalleF(tabla, pkid, fkencabezado, cantidad, fkidproducto, fkservicio, subtotal, iva, ps);

		}

		public void modificarstock(string tabla, string idarticulo, string parametroid, string stocknuevo, string parametrostock)
		{
			sn.modificarstock(tabla, idarticulo, parametroid, stocknuevo, parametrostock);
		}

		public string ultimapoliza()
		{
			string ultima = sn.ultimapoliza();
			return ultima;
		}

		public string tipopoliza()
		{
			string idtipopoliza = sn.tipopoliza();
			return idtipopoliza;
		}

		public void insertarPolizaE(string id, string fecha, string tipopoliza)
		{
			sn.insertarPolizaE(id, fecha, tipopoliza);
		}

		public string idcuenta(string nombre)
		{
			string idcuenta = sn.idcuenta(nombre);
			return idcuenta;
		}

		public string tipoperacion(string nombre1, string nombre2)
		{
			string idtipoperacion = sn.tipoperacion(nombre1, nombre2);
			return idtipoperacion;
		}

		public void insertarPolizaD(string id, string fecha, string cuenta, string saldo, string operacion, string concepto)
		{
			sn.insertarPolizaD(id, fecha, cuenta, saldo, operacion, concepto);
		}

		public string bloqueo(string id, string app)
		{
			string cadena = sn.llenarpermisos(id, app);

			return cadena;

		}
	}
}
