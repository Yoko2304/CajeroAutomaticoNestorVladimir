using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Modelos
{
    public class Retiro
    {
        public int Cuenta_Id { get; set; }
        public int Usuario_Id { get; set; }
        public int Cajero_Id { get; set; }
        public int Valor { get; set; }
    }
}
