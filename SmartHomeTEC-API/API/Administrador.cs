using System;
using System.Collections.Generic;
using System.Reflection.Emit;
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
        static private int numeroSerieActual = 1230;

        static public int disp_America = 0;
        static public int disp_Europa = 0;
        static public int disp_Asia = 0;
        static public int disp_Africa = 0;
        static public int disp_Oceania = 0;
        
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

        public static void EditarUsuarioActual(Usuario usuario)
        {
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                if (lista_Usuarios[i].nombre.Equals(obtenerUsuarioActual().nombre))
                {
                    lista_Usuarios[i].nombre = usuario.nombre;
                    lista_Usuarios[i].apellido = usuario.apellido;
                    lista_Usuarios[i].pais = usuario.pais;
                    lista_Usuarios[i].region = usuario.region;
                    lista_Usuarios[i].correo = usuario.correo;
                    lista_Usuarios[i].Contrasena = usuario.Contrasena;
                    lista_Usuarios[i].direccion = usuario.direccion;
                    
                    cambiarUsuarioActual(lista_Usuarios[i].correo);
                }
                
            }
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
        public static void editar_Dispositivo(Dispositivo dispositivoEditado)
        {
            for (int i = 0; i < lista_Dispositivos.Count; i++)
            {
                if (lista_Dispositivos[i].numero_Serie.Equals(dispositivoEditado.numero_Serie))
                {
                    lista_Dispositivos[i].nombre = dispositivoEditado.nombre;
                    lista_Dispositivos[i].precio = dispositivoEditado.precio;
                    lista_Dispositivos[i].tipo = dispositivoEditado.tipo;
                    lista_Dispositivos[i].marca = dispositivoEditado.marca;
                    lista_Dispositivos[i].consumo_Electrico = dispositivoEditado.consumo_Electrico;
                }
            }
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
            int num = numeroSerieActual;
            numeroSerieActual++;
            return num;
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
            for (int i = 0; i < Lista_tipos.Count; i++)
            {
                if (Lista_tipos[i].nombre.Equals(tipo.nombre))
                {
                    Lista_tipos[i].descripcion = tipo.descripcion;
                    Lista_tipos[i].TiempoGarantia = tipo.tiempoGarantia;
                }
            }
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
        /********************************************************************
                                     DashBoard 
         ********************************************************************/
        
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static int prom_Dispo_usuario()
        {
            int promedio = 0;
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                promedio = promedio + lista_Usuarios[i].obtener_lista_Dispositivos().Count;
            }
            return (promedio/lista_Usuarios.Count);
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static int cantidad_Dispo()
        {
            return (lista_Dispositivos.Count - Administrador.obtener_Disp_Usuarios().Count);
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static void obtener_Disp_Region()
        {
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                if (lista_Usuarios[i].region.Equals("America"))
                {disp_America++;}
                if (lista_Usuarios[i].region.Equals("Europa"))
                {disp_Europa++;}
                if (lista_Usuarios[i].region.Equals("Asia"))
                {disp_Asia++;}
                if (lista_Usuarios[i].region.Equals("Africa"))
                {disp_Africa++;}
                if (lista_Usuarios[i].region.Equals("Oceania"))
                {disp_Oceania++;}
            }
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static IList<Dispositivo> obtener_Disp_Usuarios()
        {
            IList<Dispositivo> lista = new List<Dispositivo>();
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                for (int j = 0; j < lista_Usuarios[i].lista_Disp_Usuario.Count; j++)
                {
                    for (int k = 0; k < lista_Dispositivos.Count; k++)
                    {
                        if (lista_Usuarios[i].lista_Disp_Usuario[j].nombre.Equals(lista_Dispositivos[k].nombre))
                        {
                            lista.Add(lista_Dispositivos[k]);
                        }
                    }
                }
            }
            return lista;
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static IList<Dispositivo> obtener_Disp_SinUsuarios()
        {
            IList<Dispositivo> lista = new List<Dispositivo>();
            for (int i = 0; i < lista_Dispositivos.Count; i++)
            {
                lista.Add(lista_Dispositivos[i]);
            }
            
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                for (int j = 0; j < lista_Usuarios[i].lista_Disp_Usuario.Count; j++)
                {
                    for (int k = 0; k < lista_Dispositivos.Count; k++)
                    {
                        if (lista_Usuarios[i].lista_Disp_Usuario[j].nombre.Equals(lista_Dispositivos[k].nombre))
                        {
                            lista.RemoveAt(k);
                        }
                    }
                }
            }
            return lista;
        }
        
        /********************************************************************
                              Comprar / Factura
         ********************************************************************/
        
        //
        // Entrada:
        // Salida:
        // Restricciones:
        public static void comprarDispositivo(Dispositivo disp)
        {
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                if (lista_Usuarios[i].nombre.Equals(obtenerUsuarioActual().nombre))
                {
                    lista_Usuarios[i].lista_Disp_Usuario.Add(disp);
                }
            }
        }
        
        
        
        /********************************************************************
                                Reportes Usuario 
         ********************************************************************/
        
    }
}