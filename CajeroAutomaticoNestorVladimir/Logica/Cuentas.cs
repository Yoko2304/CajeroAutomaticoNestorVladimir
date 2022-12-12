using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Logica
{
    public class Cuentas
    {
        public List<Cuenta> cuentas = new List<Cuenta>();
        public void NuevaCuenta(Cuenta Cuenta)
        {
            cuentas.Add(Cuenta);
        }

        public bool EditarCuenta(int numero, Cuenta datos)
        {
            try
            {
                for (int i = 0; i < cuentas.Count; i++)
                {
                    Cuenta cuenta = cuentas[i];
                    if (cuenta.Numero == numero)
                        cuentas[i] = datos;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AgregarFondos(int numero, int valor)
        {
            try
            {
                for (int i = 0; i < cuentas.Count; i++)
                {
                    Cuenta cuenta = cuentas[i];
                    if (cuenta.Numero == numero)
                        cuentas[i].Saldo = cuentas[i].Saldo + valor;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RetirarFondos(int numero, int valor)
        {
            try
            {
                for (int i = 0; i < cuentas.Count; i++)
                {
                    Cuenta cuenta = cuentas[i];
                    if (cuenta.Numero == numero)
                    {
                        if (cuentas[i].Saldo >= valor)
                            cuentas[i].Saldo = cuentas[i].Saldo - valor;
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

        public Cuenta ConsultarCuenta(int numero)
        {
            foreach (var cuenta in cuentas)
            {
                if (cuenta.Usuario_Id == numero)
                    return cuenta;
            }

            return null;
        }
    }
}
