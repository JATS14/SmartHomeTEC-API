using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using SmartHomeTEC_API.BD;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Microsoft.AspNetCore.Mvc;
//Clase encargada de control de toda la funcionalidad de la aplicacion
//ademas contiene las listas de la base de datos y controla las consulatas a esta.
namespace SmartHomeTEC_API.API
{
    public class Administrador
    {
        static public IList<Usuario> lista_Usuarios;
        static public IList<Dispositivo> lista_Dispositivos;
        static public IList<Tipo> Lista_tipos;
        static public IList<Distribuidor> lista_Distribuidores;
        static public Usuario usuarioActual;
        static private int numeroSerieActual = 1240;

        static public int disp_America = 0;
        static public int disp_Europa = 0;
        static public int disp_Asia = 0;
        static public int disp_Africa = 0;
        static public int disp_Oceania = 0;
        
        static public ConexionPostgreSQL conn = new ConexionPostgreSQL();
        
        static private Tipo TipoOtros = new Tipo("Otros","Objetos de Uso vario",3);
        static private string correSmartHomeTEC = "pepequinto14@gmail.com";
        static private string contrasenaSmartHome = "imlevitatin123";
        static private int numeroFacturas = 0; 

        public Administrador(IList<Usuario> listaUsuarios , IList<Dispositivo> listaDispositivos, IList<Tipo> Listatipos,
                            IList<Distribuidor> listaDistribuidores)
        {
            lista_Usuarios = listaUsuarios;
            lista_Dispositivos = listaDispositivos;
            Lista_tipos = Listatipos;
            lista_Distribuidores = listaDistribuidores;
            Lista_tipos.Add(TipoOtros);
        }
        // Funcion que verifica el log in proveniente de la pagina wer¿b
        // Entrada: La entrada es un string con el correo y otro con la contrasena
        // Salida: esta funcion tiene como salida un string del tipo de usuario que ingresa
        // Restricciones: las entradas son strings
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
        // funcion encargada de registrar unusario nuevo, lo mete en la base de datos
        // Entrada: la entrada en un usuario previamente creado con todos sus parametros completos
        // Salida: esta funcion no tiene salida
        // Restricciones: la entrada tiene que ser un usuario != null
        public static void registrarUsuario(Usuario usu)
        {
            lista_Usuarios.Add(usu);
            conn.InsertarUsuarioBaseDatos(usu);
        }
        //Funcion que retorna la lista de dispostivos en el sistema
        // Salida: lista de dispositiovs
        public static IList<Dispositivo> getDipositivos()
        {
            return lista_Dispositivos;
        }
        //Funcion que retorna la lista de Tipos en el sistema
        // Salida: lista de tipos
        public static IList<Tipo> getTipo()
        {
            return Lista_tipos;
        }
        //Funcion que retorna la lista de distribuidores en el sistema
        // Salida: lista de distribuidores
        public static IList<Distribuidor> getDistribuidores()
        {
            return lista_Distribuidores;
        }       
        // Funcion que agregar un dispositivo al sistema y base de datos
        // Entrada: la entrada es un dispositivo antes creado
        // Salida: esta funcion no tiene salidas
        // Restricciones: el dispositivo de entrada no puede ser nulo
        public static void adregar_Dispositivo(Dispositivo disp)
        {
            lista_Dispositivos.Add(disp);
            conn.InsertarDispositivoBaseDatos(disp);
        }
        // funcion que camvia elatributo de usuario actual por otro
        // Entrada: la entrada es el correo de un usuario del sistema
        // Salida: no posee salidas
        // Restricciones: la entrada es un string
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
        // funcion que retorna el suaario actual en el sistema
        // Entrada: no tiene entradas
        // Salida: la salida es el usuario actual del sistema
        // Restricciones: no tiene restricciones
        public static Usuario obtenerUsuarioActual( )
        {
            return usuarioActual;
        }
        // funcion que edita al usuario actual en linea
        // Entrada: la entrada es un usuario con los cambios que se desean hacer al usuaior actual  
        // Salida: esta funcion no tiene salidas
        // Restricciones: la entrada tiene que ser un usuario != null
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
        // Funcion que inserta un dispositivo nuevo al sistema
        // Entrada: la entrada es un dispositivo nuevo antes creado
        // Salida: esta funcion no tiene salidas
        // Restricciones: el distpositivo nuevo tiene que ser distinto a null
        public static void insertar_Dispositivo(Dispositivo dispositivo)
        {
            lista_Dispositivos.Add(dispositivo);
            conn.InsertarDispositivoBaseDatos(dispositivo);
        }
        //funcion encargada de modificar la informacion de un dispositivo en el sistema
        // Entrada: la entrada es un dispositivo del sistema mcon algun cambio
        // Salida: no tiene salidas
        // Restricciones: la restriccion es que el dispostivo != null
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
        // funcion que elimina de la base de datos y del sistema un dispositivo
        // Entrada: la entrada es el nombre de dispositivo a eliminar
        // Salida: esta funcion no tiene salidas
        // Restricciones: el nombre es un string de un dispositivo de la base de datos
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
        // funcion que busca en la base de datos algun dispositivo con un texto dado
        // Entrada: la entrada es un string 
        // Salida: la salida es una lista de dispositivos que sean iguales a los buscado o nulo si no encuentra nada
        // Restricciones: no tiene restricciones
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
        // funcion que genera un numero de serie para los dispositivos neuevo y unico
        // Entrada: no tiene entradas
        // Salida: la salida es un numero
        // Restricciones: no tiene restricciones
        public static int genenerar_Numero_Serie()
        {
            int num = numeroSerieActual;
            numeroSerieActual++;
            return num;
        }
        /********************************************************************
         *                   Gestinar Tipo 
         *****************************/
        // funcion que busca un tipo con el nombre dado
        // Entrada: la entrada es el string de un tipo de la base de datos
        // Salida: la salida es el tipo encontrado
        // Restricciones: el nombre es un string y tiene que estar en el sistema
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
        
