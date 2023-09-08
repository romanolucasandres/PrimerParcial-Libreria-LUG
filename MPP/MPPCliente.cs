using Abstraccion;
using BE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MPPCliente : Igestor<BECliente>
    {
        //declaro objeto para acceso a datos
        AccesoDatos acceso;
        //declaro la variable para la query
        string query = null;
        public MPPCliente()
        {
            acceso = new AccesoDatos();
        }
        public void Alta(BECliente x)
        {
            query = null;
            query = $"insert into Clientes(Nombre,Apellido,DNI) values ('{x.Nombre}','{x.Apellido}','{x.DNI}'";
            acceso.EjecutarConsulta(query);
        }

        public void Baja(BECliente x)
        {
            if (!ExisteClienteAsociado(x))
            {
                query = null;
                query = $"delete from Clientes where Id = {x.Codigo}";
                acceso.EjecutarConsulta(string.Format(query));

            }
            else
            {
                throw new Exception($"El cliente se encuentra ASOCIADO a un Libro.");
            }
        }

        public List<BECliente> Listar()
        {
            try
            {
                //declaro una lista de administrativos
                List<BECliente> lst = new List<BECliente>();
                //accedo a la base
                DataTable dt = acceso.LeerDT("Select * from Clientes");

                foreach (DataRow dr in dt.Rows)
                {
                    BECliente beCliente = new BECliente();
                    beCliente.Codigo = Convert.ToInt32(dr["Id"].ToString());
                    beCliente.Nombre = dr["Nombre"].ToString();
                    beCliente.Apellido = dr["Apellido"].ToString();
                    beCliente.DNI = dr["DNI"].ToString();

                    //agrego a la lista
                    lst.Add(beCliente);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        public void Modifcacion(BECliente x)
        {
            query = null;
            query = $"update Clientes set  Nombre = '{x.Nombre}', Apellido = '{x.Apellido}', DNI = '{x.DNI}' where Id='{x.Codigo}'";
            acceso.EjecutarConsulta(query);
        }

        private bool ExisteClienteAsociado(BECliente oBEcliente)
        {
            acceso = new DAL.AccesoDatos();
            query = ("select count(Cliente_Id) from Libro_Cliente where Cliente_Id = " + oBEcliente.Codigo + "");
            int resultado = acceso.LeerEscalar(query);
            if (resultado > 0)   // si esta asociado, devuelve true
                return true;
            else                 // no esta asociada, devuelve false
                return false;
        }

        public void AsociarClienteLibro(BECliente cliente, BELibro libro)
        {
            //if (!ExisteClienteAsociado(cliente))
            //{
                // actualizo el codigo de la tarjeta en la tabla del cliente, luego el estado de la tarjeta pasa a activa
               query = $"Insert into Cliente_Libro(Id_Cliente, Id_Libro,Estado,Descuento) values ('{cliente.Codigo}','{libro.Codigo}', Asociado,0)";

                acceso.EjecutarConsulta(query);
           
        }
    }
}
