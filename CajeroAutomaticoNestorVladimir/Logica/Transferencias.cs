using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Logica
{
    public class Transferencias
    {
        public List<Transferencia> transferencias = new List<Transferencia>();
        public bool NuevaTransferencia(Transferencia transferencia)
        {
            try
            {
                transferencias.Add(transferencia);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Retiro> ConsultarTransferencias(int usuario)
        {
            List<Retiro> transferenciasUsuario = new List<Retiro>();
            foreach (var retiro in transferencias)
            {
                if (retiro.Usuario_Id == usuario)
                    transferencias.Add(retiro);
            }

            return transferenciasUsuario;
        }
    }
}
