using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaModeloMVentasCC;

namespace CapaControladorMVentasCC
{
    public class Controlador
	{
        Sentencias sn = new Sentencias();

        //Mantenimiento Clientes Kevin Flores 9959-18-17632
        public void llamarInsertCliente(string id, string nit, string nombre, string apellido, string direccion, string telefono, string estado)
        {

            sn.funInsertarCliente(id, nit, nombre, apellido, direccion, telefono, estado);
        }

        public void llamarModifCliente(string id, string nit, string nombre, string apellido, string direccion, string telefono, string estado)
        {

            sn.funModifCliente(id, nit, nombre, apellido, direccion, telefono, estado);
        }

        public void llamarElimCliente(string id)
        {

            sn.funElimCliente(id);
        }
        public DataTable llenarCliente(string tabla1)
        {
            OdbcDataAdapter dt = sn.llenarCliente(tabla1);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        //Mantenimiento Fraccionamiento  Kevin Flores 9959-18-17632

        //Mantenimiento inventarios Heydi Quemé 9959-18-5335
        public void llamarInsertProducto(string id, string nombre, string costo, string precio, string existencias, string estado)
        {

            sn.funInsertarProducto(id, nombre, costo, precio, existencias, estado);
        }

        public void llamarModifProducto(string id, string nombre, string costo, string precio, string existencias, string estado)
        {

            sn.funModifProducto(id, nombre, costo, precio, existencias, estado);
        }

        public void llamarElimProducto(string id)
        {

            sn.funElimProducto(id);
        }
        public DataTable llenarProducto(string tabla1)
        {
            OdbcDataAdapter dt = sn.llenarProducto(tabla1);
            DataTable table = new DataTable();
            dt.Fill(table);
            return table;
        }

        //Mantenimiento tipo inventario Heydi Quemé 9959-18-5335

        //Mantenimiento Mora Kevin Flores 9959-18-17632

        //Mantenimiento tipo Documento Kevin Flores 9959-18-17632 

    }
}
