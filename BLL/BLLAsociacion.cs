using BE;
using MPP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLAsociacion
    {
        MPPAsociacion mpp = new MPPAsociacion();

        public void Alta(BEAsociacion x)
        {
            mpp.Alta(x);
        }
        public void AlpaPago(BEAsociacion x)
        {
            mpp.AltaPago(x);
        }
        public void stock(BELibro libro)
        {
            mpp.stock(libro);
        }
        public void Baja(BEAsociacion x)
        {
            mpp.Baja(x);
        }
      
        public List<BEAsociacion> Listar()
        {
            return mpp.Listar();
        }

        public List<BEAsociacion> ListarPoliciales()
        {
            return mpp.ListarPoliciales();
        }
        public List<BEAsociacion> ListarCF()
        {
            return mpp.ListarCF();
        }
       
        public List<BEAsociacion> ListarDes()
        {
            return mpp.ListarDes();
        }
    }
}
