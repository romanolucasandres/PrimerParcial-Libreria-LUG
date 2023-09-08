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
    public partial class Reserva_Libro : Form
    {
        BLLLibro bLLLibro;
        BLLCliente cliente;
        BEAsociacion beAsociacion;
        BLLAsociacion asociacion;
        BELibro libro;
        BLLAsociacion oBLLAsociacion;
       
        public Reserva_Libro()
        {
            InitializeComponent();
            bLLLibro = new BLLLibro();
            cliente = new BLLCliente();
            asociacion = new BLLAsociacion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            beAsociacion = new BEAsociacion();
            beAsociacion.Cliente = (BECliente)comboBox1.SelectedItem;     
            beAsociacion.Libro = (BELibro)comboBox2.SelectedItem;
            beAsociacion.Estado = "Asociado";
            asociacion.Alta(beAsociacion);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = asociacion.Listar();
            


        }

        

        private void Reserva_Libro_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = bLLLibro.ListarLibros();
            comboBox2.ValueMember = "Titulo";
            comboBox2.DisplayMember = "Titulo";

            comboBox1.DataSource = cliente.Listar();
            comboBox1.ValueMember = "Apellido";
            comboBox1.DisplayMember = "Apellido";

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = asociacion.Listar();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                    beAsociacion = new BEAsociacion();
                    beAsociacion.Cliente = (BECliente)comboBox1.SelectedItem;
                    beAsociacion.Libro = (BELibro)comboBox2.SelectedItem;

               

                    // Inicializa oBLLAsociacion antes de utilizarlo
                    oBLLAsociacion = new BLLAsociacion();
                    if (beAsociacion.Estado == "Asociado")
                    {
                        oBLLAsociacion.Baja(beAsociacion);
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = asociacion.Listar();
                        
                    }
                    else
                    {
                        MessageBox.Show("No se pueden eliminar los pagos");
                    }
                
               
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                
                comboBox1.Text = row.Cells["Cliente"].Value.ToString();
                comboBox2.Text = row.Cells["Libro"].Value.ToString();
           
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            beAsociacion = new BEAsociacion();
            beAsociacion.Cliente = (BECliente)comboBox1.SelectedItem;
           

            // Obtiene el valor seleccionado del ComboBo

            beAsociacion.Libro = (BELibro)comboBox2.SelectedItem;
            
            beAsociacion.Estado = "Pagado";
            
            beAsociacion.Descuento = Convert.ToDecimal(beAsociacion.Libro.DescuentoCalculado());
            asociacion.AlpaPago(beAsociacion);
           
                
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = asociacion.Listar();
            
        }
    }
}
