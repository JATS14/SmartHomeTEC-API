using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SmartHomeTEC_API.API
{
    public class Administrador
    {
        static public IList<Usuario> lista_Usuarios;
        static public IList<Dispositivo> lista_Dispositivos;
        static public IList<Tipo> Lista_tipos;
        static public IList<Distribuidor> lista_Distribuidores;
        static public Usuario usuarioActual;
        
        static private Tipo TipoOtros = new Tipo("Otros","Objetos de Uso vario",3);

        public Administrador(IList<Usuario> listaUsuarios , IList<Dispositivo> listaDispositivos, IList<Tipo> Listatipos,
                            IList<Distribuidor> listaDistribuidores)
        {
            lista_Usuarios = listaUsuarios;
            lista_Dispositivos = listaDispositivos;
            Lista_tipos = Listatipos;
            lista_Distribuidores = listaDistribuidores;
            Lista_tipos.Add(TipoOtros);
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
        public static IList<Tipo> getTipo()
        {
            return Lista_tipos;
        }

        public static IList<Distribuidor> getDistribuidores()
        {
            return lista_Distribuidores;
        }
        public static void adregar_Dispositivo(Dispositivo disp)
        {
            lista_Dispositivos.Add(disp);
        }

        public static void cambiarUsuarioActual(string correo)
        {
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                if (lista_Usuarios[i].correo.Equals(correo))
                {
                    usuarioActual = lista_Usuarios[i];
                }
            }
        }
        public static Usuario obtenerUsuarioActual( )
        {
            return usuarioActual;
        }
        
        
        /********************************************************************
         *                   Gestinar Dispositivos 
         *****************************/
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static void insertar_Dispositivo(Dispositivo dispositivo)
        {
            lista_Dispositivos.Add(dispositivo);
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static int editar_Dispositivo(string queEditar, string nombre, string edicion)
        {
            if (queEditar == "tipo")
            {
                for (int i = 0; i < lista_Dispositivos.Count; i++)
                {
                    if (lista_Dispositivos[i].nombre.Equals(nombre))
                    {
                        lista_Dispositivos[i].tipo.nombre = edicion;
                        return 1;
                    }
                }
            }
            if (queEditar == "marca")
            {
                for (int i = 0; i < lista_Dispositivos.Count; i++)
                {
                    if (lista_Dispositivos[i].nombre.Equals(nombre))
                    {
                        lista_Dispositivos[i].marca = edicion;
                        return 1;
                    }
                }
            }
            if (queEditar == "precio")
            {
                for (int i = 0; i < lista_Dispositivos.Count; i++)
                {
                    if (lista_Dispositivos[i].nombre.Equals(nombre))
                    {
                        lista_Dispositivos[i].precio = Convert.ToInt32(edicion);
                        return 1;
                    }
                }
            }
            if (queEditar == "consumo")
            {
                for (int i = 0; i < lista_Dispositivos.Count; i++)
                {
                    if (lista_Dispositivos[i].nombre.Equals(nombre))
                    {
                        lista_Dispositivos[i].consumo_Electrico = Convert.ToInt32(edicion);
                        return 1;
                    }
                }
            }
            return 0;
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static void eliminar_Dispositivo(string nombre)
        {
            for (int i = 0; i < lista_Dispositivos.Count; i++)
            {
                if (lista_Dispositivos[i].nombre.Equals(nombre))
                {
                   lista_Dispositivos.RemoveAt(i);
                }
            }
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static IList<Dispositivo> buscar_Dispositivo(string queBusca)
        {
            IList<Dispositivo> list = new List<Dispositivo>();
            for (int i = 0; i < lista_Dispositivos.Count; i++)
            {
                if (lista_Dispositivos[i].nombre.Equals(queBusca, StringComparison.OrdinalIgnoreCase))
                { list.Add(lista_Dispositivos[i]); }
            
                if (lista_Dispositivos[i].tipo.nombre.Equals(queBusca, StringComparison.OrdinalIgnoreCase))
                { list.Add(lista_Dispositivos[i]);  }
            
                if (lista_Dispositivos[i].marca.Equals(queBusca, StringComparison.OrdinalIgnoreCase))
                { list.Add(lista_Dispositivos[i]);  }
                
            }
            
            return list;
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static int genenerar_Numero_Serie()
        {
            
            int numeroSerie = 1230;

            if (lista_Dispositivos.Count == 0)
            {
                return numeroSerie;
            }

            return numeroSerie + lista_Dispositivos.Count;
        }
        /********************************************************************
         *                   Gestinar Tipo 
         *****************************/
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static Tipo obtnenerTipo(string nombre)
        {
            for (int i = 0; i < Lista_tipos.Count; i++)
            {
                if (Lista_tipos[i].nombre.Equals(nombre))
                {
                    return Lista_tipos[i];
                } 
                
            }
            return TipoOtros;
        }
        
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static void insertar_Tipo(Tipo tipo)
        {
            Lista_tipos.Add(tipo);
        }
        
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static void editar_Tipo(Tipo tipo)
        {
            return;
        }
        
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static IList<Tipo> Buscar_Tipo(string busqueda)
        {
            IList<Tipo> list = new List<Tipo>();
            for (int i = 0; i < Lista_tipos.Count; i++)
            {
                if (Lista_tipos[i].nombre.Equals(busqueda, StringComparison.OrdinalIgnoreCase))
                { list.Add(Lista_tipos[i]); }

                if (Lista_tipos[i].descripcion.Equals(busqueda, StringComparison.OrdinalIgnoreCase))
                { list.Add(Lista_tipos[i]); }
            }
            return list;
        }
        
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static void eliminar_Tipo(string nombre)
        {
            for (int i = 0; i < Lista_tipos.Count; i++)
            {
                if (Lista_tipos[i].nombre.Equals(nombre))
                {
                    Lista_tipos.RemoveAt(i);
                }
            }
        }
        
        
    }
}