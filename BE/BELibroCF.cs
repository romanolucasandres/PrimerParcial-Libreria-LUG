using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BELibroCF : BELibro
    {
        public string AdaptacionFilmografica { get; set; }

        public BELibroCF(string adapfilm):base()
        {
            this.AdaptacionFilmografica = adapfilm;
        }
        public BELibroCF(int ISBN, string Titulo):base()
        {
            
        }
        public BELibroCF()
        {
            
        }
        public override decimal DescuentoCalculado()
        {
           Descuento= (Precio * 25) / 100;
            return Descuento;
        }

        public override string ToString()
        {
            return String.Format($"{Titulo}");
        }
    }
    public enum AdapFilm
    {
        Si,
        No
    };
}
