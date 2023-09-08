using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using MPP;

namespace BLL
{
    public class BLLCliente : Igestor<BECliente>,IListar<BECliente>
    {
        MPPCliente mppCliente = new MPPCliente();

        public void Alta(BECliente x)
        {
            throw new NotImplementedException();
        }

        public void Baja(BECliente x)
        {
            throw new NotImplementedException();
        } 
        public void AsociarClienteLibro(BECliente cliente, BELibro libro)
        {
            mppCliente.AsociarClienteLibro(cliente, libro);
        }

        public List<BECliente> Listar()
        {
            return mppCliente.Listar();
        }

        public void Modifcacion(BECliente x)
        {
            throw new NotImplementedException();
        }
    }
}
