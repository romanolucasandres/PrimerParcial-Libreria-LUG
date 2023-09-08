using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEAsociacion
    {
        private BECliente ocliente;
        private BELibro olibro;
       
        public BECliente Cliente { get => ocliente; set => ocliente = value; }
        public BELibro Libro { get => olibro; set => olibro = value; }
        public decimal Descuento { get; set; }
        public string Estado { get; set; }
        
        public void DevolverEstado(int num)
        {
            if(num == 1)
            {
                Estado = Estados.Libre.ToString();
            }
            else if(num == 2)
            {
                Estado=Estados.Asociado.ToString();
            }
            else if(num == 3)
            {
                Estado=Estados.Pagado.ToString();
            }

        }

        
        public BEAsociacion()
        {
            


        }
    }
    public enum Estados
    {
        Libre,
        Asociado,
        Pagado
    };
}