        // Funcion que inserta un Tipo nuevo al sistema
        // Entrada: la entrada es un Tipo nuevo antes creado
        // Salida: esta funcion no tiene salidas
        // Restricciones: el Tipo nuevo tiene que ser distinto a null
        public static void insertar_Tipo(Tipo tipo)
        {
            Lista_tipos.Add(tipo);
            conn.InsertarTipoBaseDatos(tipo);
        }
        
        //funcion encargada de modificar la informacion de un tipo en el sistema
        // Entrada: la entrada es un tipo del sistema con algun cambio
        // Salida: no tiene salidas
        // Restricciones: la restriccion es que el tipo != null
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
        
        // funcion que busca en la base de datos algun tipo con un texto dado
        // Entrada: la entrada es un string 
        // Salida: la salida es una lista de tipos que sean iguales a los buscado o nulo si no encuentra nada
        // Restricciones: no tiene restricciones
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
        
        // funcion que elimina de la base de datos y del sistema un tipo
        // Entrada: la entrada es el nombre de tipo a eliminar
        // Salida: esta funcion no tiene salidas
        // Restricciones: el nombre es un string de un tipo de la base de datos
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
        
        // Funcion que genera el promedio de dispositivos por tods los usuarios
        // Entrada: no tiene entrada
        // Salida: la salida es un entero con el promedio de dispositivos(redondeado)
        // Restricciones: no tiene restricciones
        public static int prom_Dispo_usuario()
        {
            int promedio = 0;
            for (int i = 0; i < lista_Usuarios.Count; i++)
            {
                promedio = promedio + lista_Usuarios[i].obtener_lista_Dispositivos().Count;
            }
            return (promedio/lista_Usuarios.Count);
        }
        // funcion que retorna la cantidad de dispositivos en el sistema
        // Entrada: no tiene entradas
        // Salida: la salida es un entero con la cantidad de dispostivos
        // Restricciones: no tiene restricciones
        public static int cantidad_Dispo()
        {
            return (lista_Dispositivos.Count - Administrador.obtener_Disp_Usuarios().Count);
        }
        //funcion que obtiene la cantidad de dispositivos por region
        // Entrada: no tiene entradas
        // Salida: la funcion no tiene salidas, los datos se guardan en variables globales
        // Restricciones: no tiene restricciones 
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
        // funcion que obtiene una lista de dispositivoc son los dispositivos asiciados a usuarios
        // Entrada: notiene entradas
        // Salida: la salida es una lista de dispositivoc son los dispositivos asiciados a usuarios
        // Restricciones: no tiene restricciones
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
        // funcion que obtiene una lista de dispositivoc son los dispositivos no asiciados a usuarios
        // Entrada: notiene entradas
        // Salida: la salida es una lista de dispositivoc son los dispositivos no asiciados a usuarios
        // Restricciones: no tiene restricciones
        public static IList<Dispositivo> obtener_Disp_SinUsuarios()
        {
            List<Dispositivo> lista = new List<Dispositivo>();
            for (int i = 0; i < lista_Dispositivos.Count; i++)
            {
                lista.Add(lista_Dispositivos[i]);
            }
            IList<Dispositivo> yaComprados = obtener_Disp_Usuarios();

            if (yaComprados.Count == 0)
            {
                return lista_Dispositivos;
            }
            
            for (int i = 0; i < lista.Count; i++)
            {
                for (int j = 0; j < yaComprados.Count; j++)
                {
                    if (yaComprados[j].nombre.Equals(lista[i].nombre))
                    {
                        lista.Remove(lista[i]);
                        break;
                    }
                }
            }

            return lista;
        }
        
