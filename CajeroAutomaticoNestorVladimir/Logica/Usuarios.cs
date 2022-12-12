using CajeroAutomaticoNestorVladimir.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomaticoNestorVladimir.Logica
{
    public class Usuarios
    {
        public List<Usuario> usuarios = new List<Usuario>();
        public bool NuevoUsuario(Usuario usuario)
        {
            try
            {
                usuarios.Add(usuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditarUsuario(int cedula, Usuario datos)
        {
            try
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    Usuario usuario = usuarios[i];
                    if (usuario.Cedula == cedula)
                        usuarios[i] = datos;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Usuario ConsultarUsuario(int cedula, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Cedula == cedula && usuario.Contraseña == contraseña)
                    return usuario;
            }

            return null;
        }
    }
}
