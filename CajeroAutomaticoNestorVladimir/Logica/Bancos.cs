using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Logica
{
    public class Bancos
    {
        public List<Banco> bancos = new List<Banco>();
        public void NuevoBanco(Banco banco)
        {
            bancos.Add(banco);
        }

        public bool EditarBanco(int nit, Banco datos)
        {
            try
            {
                for (int i = 0; i < bancos.Count; i++)
                {
                    Banco banco = bancos[i];
                    if (banco.Nit == nit)
                        bancos[i] = datos;
                }

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Banco ConsultarBanco(int nit)
        {
            foreach(var banco in bancos)
            {
                if (banco.Nit == nit)
                    return banco;
            }

            return null;
        }
    }
}
