using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Modelos
{
    public class Cuenta
    {
        public int Banco_Id { get; set; }
        public int Usuario_Id { get; set; }
        public int Numero { get; set; }
        public bool Estado { get; set; }
        public int Saldo { get; set; }
    }
}
