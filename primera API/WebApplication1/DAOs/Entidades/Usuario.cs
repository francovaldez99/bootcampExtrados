﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs.Entidades
{
    public class Usuario
    {
        public string id { get; set; }

        public string nombre { get; set; }
        public string email { get; set; }
        public int edad { get; set; }
    }
}