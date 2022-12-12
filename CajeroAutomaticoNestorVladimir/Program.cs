using System;

namespace CajeroAutomaticoNestorVladimir
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menuCajero = new Menu();
            menuCajero.PrecargaDatos();
            Console.WriteLine("Bienvenido al cajero automatico");
            Console.WriteLine("Por favor introduce tu numero de cedula");
            String usuario;
            usuario = Console.ReadLine();
            //Console.WriteLine("El texto introducido es: " + texto);
            Console.WriteLine("Por favor introduce tu contraseña");
            String contraseña;
            contraseña = Console.ReadLine();
            //Console.WriteLine("El texto introducido es: " + texto);
            try
            {
                int numeroCedula = Convert.ToInt32(usuario);
                if(menuCajero.InicioSesion(numeroCedula, contraseña))
                {
                    menuCajero.ListaOperaciones(Modelos.EnumeradorMenu.ConsultarSaldo);
                    Console.WriteLine("Bienvenido " + menuCajero.usuarioSesion.Nombres);
                    Console.WriteLine("Su saldo es de: " + menuCajero.saldo);
                }
                else
                {
                    Console.WriteLine("Por favor ingrese datos validos");
                    Console.WriteLine("Si no esta registrado en la plataforma, por favor ingrese el numero 2 para registrarse");

                }
            }
            catch(Exception)
            {
                Console.WriteLine("Ha ocurrido un error!");
            }
        }
    }
}
