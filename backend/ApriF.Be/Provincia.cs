﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApriF.Be
{
    public class Provincia
    {
        public string PaisId { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
    }
}
