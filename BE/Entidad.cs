﻿using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Entidad : IEntidad
    {
        public int Codigo { get; set; }
    }
}