        /********************************************************************
                              Comprar / Factura
         ********************************************************************/
        
        // Funcion que asigna un dispositivo a aun usuario
        // Entrada: la entrada es un dispositivo de la base de datos
        // Salida: no tiene salidas
        // Restricciones: la entrada tiene que ser un dispositiov del sistema no nulo
        public static void comprarDispositivo(Dispositivo disp)
        {
            Console.WriteLine("Se agrega dispositivo a usuaior: " + usuarioActual.nombre);
            usuarioActual.lista_Disp_Usuario.Add(disp);
            conn.InsertarPedidoBaseDatos(disp);
            
        }
        // Funcion que envia un correo al usuario que compro un producto con la factura y la garantia
        // Entrada: al entrada es una fatura generada en la web
        // Salida: no tiene salidas
        // Restricciones: la factura no puede se nula
        public static void enviarCorreoFactura(Factura factura)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(correSmartHomeTEC, contrasenaSmartHome),
                EnableSsl = true,
            };
            
            var mailMessage = new MailMessage
            {
                From = new MailAddress(correSmartHomeTEC),
                Subject = "Factura SmarTHomeTEC",
                Body = "Gracias por comprar en SmartHomeTEC"
            };
            mailMessage.To.Add(usuarioActual.correo);
            
            var attachment1 = new Attachment(crearPDFFactura(factura),"FacturaSmarTHomeTec"+numeroFacturas+".pdf", "application/pdf");
            
