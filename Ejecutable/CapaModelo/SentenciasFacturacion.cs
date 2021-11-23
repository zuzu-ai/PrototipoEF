using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaModelo
{
    public class SentenciasFacturacion
    {
        Conexion cn = new Conexion();
        string rutaAyudaCHM = "";
        string rutaAyudaHTML = "";
        //función general para consultar el id para un combo
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

        //para cotizacion
        public int consultainsercion(string pkid,string fkencabezado,string cantidad, string fkidproducto,string fkservicio,string subtotal,string iva,string tablainsert, string tablaselect, string nombre, string condicion)
        {
            string ps = "";
            int i = 0;
            string sql = "SELECT * FROM " + tablaselect + " WHERE " + condicion + "= '" + nombre + "';";
            // MessageBox.Show(sql);
            int ret = 0;
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                string max = "SELECT MAX(pkid) FROM facturaciondetalle;";

                OdbcCommand consulta2 = new OdbcCommand(max, cn.conexion());
                consulta2.ExecuteNonQuery();

                OdbcDataReader busqueda2;
                busqueda2 = consulta2.ExecuteReader();

                if (busqueda2.Read())
                {
                     i= Int32.Parse(busqueda2[pkid].ToString())+1;
                }
                string id = i.ToString();
                string encabezado = busqueda[fkencabezado].ToString();
                string cantida = busqueda[cantidad].ToString();
                string idproducto = busqueda[fkidproducto].ToString();
                string idservicio = busqueda[fkservicio].ToString();
                string sub = busqueda[subtotal].ToString();
                float s = float.Parse(sub);
                double imp = s * 0.12;
                string impuesto = imp.ToString();

                if (idproducto == "")
                {
                    ps = "s";
                    insertarDetalleF(tablainsert, id, encabezado, cantida, "", idservicio, sub, impuesto, ps);
                    ret = 1;
                }
                else if (idproducto != "")
                {
                    ps = "p";
                    insertarDetalleF(tablainsert, id, encabezado, cantida, idproducto, "", sub, impuesto, ps);
                    ret = 1;
                }
            }

            return ret;

        }
        //para reservacion
        public int consultainsercion2(string idordenservicio,string idservicioe, string cantidad, string idtiposervicio, string costo, string iva, string tablainsert, string tablaselect, string nombre, string condicion)
        {
            string ps = "";
            int i = 0;
            string sql = "SELECT * FROM " + tablaselect + " WHERE " + condicion + "= '" + nombre + "';";
            // MessageBox.Show(sql);
            int ret = 0;
            OdbcCommand consulta = new OdbcCommand(sql, cn.conexion());
            consulta.ExecuteNonQuery();

            OdbcDataReader busqueda;
            busqueda = consulta.ExecuteReader();

            if (busqueda.Read())
            {
                string max = "SELECT MAX(idordenservicio) FROM facturaciondetalle;";

                OdbcCommand consulta2 = new OdbcCommand(max, cn.conexion());
                consulta.ExecuteNonQuery();

                OdbcDataReader busqueda2;
                busqueda2 = consulta2.ExecuteReader();

                if (busqueda2.Read())
                {
                    i = Int32.Parse(busqueda[idordenservicio].ToString()) + 1;
                }
                string id = i.ToString();
                string encabezado = busqueda[idservicioe].ToString();
                string cantida = busqueda[cantidad].ToString();
                string idproducto = busqueda[idtiposervicio].ToString();
              
                string sub = busqueda[costo].ToString();
                float s = float.Parse(sub);
                double imp = s * 0.12;
                string impuesto = imp.ToString();

                if (idproducto == "")
                {
                    ps = "s";
                    insertarDetalleF(tablainsert, id, encabezado, cantida, idproducto, "", sub, impuesto, ps);
                    ret = 1;
                }
            }

            return ret;

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


        //función para insertar encabezado de pedido
        public int insertarEncabezadoP(string tabla, string id, string cliente, string bodega, string fechap, string fechav, string estado)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " VALUES ('" + id + "','" + cliente + "','" + bodega + "','" + fechap + "','" + fechav + "','" + estado + "');";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al generar el pedido: " + ex.Message);
                ret = 0;
            }
            return ret;
        }

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

        public int insertarDetalleP(string tabla, string id, string pedido, string cantidad, string producto)
        {
            int ret;
            try
            {
                string cadena = "INSERT INTO " + tabla + " VALUES ('" + id + "','" + pedido + "','" + cantidad + "','" + producto + "');";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al añadir el detalle al pedido: " + ex.Message);
                ret = 0;
            }
            return ret;
        }

        public int modifEncabezadoP(string tabla, string id, string estado)
        {
            int ret;
            try
            {
                string cadena = "UPDATE " + tabla + " SET estado='" + estado + "' WHERE pkid=" + id + ";";

                OdbcCommand consulta = new OdbcCommand(cadena, cn.conexion());
                consulta.ExecuteNonQuery();
                ret = 1;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show("Error al editar el estado del pedido: " + ex.Message);
                ret = 0;
            }
            return ret;
        }

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

        public int insertarEncabezadoF(string tabla, string id, string cliente, string empleado, string emision, string cotizacion, string reservacion, string turismo, string tipocambio, string formapago, string estado, string total, string p, string ps,string nombre)
        {
            int ret;
            try
            {
                //INSERTS
                string cadenareservacionst = "INSERT INTO " + tabla + " (pkid,fkidcliente,fkidempleado,fechaemision,fkidreservacion,fkidtipocambio,fkidformapago,estado,total) VALUES ('" + id + "','" + cliente + "','" + empleado + "','" + emision + "','" + reservacion + "','" + tipocambio + "','" + formapago + "','" + estado + "','" + total + "');";
                string cadenacotizacionst = "INSERT INTO " + tabla + " (pkid,fkidcliente,fkidempleado,fechaemision,fkidcotizacion,fkidtipocambio,fkidformapago,estado,total) VALUES ('" + id + "','" + cliente + "','" + empleado + "','" + emision + "','" + cotizacion + "','" + tipocambio + "','" + formapago + "','" + estado + "','" + total + "');";
                string cadenasinturismoyprevia = "INSERT INTO " + tabla + " (pkid,fkidcliente,fkidempleado,fechaemision,fkidtipocambio,fkidformapago,estado,total) VALUES ('" + id + "','" + cliente + "','" + empleado + "','" + emision + "','" + tipocambio + "','" + formapago + "','" + estado + "','" + total + "');";

                


                if (p == "c")
                {
                    //MessageBox.Show(cadenacotizacionst);
                    //MessageBox.Show(p);
                    OdbcCommand consulta = new OdbcCommand(cadenacotizacionst, cn.conexion());
                        consulta.ExecuteNonQuery();
                   ret= consultainsercion("pkid", "fkencabezado", "cantidad", "fkidproducto", "fkservicio", "subtotal", "iva", "FacturacionDetalle", "CotizacionDetalle", nombre, "pkid");
                    

                }
                /*else if (p == "r")
                {
                    MessageBox.Show(cadenareservacionst);
                    MessageBox.Show(p);
                    OdbcCommand consulta = new OdbcCommand(cadenareservacionst, cn.conexion());
                        consulta.ExecuteNonQuery();
                    consultainsercion2("idordenservicio", "idservicioe", "cantidad", "idtiposervicio", "costo", "iva", "FacturacionDetalle", "ServicioDetallado", nombre, "idreservacion");
                    
                }*/
                if (p == "")
                {
                   // MessageBox.Show(cadenasinturismoyprevia);
                    //MessageBox.Show(p);
                    OdbcCommand consulta = new OdbcCommand(cadenasinturismoyprevia, cn.conexion());
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

        public void funAyuda(string idAplicacion, string nombreCampo, string tablaA, Control parent)
        {
            OdbcDataReader leer = null;

            string sql = "SELECT * FROM " + " " + tablaA + " " + "WHERE " + " " + nombreCampo + "=" + idAplicacion;

            OdbcConnection conect = cn.conexion();

            try
            {

                OdbcCommand comando = new OdbcCommand(sql, conect);
                leer = comando.ExecuteReader();

                while (leer.Read())
                {
                    rutaAyudaCHM = leer.GetString(4);

                    rutaAyudaHTML = leer.GetString(5);
                }


            }
            catch (OdbcException ex)
            {

                MessageBox.Show("Error al cargar los datos" + ex.Message);

            }

            finally
            {
                cn.desconexion(conect);

            }

            if (String.IsNullOrEmpty(rutaAyudaCHM) || String.IsNullOrEmpty(rutaAyudaHTML))
            {
                MessageBox.Show("La ruta ingresa CHM o Referencia HTML es incorrecta, verifique Aplicacion!");

            }
            else
            {
                Help.ShowHelp(parent, rutaAyudaCHM, rutaAyudaHTML);
            }

        }

        public void modificarstock(string tabla, string idarticulo, string parametroid,string stocknuevo, string parametrostock)
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

        public string ultimapoliza()
        {
            string ultima ="0";
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
            else if (!busqueda.Read()) {
                ultima = "0";
            }
            return ultima;
        }

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

        public string idcuenta(string nombre)
        {
            string idcuenta = "";
            string sql = "SELECT * FROM cuenta WHERE nombre LIKE '%" + nombre +"%';";
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
