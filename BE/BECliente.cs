using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BECliente : Entidad
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

        public BECliente(int DNI, string apellido)
        {
            
        }
        public BECliente()
        {
            
        }
        public override string ToString()
        {
            return String.Format($"{Apellido}");
        }
    }
}
