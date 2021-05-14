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
        
        public static void registrarUsuario(Usuario usu)
        {
            lista_Usuarios.Add(usu);
            conn.InsertarUsuarioBaseDatos(usu);
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
            conn.InsertarDispositivoBaseDatos(disp);
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
            conn.InsertarDispositivoBaseDatos(dispositivo);
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
            conn.InsertarTipoBaseDatos(tipo);
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
            Console.WriteLine("Se agrega dispositivo a usuaior: " + usuarioActual.nombre);
            usuarioActual.lista_Disp_Usuario.Add(disp);
            conn.InsertarPedidoBaseDatos(disp);
            
        }
        //
        // Entrada:
        // Salida:
        // Restricciones:
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
        //
        // Entrada:
        // Salida:
        // Restricciones:
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