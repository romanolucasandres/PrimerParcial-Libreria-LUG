using Abstraccion;
using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace MPP
{
    public class MPPEditorial : Igestor<BEEditorial>
    {
        //declaro objeto para acceso a datos
        AccesoDatos oAccesoDatos;
        //declaro la variable para la query
        string query = null;
        public MPPEditorial()
        {
            oAccesoDatos = new AccesoDatos();
        }
        public void Alta(BEEditorial x)
        {
            if (!ExisteCUIT(x))
            {
                query = null;
                query = $"insert into Editoriales(RazonSocial,CUIT) values ('{x.RazonSocial}','{x.CUIT}')";
                oAccesoDatos.EjecutarConsulta(query);
            }
            else
            {
                throw new Exception("El CUIT ya se encuentra en la base de datos");
            }
             oAccesoDatos.EjecutarConsulta(string.Format(query));
        }

        public void Baja(BEEditorial x)
        {
            
        }

        public List<BEEditorial> Listar()
        {
            try
            {
                
                List<BEEditorial> lst = new List<BEEditorial>();
                //accedo a la base
                query = null;
                query = "Select Editoriales.Id,Editoriales.RazonSocial, Editoriales.CUIT from Editoriales";
                DataTable dt = oAccesoDatos.LeerDT(query);

                foreach (DataRow dr in dt.Rows)
                {
                    BEEditorial beEditorial = new BEEditorial();
                    beEditorial.Codigo = Convert.ToInt32(dr["Id"].ToString());
                    beEditorial.RazonSocial = dr["RazonSocial"].ToString();
                    beEditorial.CUIT = dr["CUIT"].ToString();
                    //agrego a la lista
                    lst.Add(beEditorial);
                }
                //retorno lista
                return lst;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public void Modifcacion(BEEditorial x)
        {
            query = null;
            query = $"update Editoriales set RazonSocial = '{x.RazonSocial}', CUIT = '{x.CUIT}'";
            oAccesoDatos.EjecutarConsulta(query);
        }

        private bool ExisteCUIT(BEEditorial x)
        {
            oAccesoDatos = new DAL.AccesoDatos();
            query = $"select count(CUIT) from Editoriales where CUIT = {x.CUIT}";
            var resultado = oAccesoDatos.LeerEscalar(query);
            if (resultado > 0)   // si esta asociado, devuelve true
                return true;
            else                 // no esta asociada, devuelve false
                return false;
        }
    }
}
