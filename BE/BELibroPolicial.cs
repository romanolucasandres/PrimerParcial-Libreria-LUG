using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BELibroPolicial : BELibro
    {
        public string Categoria { get; set; }
        public override decimal DescuentoCalculado()
        {
            Descuento= (Precio * 10) / 100;
            return Descuento;
        }
        public BELibroPolicial(int ISBN, string Titulo) : base()
        {

        }
        public BELibroPolicial()
        {
            
        }
        public override string ToString()
        {
            return String.Format($"{Titulo}");
        }
    }
    public enum Categoria
    {
        Robo,
        Crimen,
        Persecucion
    };
}
