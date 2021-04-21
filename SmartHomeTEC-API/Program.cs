using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;

namespace SmartHomeTEC_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dispositivo ob1 = new Dispositivo("objeto1",100);
            Dispositivo ob2 = new Dispositivo("objeto2",200);

            List<Dispositivo> nuevaList = new List<Dispositivo>();
            nuevaList.Add(ob1);
            nuevaList.Add(ob2);
            Administrador host = new Administrador(new List<Usuario>(), nuevaList);
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}