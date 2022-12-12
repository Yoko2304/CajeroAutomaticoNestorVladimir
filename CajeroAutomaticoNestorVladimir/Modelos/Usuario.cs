using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Modelos
{
    public class Usuario
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Cedula { get; set; }
        public bool Estado { get; set; }
        public string Contraseña { get; set; }
    }
}
