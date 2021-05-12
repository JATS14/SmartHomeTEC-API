using System;
using System.Collections.Generic;
using System.Linq;
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
            
            
            // DATA BASE
            ConexionPostgreSQL conn = new ConexionPostgreSQL();
            conn.Conectar();
            
            conn.iniciar_Base_Datos();

            conn.Desconetar();

            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}