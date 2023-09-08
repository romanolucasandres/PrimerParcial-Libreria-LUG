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
    public partial class FRMLibro : Form
    {
        BLLLibro bllLibro;
        BELibroPolicial beLibroPolicial;
        BELibroCF beLibroCF;
        BLLEditorial bllEditorial;

        public FRMLibro()
        {
            InitializeComponent();
            bllLibro = new BLLLibro();
            bllEditorial = new BLLEditorial();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CMBGenero.Text == "Policial")
                {
                    beLibroPolicial = new BELibroPolicial();
                    beLibroPolicial.ISBN = Convert.ToInt32(textBox1.Text);
                    beLibroPolicial.Titulo = textBox2.Text;
                    beLibroPolicial.Autor = textBox4.Text;
                    beLibroPolicial.Cantidad = Convert.ToInt32(textBox5.Text);
                    beLibroPolicial.Editorial = (BEEditorial)CMBEditorial.SelectedItem;
                    beLibroPolicial.Formato = CMBFormato.SelectedItem.ToString();
                    beLibroPolicial.Genero = CMBGenero.SelectedItem.ToString();
                    beLibroPolicial.Precio = Convert.ToDecimal(textBox3.Text);
                    beLibroPolicial.Categoria = CMBCategoria.SelectedItem.ToString();
                    beLibroPolicial.Estado = "Libre";
                    bllLibro.Alta(beLibroPolicial);
                    Mostrar();
                    Limpiar();
                }
                else
                {
                    beLibroCF = new BELibroCF(CMBAdapta.Text);
                    beLibroCF.ISBN = Convert.ToInt32(textBox1.Text);
                    beLibroCF.Titulo = textBox2.Text;
                    beLibroCF.Autor = textBox4.Text;
                    beLibroCF.Cantidad = Convert.ToInt32(textBox5.Text);
                    beLibroCF.Genero = CMBGenero.Text;
                    beLibroCF.Editorial = (BEEditorial)CMBEditorial.SelectedItem;
                    beLibroCF.Formato = CMBFormato.Text;
                    beLibroCF.Precio = Convert.ToDecimal(textBox3.Text);
                    beLibroCF.Estado = "Libre";
                    bllLibro.Alta(beLibroCF);
                    Mostrar();
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
       
        private void FRMLibro_Load(object sender, EventArgs e)
        {
            CMBGenero.DataSource = Enum.GetValues(typeof(Genero));
            CMBGenero.SelectedIndex = 0;

            CMBFormato.DataSource = Enum.GetValues(typeof(Formato));
            CMBFormato.SelectedIndex = 0;

            CMBEditorial.DataSource = bllEditorial.Listar();
            CMBEditorial.ValueMember = "RazonSocial";
            CMBEditorial.DisplayMember = "RazonSocial";

            CMBAdapta.Enabled = false;
            CMBCategoria.Enabled = false;

            Mostrar();
            ModoSeleccion();
        }

        private void ModoSeleccion()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }


        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bllLibro.ListarLibros();
            //dataGridView1.Columns["Categoria"].Visible = true;
            //dataGridView1.Columns["AdaptacionFilmografica"].Visible = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        private void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            CMBGenero.SelectedIndex = 0;
            CMBFormato.SelectedIndex = 0;
            CMBEditorial.SelectedIndex = 0;
            CMBAdapta.SelectedIndex = -1;
            CMBCategoria.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                if (CMBGenero.Text == "Policial")
                {
                    beLibroPolicial = new BELibroPolicial();
                    beLibroPolicial.ISBN = Convert.ToInt32(textBox1.Text);
                    bllLibro.Baja(beLibroPolicial);
                    Mostrar();
                }
                else
                {
                    beLibroCF = new BELibroCF(CMBAdapta.Text);
                    beLibroCF.ISBN = Convert.ToInt32(textBox1.Text);
                    bllLibro.Baja(beLibroCF);
                    Mostrar();
                }
                
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar", "Aviso");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int ISBN = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ISBN"].Value);
                if (CMBGenero.Text == "Policial")
                {
                    beLibroPolicial = new BELibroPolicial();
                    beLibroPolicial.ISBN = Convert.ToInt32(textBox1.Text);
                    beLibroPolicial.Titulo = textBox2.Text;
                    beLibroPolicial.Autor = textBox4.Text;
                    beLibroPolicial.Cantidad = Convert.ToInt32(textBox5.Text);
                    beLibroPolicial.Editorial = (BEEditorial)CMBEditorial.SelectedItem;
                    beLibroPolicial.Formato = CMBFormato.SelectedItem.ToString();
                    beLibroPolicial.Genero = CMBGenero.SelectedItem.ToString();
                    beLibroPolicial.Precio = Convert.ToDecimal(textBox3.Text);
                    beLibroPolicial.Categoria = CMBCategoria.SelectedItem.ToString();
                    beLibroPolicial.Estado = "Libre";
                    bllLibro.Modifcacion(beLibroPolicial);
                    Mostrar();
                    Limpiar();
                }
                else
                {
                    beLibroCF = new BELibroCF(CMBAdapta.Text);
                    beLibroCF.ISBN = Convert.ToInt32(textBox1.Text);
                    beLibroCF.Titulo = textBox2.Text;
                    beLibroCF.Autor = textBox4.Text;
                    beLibroCF.Cantidad = Convert.ToInt32(textBox5.Text);
                    beLibroCF.Genero = CMBGenero.Text;
                    beLibroCF.Editorial = (BEEditorial)CMBEditorial.SelectedItem;
                    beLibroCF.Formato = CMBFormato.Text;
                    beLibroCF.Precio = Convert.ToDecimal(textBox3.Text);
                    beLibroCF.AdaptacionFilmografica = CMBAdapta.Text;
                    beLibroCF.Estado = "Libre";
                    bllLibro.Modifcacion(beLibroCF);
                    Mostrar();
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar", "Aviso");
            }

        }
      

        private void CMBGenero_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (CMBGenero.Text == "Policial")
            {
                CMBAdapta.Enabled = false;
                CMBCategoria.Enabled = true;
                CMBCategoria.DataSource = Enum.GetValues(typeof(Categoria));
                CMBCategoria.SelectedIndex = 0;
                CMBCategoria.Text = "Seleccione Categoría";
            }
            else if (CMBGenero.Text == "Ciencia_Ficcion")
            {
                CMBAdapta.Enabled = true;
                CMBCategoria.Enabled = false;

                CMBAdapta.DataSource = Enum.GetValues(typeof(AdapFilm));
                CMBAdapta.SelectedIndex = 0;
                CMBAdapta.Text = "Seleccione SI/NO";

            }
        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ISBN"].Value.ToString();
                textBox2.Text = row.Cells["Titulo"].Value.ToString();
                textBox3.Text = row.Cells["Precio"].Value.ToString();
                textBox4.Text = row.Cells["Autor"].Value.ToString();
                textBox5.Text = row.Cells["Cantidad"].Value.ToString();
                CMBGenero.Text = row.Cells["Genero"].Value.ToString();
                CMBFormato.Text = row.Cells["Formato"].Value.ToString();
                CMBEditorial.Text = row.Cells["Editorial"].Value.ToString();

                if (CMBGenero.Text == "Policial")
                {
                    CMBCategoria.Text = row.Cells["Categoria"].Value.ToString();
                }
                else
                {
                    CMBAdapta.Text = row.Cells["AdaptacionFilmografica"].Value.ToString();
                }
            }
        }
    }
}


