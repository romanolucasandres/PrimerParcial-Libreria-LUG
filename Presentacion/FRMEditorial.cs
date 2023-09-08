using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Presentacion
{
    public partial class FRMEditorial : Form
    {
        BEEditorial beEditorial;
        BLLEditorial bLLEditorial;
        public FRMEditorial()
        {
            InitializeComponent();
            bLLEditorial = new BLLEditorial();
            
        }
        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bLLEditorial.Listar();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void Limpiar()
        {
            textBox1 = null; textBox2 = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            beEditorial = new BEEditorial();
            beEditorial.RazonSocial = textBox1.Text;
            beEditorial.CUIT= textBox2.Text;
            bLLEditorial.Alta(beEditorial);
            Mostrar();
            Limpiar();
        }

        private void FRMEditorial_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
