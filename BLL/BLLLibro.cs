using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLLibro : Igestor<BELibro>
    {
        MPPLibro mpplibro= new MPPLibro();

     

        public void Alta(BELibro x)
        {
            mpplibro.Alta(x);
        }

      
        public void Baja(BELibro x)
        {
            mpplibro.Baja(x);
        }


        public List<BELibro> ListarLibros()
        {
            return mpplibro.ListarLibros();
        }
       

    

        public void Modifcacion(BELibro x)
        {
            mpplibro.Modifcacion(x);
        }
    }
}
