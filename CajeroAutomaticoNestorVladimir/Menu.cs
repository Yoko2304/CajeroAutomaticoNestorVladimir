using CajeroAutomaticoNestorVladimir.Logica;
using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir
{
    public class Menu
    {
        #region almacenamiento
        Bancos bancosData = new Bancos();
        Cajeros CajerosData = new Cajeros();
        Cuentas cuentasData = new Cuentas();
        PuntosColombia puntosColombiaData = new PuntosColombia();
        Topes topesData = new Topes();
        Usuarios usuariosData = new Usuarios();
        Transferencias transferenciasData = new Transferencias();
        Retiros retirosData = new Retiros();
        #endregion

        #region datos de captura
        int cedula = 0; //solicitar dato por consola
        string contraseña = string.Empty; //solicitar dato por consola
        int valorOperacion = 0; //solicitar dato por consola
        int cajero_Id = 0; //solicitar dato por consola
        #endregion

        #region Variables de sesion
        public Usuario usuarioSesion = null;
        public Cuenta cuentaSesion = null;
        Usuario usuarioNuevo = null;
        Puntos puntosColombia = null;
        public int saldo = 0;
        bool precargarDatos = false;
        int cantidad = 0;
        #endregion

        public void ListaOperaciones(EnumeradorMenu tipoMenu)
        {
            switch (tipoMenu)
            {
                case EnumeradorMenu.InicioSesion:
                    InicioSesion(cedula,contraseña);
                    break;
                case EnumeradorMenu.Registro:
                    Registro();
                    break;
                case EnumeradorMenu.ConsultarSaldo:
                    ConsultarSaldo(cedula);
                    break;
                case EnumeradorMenu.RealizarRetiro:
                    RealizarRetiro(cedula, valorOperacion);
                    break;
                case EnumeradorMenu.RealizarTransferencias:
                    RealizarTransferencias(cedula, valorOperacion);
                    break;
                case EnumeradorMenu.ConsultarPuntos:
                    ConsultarPuntos(cedula);
                    break;
                case EnumeradorMenu.CanjearPuntos:
                    CanjearPuntos(cedula, cantidad);
                    break;
            }
        }

        #region 1 Iniciar sesion
        public bool InicioSesion(int cedulaIngresada, string contraseña)
        {
            Usuario usuario = usuariosData.ConsultarUsuario(cedulaIngresada, contraseña);
            if (usuario != null)
            {
                usuarioSesion = usuario;
                cedula = cedulaIngresada;
                cuentaSesion = cuentasData.ConsultarCuenta(cedula);
                return true;
            }

            return false;
        }
        #endregion

        #region 2 Registrarse
        public bool Registro()
        {
            return usuariosData.NuevoUsuario(usuarioNuevo);
        }
        #endregion

        #region 3 Consultar saldo
        public int ConsultarSaldo(int cedula)
        {
            saldo = cuentasData.ConsultarCuenta(cedula).Saldo;
            return saldo;
        }
        #endregion

        #region 4 Retiros
        public bool RealizarRetiro(int cedula, int valor)
        {
            bool operacionValida = cuentasData.RetirarFondos(cedula,valor);
            if (operacionValida)
                retirosData.NuevoRetiro(new Retiro() { Valor = valor, Usuario_Id = usuarioSesion.Cedula, Cuenta_Id = cuentaSesion.Numero, Cajero_Id = cajero_Id });

            return operacionValida;
        }
        #endregion

        #region 5 Transferencias
        public bool RealizarTransferencias(int cedula, int valor)
        {
            bool operacionValida = cuentasData.AgregarFondos(cedula, valor);
            if (operacionValida)
                transferenciasData.NuevaTransferencia(new Transferencia() { Valor = valor, Usuario_Id = usuarioSesion.Cedula, Cuenta_Id = cuentaSesion.Numero });

            return operacionValida;
        }
        #endregion

        #region 6 Consultar puntos
        public Puntos ConsultarPuntos(int cedula)
        {
            puntosColombia = puntosColombiaData.ConsultarPuntos(cedula);
            return puntosColombia;
        }
        #endregion

        #region 7 Canjear puntos
        public bool CanjearPuntos(int cedula, int cantidad)
        {
            return puntosColombiaData.CanjearPuntos(cedula,cantidad);
        }
        #endregion

        #region Precargar datos
        public void PrecargaDatos()
        {
            if (!precargarDatos)
            {
                bancosData.bancos.Add(new Banco() { Nombre = "Banco Agrario", Nit = 0000000001, Estado = true });
                bancosData.bancos.Add(new Banco() { Nombre = "Banco Bogota", Nit = 0000000002, Estado = true });
                bancosData.bancos.Add(new Banco() { Nombre = "Banco Occidente", Nit = 0000000003, Estado = true });
                bancosData.bancos.Add(new Banco() { Nombre = "Banco popular", Nit = 0000000004, Estado = true });
                bancosData.bancos.Add(new Banco() { Nombre = "Bancolombia", Nit = 0000000005, Estado = true });

                CajerosData.cajeros.Add(new Cajero() { Nombre = "Cajero Banco Agrario", Banco_Id = 0000000001, Identificador = 1, Estado = true });
                CajerosData.cajeros.Add(new Cajero() { Nombre = "Cajero Banco Bogota", Banco_Id = 0000000002, Identificador = 2, Estado = true });
                CajerosData.cajeros.Add(new Cajero() { Nombre = "Cajero Banco Occidente", Banco_Id = 0000000003, Identificador = 3, Estado = true });
                CajerosData.cajeros.Add(new Cajero() { Nombre = "Cajero Banco popular", Banco_Id = 0000000004, Identificador = 4, Estado = true });
                CajerosData.cajeros.Add(new Cajero() { Nombre = "Cajero Bancolombia", Banco_Id = 0000000005, Identificador = 5, Estado = true });

                usuariosData.usuarios.Add(new Usuario() { Nombres = "Jose", Apellidos = "Mora", Cedula = 1000000001, Contraseña = "Prueba1", Estado = true });
                usuariosData.usuarios.Add(new Usuario() { Nombres = "Maria", Apellidos = "Casas", Cedula = 1000000002, Contraseña = "Prueba1", Estado = true });
                usuariosData.usuarios.Add(new Usuario() { Nombres = "Pedro", Apellidos = "Capa", Cedula = 1000000003, Contraseña = "Prueba1", Estado = true });
                usuariosData.usuarios.Add(new Usuario() { Nombres = "Camila", Apellidos = "Alvarado", Cedula = 1000000004, Contraseña = "Prueba1", Estado = true });
                usuariosData.usuarios.Add(new Usuario() { Nombres = "Jairo", Apellidos = "Vargas", Cedula = 1000000005, Contraseña = "Prueba1", Estado = true });

                cuentasData.cuentas.Add(new Cuenta() { Saldo = 0, Numero = 921000001, Banco_Id = 0000000001, Usuario_Id = 1000000001, Estado = true });
                cuentasData.cuentas.Add(new Cuenta() { Saldo = 0, Numero = 921000002, Banco_Id = 0000000002, Usuario_Id = 1000000002, Estado = true });
                cuentasData.cuentas.Add(new Cuenta() { Saldo = 0, Numero = 921000003, Banco_Id = 0000000003, Usuario_Id = 1000000003, Estado = true });
                cuentasData.cuentas.Add(new Cuenta() { Saldo = 0, Numero = 921000004, Banco_Id = 0000000004, Usuario_Id = 1000000004, Estado = true });
                cuentasData.cuentas.Add(new Cuenta() { Saldo = 0, Numero = 921000005, Banco_Id = 0000000005, Usuario_Id = 1000000005, Estado = true });

                puntosColombiaData.puntos.Add(new Puntos() { Usuario_Id = 1000000001, Cantidad = 0, Estado = true });
                puntosColombiaData.puntos.Add(new Puntos() { Usuario_Id = 1000000002, Cantidad = 0, Estado = true });
                puntosColombiaData.puntos.Add(new Puntos() { Usuario_Id = 1000000003, Cantidad = 0, Estado = true });
                puntosColombiaData.puntos.Add(new Puntos() { Usuario_Id = 1000000004, Cantidad = 0, Estado = true });
                puntosColombiaData.puntos.Add(new Puntos() { Usuario_Id = 1000000005, Cantidad = 0, Estado = true });

                precargarDatos = true;
            }
        }
        #endregion
    }
}
