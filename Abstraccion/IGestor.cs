using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface Igestor<T> where T : IEntidad
    {
        

        #region Métodos ABM Genéricos

        void Alta(T x);
        void Baja(T x);
        void Modifcacion(T x);
        #endregion
    }
}
