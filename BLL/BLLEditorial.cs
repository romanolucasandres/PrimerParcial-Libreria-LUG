using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLEditorial : Igestor<BEEditorial>,IListar<BEEditorial>
    {
        MPPEditorial mppEditorial = new MPPEditorial();
        public void Alta(BEEditorial x)
        {
           mppEditorial.Alta(x);
        }

        public void Baja(BEEditorial x)
        {
            throw new NotImplementedException();
        }

        public List<BEEditorial> Listar()
        {
            return mppEditorial.Listar();
        }

        public void Modifcacion(BEEditorial x)
        {
            throw new NotImplementedException();
        }
    }
}
