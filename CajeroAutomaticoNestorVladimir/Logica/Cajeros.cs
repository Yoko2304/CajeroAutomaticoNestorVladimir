using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Logica
{
    public class Cajeros
    {
        public List<Cajero> cajeros = new List<Cajero>();
        public void NuevoCajero(Cajero Cajero)
        {
            cajeros.Add(Cajero);
        }

        public bool EditarCajero(int nit, Cajero datos)
        {
            try
            {
                for (int i = 0; i < cajeros.Count; i++)
                {
                    Cajero Cajero = cajeros[i];
                    if (Cajero.Identificador == nit)
                        cajeros[i] = datos;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cajero ConsultarCajero(int identificador)
        {
            foreach (var Cajero in cajeros)
            {
                if (Cajero.Identificador == identificador)
                    return Cajero;
            }

            return null;
        }
    }
}
