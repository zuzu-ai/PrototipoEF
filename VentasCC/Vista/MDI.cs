using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaVistaSeguridadHSC;

namespace CapaVistaMVentasCC
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCuentaContable form3 = new frmCuentaContable();
            form3.MdiParent = this;
            form3.Show();
        }

        private void morasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMantenimientoMora form3 = new frmMantenimientoMora();
            //form3.MdiParent = this;
            //form3.Show();
        }

        private void fraccionamientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMantenimientoFraccionamiento form3 = new frmMantenimientoFraccionamiento();
            //form3.MdiParent = this;
            //form3.Show();
        }

        private void tipoDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMantenimientoTipoDocumento form3 = new frmMantenimientoTipoDocumento();
            //form3.MdiParent = this;
            //form3.Show();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmCBancarias form3 = new frmCBancarias();
           form3.MdiParent = this;
           form3.Show();
        }

        private void tipoInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBancos form3 = new frmBancos();
            form3.MdiParent = this;
            form3.Show();
        }

        private void MDIVentas_Load(object sender, EventArgs e)
        {
            frmLoginHSC form = new frmLoginHSC();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtUsuario.Text = form.usuario();
            }
            else
            {
                this.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmLoginHSC form = new frmLoginHSC();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtUsuario.Text = form.usuario();
            }
            else
            { this.Close(); }
        }

		private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
		{
        }

		private void cotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
            //Heydi Quemé 9959-18-5335
            frmCotizacion form3 = new frmCotizacion();
            form3.MdiParent = this;
            form3.Show();
        }

		private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
		{
            //Heydi Quemé 9959-18-5335
            frmFacturacion form3 = new frmFacturacion();
            form3.MdiParent = this;
            form3.Show();
        }

        private void asignarComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Kevin Flores 9959-18-17632
                //frmComisiones form3 = new frmComisiones();
                //form3.MdiParent = this;
                //form3.Show();
            }catch
            {

            }
        }

        private void tipoComisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Kevin Flores 9959-18-17632
                //frmMantenimientoTipoComision form3 = new frmMantenimientoTipoComision();
                //form3.MdiParent = this;
                //form3.Show();
            }catch
            {

            }
        }

        private void movimientoInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMantenimientoMovimientoInventario form3 = new frmMantenimientoMovimientoInventario();
            //form3.MdiParent = this;

            //form3.Show();
        }

        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMantenimientoListaDePrecios form3 = new frmMantenimientoListaDePrecios();
            //form3.MdiParent = this;

            //form3.Show();
        }

        private void movimientosCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmMovimientosCC form3 = new frmMovimientosCC();
            //form3.MdiParent = this;

            //form3.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //frmEnlaceContableVentasCC form3 = new frmEnlaceContableVentasCC();
            //form3.MdiParent = this;
            //form3.Show();
        }

		private void tipoMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
		{
            frmTipoMovimiento form3 = new frmTipoMovimiento();
            form3.MdiParent = this;
            form3.Show();
        }
    }
}
