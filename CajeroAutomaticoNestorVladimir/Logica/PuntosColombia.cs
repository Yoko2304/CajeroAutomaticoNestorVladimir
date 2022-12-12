using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Logica
{
    public class PuntosColombia
    {
        public List<Puntos> puntos = new List<Puntos>();
        public void AgregarPuntos(Puntos puntosColombia)
        {
            puntos.Add(puntosColombia);
        }

        public Puntos ConsultarPuntos(int usuario)
        {
            for (int i = 0; i < puntos.Count; i++)
            {
                Puntos puntosColombia = puntos[i];
                if (puntosColombia.Usuario_Id == usuario)
                    return puntosColombia;
            }

            return null;
        }


        public bool EditarPuntos(int usuario, Puntos datos)
        {
            try
            {
                for (int i = 0; i < puntos.Count; i++)
                {
                    Puntos puntosColombia = puntos[i];
                    if (puntosColombia.Usuario_Id == usuario)
                        puntos[i] = datos;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CanjearPuntos(int usuario, int cantidad)
        {
            try
            {
                for (int i = 0; i < puntos.Count; i++)
                {
                    Puntos puntosColombia = puntos[i];
                    if (puntosColombia.Usuario_Id == usuario)
                    {
                        if (puntos[i].Cantidad >= cantidad)
                            puntos[i].Cantidad = puntos[i].Cantidad - cantidad;
                        else
                            return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