            var attachment2 = new Attachment(crearPDFGarantia(usuarioActual.lista_Disp_Usuario[usuarioActual.lista_Disp_Usuario.Count-1]),
                                                "FacturaSmarHomeTecGarantía" + numeroFacturas + ".pdf", "application/pdf");
            numeroFacturas++;
            mailMessage.Attachments.Add(attachment1);
            mailMessage.Attachments.Add(attachment2);
            smtpClient.Send(mailMessage);
   
        }
        // funcion que genera el pdf de la factura
        // Entrada: la entrada son los datos de la factura a generar
        // Salida: como saida es un memoryStream con el documento
        // Restricciones: la factura no puede ser nula
        public static MemoryStream crearPDFFactura(Factura factura)
        {
            
            PdfDocument document = new PdfDocument();
            
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            
            string FechaCompra = DateTime.Now.ToString("yyy-MM-dd");
            Dispositivo disp = usuarioActual.lista_Disp_Usuario[usuarioActual.lista_Disp_Usuario.Count - 1];
            
            graphics.DrawString("Factura SmartHomeTEC", font, PdfBrushes.Black, new PointF(0, 0));
            graphics.DrawString("Numero de Factura: 1254875966541231485"+ numeroFacturas, font2, PdfBrushes.Black, new PointF(0, 40));
            graphics.DrawString("Fecha de compra: "+ FechaCompra , font2, PdfBrushes.Black, new PointF(0, 80));
            graphics.DrawString("Tipo Dispositivo: "+ disp.tipo.nombre + ".", font2, PdfBrushes.Black, new PointF(0, 120));
            graphics.DrawString("Precio: "+ disp.precio + " Colones.", font2, PdfBrushes.Black, new PointF(0, 160));
            
            graphics.DrawString("Datos Factura: ", font2, PdfBrushes.Black, new PointF(0, 200));
            graphics.DrawString("        Nombre: "+ factura.nombre + " " + factura.apellido + ".", font2, PdfBrushes.Black, new PointF(0, 240));
            graphics.DrawString("        Direccion: " + factura.direccionfacturacion + ".", font2, PdfBrushes.Black, new PointF(0, 280));
            graphics.DrawString("        Codigo Postal: " + factura.codigoPostal, font2, PdfBrushes.Black, new PointF(0, 320));
            graphics.DrawString("        Celular: " + factura.celular, font2, PdfBrushes.Black, new PointF(0, 360));
            
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            document.Close(true);
            
            return stream;
        }
        // funcion que genera el pdf de la garantia
        // Entrada: la entrada son los datos del dispositivo a generar garantia
        // Salida: como saida es un memoryStream con el documento
        // Restricciones: la factura no puede ser nula
        public static MemoryStream crearPDFGarantia(Dispositivo disp)
        {
            PdfDocument document = new PdfDocument();
            
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
            
            string fechaInicio = DateTime.Now.ToString("yyy-MM-dd");
            
            string diafinal = DateTime.Now.ToString("dd");
            
            int mesFinal = Convert.ToInt32(DateTime.Now.ToString("MM"));
            mesFinal = mesFinal + disp.tipo.tiempoGarantia;
            
            int anoFinal = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

            anoFinal = anoFinal + (mesFinal / 12);
            int nuevoMes = mesFinal % 12;


            string fechafinal = anoFinal+ "-" + nuevoMes + "-" + diafinal;

            graphics.DrawString("Garantía para Dispositivo: "+ disp.nombre, font, PdfBrushes.Black, new PointF(0, 0));
            graphics.DrawString("Usuario: "+ usuarioActual.nombre+ " " + usuarioActual.apellido+ ".", font2, PdfBrushes.Black, new PointF(0, 40));
            graphics.DrawString("Tipo Dispositivo: "+ disp.Tipo.nombre + ".", font2, PdfBrushes.Black, new PointF(0, 80));
            graphics.DrawString("Marca: "+ disp.marca + ".", font2, PdfBrushes.Black, new PointF(0, 120));
            graphics.DrawString("NumeroSerie: "+ disp.numero_Serie + ".", font2, PdfBrushes.Black, new PointF(0, 160));
            graphics.DrawString("Fecha Inicio Garantia: ", font2, PdfBrushes.Black, new PointF(0, 200));
            graphics.DrawString("      " + fechaInicio, font2, PdfBrushes.Black, new PointF(0, 240));
            graphics.DrawString("Fecha Final Garantia: ", font2, PdfBrushes.Black, new PointF(0, 280));
            graphics.DrawString("      " + fechafinal, font2, PdfBrushes.Black, new PointF(0, 320));
            
            
            
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            document.Close(true);

            return stream;
        }

    }
}