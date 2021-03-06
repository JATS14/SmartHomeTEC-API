using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;
using SmartHomeTEC_API.BD;

namespace SmartHomeTEC_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            List<Tipo> listaTipos = new List<Tipo>();
            List<Distribuidor> listDitribuidor = new List<Distribuidor>();
            List<Dispositivo> nuevaList = new List<Dispositivo>();
            List<Usuario> listUsuario = new List<Usuario>();
            
            Administrador host = new Administrador(listUsuario, nuevaList,listaTipos,listDitribuidor);
            Administrador.conn.Conectar();
            Administrador.conn.iniciar_Base_Datos();

            Administrador.usuarioActual = Administrador.lista_Usuarios[0];
            //Usuario prueba = new Usuario("Stephanie","Juanilama","USA","America","juanilama@gmail.com","1234","Houston, Texas");
            //Dispositivo pruebadisp = new Dispositivo("Ratón Inalámbrico",  15000, Administrador.Lista_tipos[9],1240, "Razer", 10);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}