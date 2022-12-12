using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Logica
{
    public class Retiros
    {
        public List<Retiro> retiros = new List<Retiro>();
        public bool NuevoRetiro(Retiro retiro)
        {
            try
            {
                retiros.Add(retiro);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public List<Retiro> ConsultarRetiros(int usuario)
        {
            List<Retiro> retirosUsuario = new List<Retiro>();
            foreach (var retiro in retiros)
            {
                if (retiro.Usuario_Id == usuario)
                    retirosUsuario.Add(retiro);
            }

            return retirosUsuario;
        }
    }
}
