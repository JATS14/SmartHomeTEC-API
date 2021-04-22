using System.Collections.Generic;

namespace SmartHomeTEC_API.API
{
    public class Administrador
    {
        static public IList<Usuario> lista_Usuarios;
        static public IList<Dispositivo> lista_Dispositivos;

        public Administrador(IList<Usuario> listaUsuarios , IList<Dispositivo> listaDispositivos)
        {
            lista_Usuarios = listaUsuarios;
            lista_Dispositivos = listaDispositivos;
        }

        public static string login(string loginCorreo, string loginContrasena)
        {
            if (loginCorreo.Equals("admin") && loginContrasena.Equals("123"))
            {
                return "admin";
            }
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                if (lista_Usuarios[i].correo.Equals(loginCorreo) &&
                    lista_Usuarios[i].Contrasena.Equals(loginContrasena))
                {
                    return "usuario";
                }
            }
            
            return "denegar";
        }

        public static IList<Dispositivo> getDipositivos()
        {
            return lista_Dispositivos;
        }
        public static void adregar_Dispositivo(Dispositivo disp)
        {
            lista_Dispositivos.Add(disp);
        }
    }
}