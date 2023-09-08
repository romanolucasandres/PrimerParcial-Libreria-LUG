using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Menu : Form
    {
        FRMLibro frmlibro;
        FRMEditorial frmeditorial;
      
        Informes lbr;
        Reserva_Libro reserva;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void aBMLibroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmlibro != null)
                frmlibro.BringToFront();
            else
            {
                frmlibro = new FRMLibro();
                frmlibro.FormClosed += (o, args) => frmlibro = null;
                frmlibro.MdiParent = this;
                frmlibro.Show();
            }
        }

        private void aBMEditorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmeditorial != null)
                frmeditorial.BringToFront();
            else
            {
                frmeditorial = new FRMEditorial();
                frmeditorial.FormClosed += (o, args) => frmeditorial = null;
                frmeditorial.MdiParent = this;
                frmeditorial.Show();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Ud. está por salir del programa. Presione Aceptar para confirmar.", "Aviso", MessageBoxButtons.OKCancel);
            if (dialog is DialogResult.OK)
            {
                Application.Exit();
            }
        }

       

        private void rESERVASToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (reserva != null)
                reserva.BringToFront();
            else
            {
                reserva = new Reserva_Libro();
                reserva.FormClosed += (o, args) => reserva = null;
                reserva.MdiParent = this;
                reserva.Show();
            }
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lbr != null)
                lbr.BringToFront();
            else
            {
                lbr = new Informes();
                lbr.FormClosed += (o, args) => lbr = null;
                lbr.MdiParent = this;
                lbr.Show();
            }
        }
    }
}
