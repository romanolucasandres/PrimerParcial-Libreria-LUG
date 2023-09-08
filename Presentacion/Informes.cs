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

namespace Presentacion
{
    public partial class Informes : Form
    {
        BLLLibro oBLLLibro;
        BLLAsociacion asociacion;
        public Informes()
        {
            InitializeComponent();
            oBLLLibro = new BLLLibro();
            asociacion = new BLLAsociacion();
        }

        private void Libro_Por_Genero_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = oBLLLibro.ListarLibros();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Columns["Libro"].Visible = true;
            dataGridView1.DataSource=asociacion.ListarPoliciales();
            dataGridView1.Columns["Cliente"].Visible = false;
            dataGridView1.Columns["Estado"].Visible = false;
            dataGridView1.Columns["Descuento"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["Libro"].Visible = true;
            dataGridView1.DataSource = asociacion.ListarCF();
            dataGridView1.Columns["Cliente"].Visible = false;
            dataGridView1.Columns["Estado"].Visible = false;
            dataGridView1.Columns["Descuento"].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["Descuento"].Visible = true;
            dataGridView1.DataSource =asociacion.ListarDes();
            dataGridView1.Columns["Cliente"].Visible = true;
            dataGridView1.Columns["Estado"].Visible = false;
            dataGridView1.Columns["Libro"].Visible = false;

        }
    }
}
