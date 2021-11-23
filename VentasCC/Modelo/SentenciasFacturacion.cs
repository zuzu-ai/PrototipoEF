using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaModeloMVentasCC
{
 //Heydi Quemé 9959-18-5335
    public class SentenciasFacturacion
    {
        Conexion cn = new Conexion();

        //función general para consultar el id para un combo con nombre y apellido
        public void consultaid(TextBox txt, string tabla, string nombre, string apellido, string dato)
        {
            string sql = "SELECT * FROM " + tabla + " WHERE nombre= '" + nombre + "' AND apellido= '" + apellido + "';";
            //MessageBox.Show(sql);

            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                txt.Text = busqueda[dato].ToString();
            }



        }

        //función general para consulta de id para un combo
        public void consultaida(TextBox txt, string tabla, string nombre, string dato, string condicion)
        {
            string sql = "SELECT * FROM " + tabla + " WHERE " + condicion + "= '" + nombre + "';";
            // MessageBox.Show(sql);

            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                txt.Text = busqueda[dato].ToString();
            }



        }

        //funcion general para llenar nombre y apellido
        public OdbcDataReader llenarcbxna(string tabla, string estatus)
        {


            string sql = "SELECT * FROM " + " " + tabla + " " + "WHERE " + " " + estatus + "= 'A' or " + estatus + "= '1' ";

            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        //funcion general para llenar un combo sin consultar estado
        public OdbcDataReader llenarcbxse(string tabla)
        {


            string sql = "SELECT * FROM " + " " + tabla + ";";

            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        //función para llenar combobox de forma previa para facturacion
        public OdbcDataReader llenarcbxprevia(string tabla, string comparacion, string comparado, string estatus, string estadoc)
        {


            string sql = "SELECT * FROM " + tabla + " WHERE " + comparacion + "= '" + comparado + "' AND " + estadoc + "= '" + estatus + "';";

            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        //función general para llenar una tabla
        public DataTable llenarTabla(string tabla)// metodo  que obtinene el contenido de una tabla
        {
            DataTable table = new DataTable();
            //string para almacenar los campos de OBTENERCAMPOS y utilizar el 1ro
            string sql = "SELECT * FROM " + tabla + "  ;";
            try
            {
                OdbcDataAdapter dataTable = new OdbcDataAdapter(sql, cn.conexion());

                dataTable.Fill(table);

            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error al leer los datos " + ex.Message);
            }
            return table;
        }

        //función para insertar cuenta contable
        public int insertarcuenta(string tabla, int id, string nombre, int tipo, int estado)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " VALUES ('" + id + "','" + nombre + "','" + tipo + "','" + estado + "');";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al ingresar la cuenta: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion general para insertar bancos
        public int insertarbanco(string tabla, int id, string nombre, int estado)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " VALUES ('" + id + "','" + nombre + "','" + estado + "');";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al ingresar el banco: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion general para ingresar cuenta bancaria
        public int insertarcuentab(string tabla, int id, string nombre, int tipo, int estado,int numero)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " VALUES ('" + id + "','" + nombre + "','" + numero + "','" + tipo + "','" + estado + "');";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al ingresar la cuenta: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion general para eliminar datos
        public void eliminar(string tabla, string id, string condicion)
        {
            try
            {
                string cadena = "DELETE FROM " + tabla + " WHERE " + condicion + "='" + id + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al cancelar el pedido: " + ex.Message);
            }
        }

        //funcion para modificar cuentas contables
        public int modificarcuenta(string tabla, int id, string nombre, int tipo, int estado)
        {
            int ret;
            try
            {
                string cadena = "UPDATE " + tabla + " SET nombre= '"+ nombre + "',tipocuenta=" + tipo + ", estado=" + estado + " WHERE id=" + id + ";";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al editar la cuenta: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion general para modificar bancos
        public int modificarbanco(string tabla, int id, string nombre, int estado)
        {
            int ret;
            try
            {
                string cadena = "UPDATE " + tabla + " SET nombre= '" + nombre + "', estado=" + estado + " WHERE id=" + id + ";";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al editar la cuenta: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion general para modificar cuenta bancaria
        public int modificarcuentab(string tabla, int id, string nombre, int tipo, int estado,int numero)
        {
            int ret;
            try
            {
                string cadena = "UPDATE " + tabla + " SET nombre= '" + nombre + "',numero=" + numero + " ,banco=" + tipo + ", estado=" + estado + " WHERE id=" + id + ";";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al editar la cuenta: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion para insertar encabezado de cotizacion
        public int insertarEncabezadoC(string tabla, string id, string cliente, string emision, string vencimiento, string total, string tipocambio, string estado)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " VALUES ('" + id + "','" + cliente + "','" + emision + "','" + vencimiento + "','" + total + "','" + tipocambio + "','" + estado + "');";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al generar la cotizacion: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion general para insertar detalle de cotizacion
        public int insertarDetalleC(string tabla, string id, string cotizacion, string cantidad, string producto, string servicio, string subtotal, string ps)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " (pkid,fkencabezado,cantidad,fkidproducto,subtotal) VALUES ('" + id + "','" + cotizacion + "','" + cantidad + "','" + producto + "','" + subtotal + "');";
                string cadena2 = "INSERT INTO " + tabla + " (pkid,fkencabezado,cantidad,fkservicio,subtotal) VALUES ('" + id + "','" + cotizacion + "','" + cantidad + "','" + servicio + "','" + subtotal + "');";



                if (ps == "p")
                {
                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();
                }
                else if (ps == "s")
                {
                    OdbcCommand consulta2 = new OdbcCommand(cadena2, cn.conexion());
                    consulta2.ExecuteNonQuery();

                }
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al añadir el detalle a la cotizacion: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion para insertar detalle de factura
        public void insertarDetalleF(string tabla, string pkid, string fkencabezado, string cantidad, string fkidproducto, string fkservicio, string subtotal, string iva, string ps)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " (pkid,fkencabezado,cantidad,fkidproducto,subtotal,iva) VALUES ('" + pkid + "','" + fkencabezado + "','" + cantidad + "','" + fkidproducto + "','" + subtotal + "','" + iva + "');";
                string cadena2 = "INSERT INTO " + tabla + " (pkid,fkencabezado,cantidad,fkservicio,subtotal,iva) VALUES ('" + pkid + "','" + fkencabezado + "','" + cantidad + "','" + fkservicio + "','" + subtotal + "','" + iva + "');";



                if (ps == "p")
                {
                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();
                }
                else if (ps == "s")
                {
                    OdbcCommand consulta2 = new OdbcCommand(cadena2, cn.conexion());
                    consulta2.ExecuteNonQuery();

                }
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al añadir el detalle a la cotizacion: " + ex.Message);
                ret = 0;
            }

        }
        //funcion para actualizar el total del encabezado al finalizar factura y cotizacion
        public int actualizarTotalC(string tabla, string id, string total)
        {
            int ret;
            try
            {
                string cadena = "UPDATE " + tabla + " SET total='" + total + "' WHERE pkid=" + id + ";";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }
            catch (OdbcException ex)
            {
                MessageBox.Show("Error al modificar el total de la cotización: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        //funcion para llenar combobox de tipo cambio
        public OdbcDataReader llenarcbxtc(string tabla, string id)
        {


            string sql = "SELECT * FROM " + tabla + " WHERE fkidmoneda='" + id + "';";

            try
            {
                OdbcCommand datos = new OdbcCommand(sql, cn.conexion());
                OdbcDataReader leer = datos.ExecuteReader();
                return leer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        //funcion para insertar encabezado de factura
        public int insertarEncabezadoF(string tabla, string id, string cliente, string empleado, string emision, string cotizacion, string reservacion, string turismo, string tipocambio, string formapago, string estado, string total, string p, string ps, string nombre)
        {
            int ret;
            try
            {
               
                string cadena = "INSERT INTO " + tabla + " (pkid,fkidcliente,fkidempleado,fechaemision,fkidtipocambio,fkidformapago,estado,total) VALUES ('" + id + "','" + cliente + "','" + empleado + "','" + emision + "','" + tipocambio + "','" + formapago + "','" + estado + "','" + total + "');";

                if (p == "")
                {
                    // MessageBox.Show(cadenasinturismoyprevia);
                    //MessageBox.Show(p);
                    OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                    consulta.ExecuteNonQuery();

                }
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al generar la factura: " + ex.Message);
                ret = 0;
            }
            return ret;
        }
        
        //funcion para modificar el stock de producto al finalizar factura
        public void modificarstock(string tabla, string idarticulo, string parametroid, string stocknuevo, string parametrostock)
        {
            try
            {
                string cadena = "UPDATE " + tabla + " SET " + parametrostock + "= " + stocknuevo + " WHERE " + parametroid + "= '" + idarticulo + "';";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();

            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al editar el stock del artículo: " + ex.Message);

            }
        }
        //funcion para obtener la ultima poliza registrada (encabezado)
        public string ultimapoliza()
        {
            string ultima = "0";
            string sql = "SELECT * FROM polizaencabezado ORDER BY idpolizaencabezado DESC LIMIT 1";
            // MessageBox.Show(sql);

            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery().ToString();
            //MessageBox.Show(ultima.ToString());
            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                ultima = busqueda["idPolizaEncabezado"].ToString();

            }
            else if (!busqueda.Read())
            {
                ultima = "0";
            }
            return ultima;
        }
        //funcion para obtener el id de tipo de poliza a registrar
        public string tipopoliza()
        {
            string idtipopoliza = "";
            string sql = "SELECT * FROM tipopoliza WHERE descripcion LIKE '%Venta%';";
            // MessageBox.Show(sql);

            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                idtipopoliza = busqueda["idTipoPoliza"].ToString();
            }
            return idtipopoliza;
        }
        //funcion para insertar encabezado de poliza
        public void insertarPolizaE(string id, string fecha, string tipopoliza)
        {
            try
            {
                string cadena = "INSERT INTO polizaEncabezado VALUES ('" + id + "','" + fecha + "','" + tipopoliza + "');";

                // MessageBox.Show(cadena);

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al añadir póliza por venta: " + ex.Message);
            }
        }
        //funcion para obtener el id de las cuentas involucradas en la poliza
        public string idcuenta(string nombre)
        {
            string idcuenta = "";
            string sql = "SELECT * FROM cuenta WHERE nombre LIKE '%" + nombre + "%';";
            // MessageBox.Show(sql);

            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                idcuenta = busqueda["idCuenta"].ToString();
            }
            return idcuenta;
        }
        //funcion para obtener el id del tipo de operacion en cada cuenta
        public string tipoperacion(string nombre1, string nombre2)
        {
            string idtipoperacion = "";
            string sql = "SELECT * FROM tipooperacion WHERE nombre LIKE '%" + nombre1 + "%' OR nombre LIKE '%" + nombre2 + "%'; ";
            // MessageBox.Show(sql);

            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                idtipoperacion = busqueda["idtipooperacion"].ToString();
            }
            return idtipoperacion;
        }
        //funcion para insertar detalle de poliza
        public void insertarPolizaD(string id, string fecha, string cuenta, string saldo, string operacion, string concepto)
        {
            try
            {
                string cadena = "INSERT INTO polizaDetalle VALUES ('" + id + "','" + fecha + "','" + cuenta + "','" + saldo + "','" + operacion + "','" + concepto + "');";

                // MessageBox.Show(cadena);

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al añadir detalle de póliza por venta: " + ex.Message);
            }
        }
        //funcion para llenar los permisos del usuario sobre la aplicacion
        public string llenarpermisos(string id, string app)
        {


            string Query = "SELECT  *    from   usuarioAplicacion   WHERE fkIdUsuario = " + id + " AND fkIdAplicacion= " + app + ";";






            OdbcCommand consulta = new OdbcCommand(Query, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            string cadena = "";
            if (busqueda.Read())
            {


                string escritura = busqueda["permisoEscritura"].ToString();

                string lectura = busqueda["permisoLectura"].ToString();


                string imprimir = busqueda["permisoImprimir"].ToString();


                string eliminar = busqueda["permisoEliminar"].ToString();


                string modificar = busqueda["permisoModificar"].ToString();

                cadena = escritura + lectura + imprimir + eliminar + modificar;


            }



            return cadena;


        }
    }
}
