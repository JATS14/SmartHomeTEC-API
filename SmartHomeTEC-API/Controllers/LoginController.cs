using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmartHomeTEC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        
        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta Verificar_Login(string login)
        {
            string jsonString = JsonSerializer.Serialize(login);
            Console.WriteLine("Lo que llega: "+ jsonString);
            /*
            Console.WriteLine("correo: "+ login.correo);
            Console.WriteLine("Contrasena: "+ login.contrasena);
            if (Administrador.login(login.correo, login.contrasena) == "admin")
            {
                return new respuesta("admin");
            }
            if (Administrador.login(login.correo, login.contrasena) == "usuario")
            {
                return new respuesta("usuario");
            }
            return new respuesta("denegar");
            */
            return new respuesta("admin");
        }



        
    public class LoginEntrada
    {
        public string correo;
        public string contrasena;
    }

    public class respuesta
    { 
        public string ingreso;
        public string status;

        public respuesta(string ingreso)
        { 
            this.ingreso = ingreso;
        }

        }
    }
}