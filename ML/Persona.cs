﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string FechaDeNacimiento { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public List<object> Personas { get; set; }
    }
}
