﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCasoEstudio2.Entity
{
    public class CasasEntity
    {
        public long IdCasa { get; set; }
        public string DescripcionCasa { get; set; }
        public decimal PrecioCasa { get; set; }
        public string UsuarioAlquiler { get; set; }
        public DateTime? FechaAlquiler { get; set; }
    }
}