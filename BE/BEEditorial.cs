using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEEditorial:Entidad
    {
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }

        public BEEditorial() { }
        public BEEditorial(String st)
        {
            RazonSocial = st;
        }
      
        public override string ToString()
        {
            return String.Format($"{RazonSocial}");
        }
    }
}
