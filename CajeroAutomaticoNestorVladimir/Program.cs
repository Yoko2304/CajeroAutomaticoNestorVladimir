using System;

namespace CajeroAutomaticoNestorVladimir
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Menu menuCajero = new Menu();
            menuCajero.PrecargaDatos();
            bool detenerFlujo = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al cajero automatico.");
                Console.WriteLine("Por favor introduce tu numero de cedula:");
                String usuario;
                usuario = Console.ReadLine();
                Console.WriteLine("Por favor introduce tu contraseña:");
                String contraseña;
                contraseña = Console.ReadLine();
                try
                {
                    int numeroCedula = Convert.ToInt32(usuario);
                    if (menuCajero.InicioSesion(numeroCedula, contraseña))
                    {
                        menuCajero.ListaOperaciones(Modelos.EnumeradorMenu.ConsultarSaldo);
                        Console.WriteLine("Bienvenido " + menuCajero.usuarioSesion.Nombres);
                        Console.WriteLine("Su saldo es de: " + menuCajero.saldo);

                        Console.WriteLine("Ingrese 1 para hacer una transferencia o 2 para un retiro:");
                        String operacion;
                        operacion = Console.ReadLine();
                        int numeroOperacion = Convert.ToInt32(operacion);

                        if (numeroOperacion == 1)
                        {
                            Console.WriteLine("Ingrese el valor de la transferencia:");
                            String valorTransferencia;
                            valorTransferencia = Console.ReadLine();
                            int valorTransferenciaInt = Convert.ToInt32(operacion);
                            menuCajero.valorOperacion = valorTransferenciaInt;
                            menuCajero.ListaOperaciones(Modelos.EnumeradorMenu.RealizarTransferencias);
                        }
                        else if (numeroOperacion == 2)
                        {
                            Console.WriteLine("Ingrese el valor del retiro:");
                            String valorRetiro;
                            valorRetiro = Console.ReadLine();
                            int valorRetiroInt = Convert.ToInt32(operacion);
                            menuCajero.valorOperacion = valorRetiroInt;
                            menuCajero.ListaOperaciones(Modelos.EnumeradorMenu.RealizarRetiro);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor ingrese datos validos.");
                        Console.WriteLine("Si no esta registrado en la plataforma, por favor ingrese el numero 2 para registrarse, 1 para volver a intentarlo, 0 para salir del programa:");
                        String operacion;
                        operacion = Console.ReadLine();
                        int numeroOperacion = Convert.ToInt32(operacion);
                        if (numeroOperacion == 2)
                        {
                            Console.WriteLine("Por favor ingrese los datos para registrarse.");
                            Console.WriteLine("Por favor introduce tu numero de cedula:");
                            usuario = Console.ReadLine();
                            numeroCedula = Convert.ToInt32(usuario);
                            Console.WriteLine("Por favor introduce tu contraseña:");
                            contraseña = Console.ReadLine();
                            Console.WriteLine("Por favor introduce tus nombres:");
                            String nombres;
                            nombres = Console.ReadLine();
                            Console.WriteLine("Por favor introduce tus apellidos:");
                            String apellidos;
                            apellidos = Console.ReadLine();

                            menuCajero.usuarioNuevo = new Modelos.Usuario() { Estado = true, Apellidos = apellidos, Nombres = nombres, Cedula = numeroCedula, Contraseña = contraseña };
                            menuCajero.ListaOperaciones(Modelos.EnumeradorMenu.Registro);
                        }
                        else if (numeroOperacion == 1)
                        {
                            throw new Exception("Datos erroneos.");
                        }
                        else if (numeroOperacion == 0)
                        {
                            detenerFlujo = true;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ha ocurrido un error!");
                }
            } while (!detenerFlujo);
        }
    }
}
