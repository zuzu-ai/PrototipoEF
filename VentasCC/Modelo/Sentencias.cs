using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModeloMVentasCC
{
	public class Sentencias
	{
        Conexion cn = new Conexion();

        //Mantenimiento Clientes Kevin Flores 9959-18-17632
        public void funInsertarCliente(string id, string nit, string nombre, string apellido, string direccion, string telefono, string estado)
        {

            string cadena = "INSERT INTO Cliente VALUES ('" + id + "','" + nit + "','" + nombre + "','" + apellido + "','" + direccion + "','" + telefono + "','" + estado + "');";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

        }

        public void funModifCliente(string id, string nit, string nombre, string apellido, string direccion, string telefono, string estado)
        {
            string cadena = "UPDATE Cliente SET nit_cliente= '" + nit + "', nombre_cliente= '" + nombre + "', apellido_cliente='" + apellido + "', direccion_cliente= '" + direccion + "', telefono_cliente= '" + telefono + "', estado_cliente= '" + estado + "' WHERE id_cliente= '" + id + "';";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }
        public void funElimCliente(string id)
        {
            string cadena = "DELETE FROM Cliente WHERE id_cliente= '" + id + "';";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }
        public OdbcDataAdapter llenarCliente(string tabla1)// metodo  que obtinene el contenido de una tabla
        {

            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla1 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        //Mantenimiento Fraccionamiento  Kevin Flores 9959-18-17632

        //Mantenimiento inventarios Heydi Quemé 9959-18-5335
        public void funInsertarProducto(string id, string nombre, string costo, string precio, string existencias, string estado)
        {

            string cadena = "INSERT INTO Inventario VALUES ('" + id + "','" + nombre + "'," + costo + "," + precio + "," + existencias + ",'" + estado + "');";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();

        }

        public void funModifProducto(string id, string nombre, string costo, string precio, string existencias, string estado)
        {
            string cadena = "UPDATE Inventario SET nombre_producto= '" + nombre + "', costo_producto= " + costo + ", precio_venta=" + precio + ", existencia_producto= " + existencias + ", estado_producto= '" + estado + "' WHERE id_inventario= '" + id + "';";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }
        public void funElimProducto(string id)
        {
            string cadena = "DELETE FROM Inventario WHERE id_inventario= '" + id + "';";

            OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
            consulta.ExecuteNonQuery();
        }
        public OdbcDataAdapter llenarProducto(string tabla1)// metodo  que obtinene el contenido de una tabla
        {

            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla1 + "  ;";
            OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());
            return dataTable;
        }

        //Mantenimiento tipo inventario Heydi Quemé 9959-18-5335

        //Mantenimiento Mora Kevin Flores 9959-18-17632

        //Mantenimiento tipo Documento Kevin Flores 9959-18-17632 

    }
}
