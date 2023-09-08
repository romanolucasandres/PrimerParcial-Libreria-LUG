using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BELibro :Entidad
    {
        private BEEditorial editorial;
        public int ISBN { get; set; }
        public string Titulo { get; set; }
        public decimal Precio { get; set; }
        public string Genero { get; set; }
        public string Autor { get; set; }
        public string Formato { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }

        //Relacion 1 a 1
        public BEEditorial Editorial { get { return editorial; } set { editorial = value; } }

        public string Estado { get; set; }

        public abstract decimal DescuentoCalculado();

        public BELibro()
        {
            
        }
       

    }

    public enum Genero
    {
        Policial,
        Ciencia_Ficcion
    };

    public enum Formato
    {
        Impreso,
        Digital
    };

    

    
}
