using System;
using System.Net;
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
        [HttpPost]
        [Route("verificar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta Verificar_Login(LoginEntrada login)
        {
            string jsonString = JsonSerializer.Serialize(login);
            Console.WriteLine("Lo que llega: "+ jsonString);
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
        }

        [HttpPost]
        [Route("registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta Verificar_registro(Usuario nuevoUsuario)
        {
            string jsonString = JsonSerializer.Serialize(nuevoUsuario);
            Console.WriteLine("Lo que llega de registrarse: "+ jsonString);
            return new respuesta("ok");
        }


        public class LoginEntrada
    {
        public string correo;
        public string contrasena;

        public LoginEntrada(string correo, string contrasena)
        {
            this.correo = correo;
            this.contrasena = contrasena;
        }

        public string Correo => correo;

        public string Contrasena => contrasena;
    }

    public class respuesta
    { 
        public string ingreso;

        public respuesta(string ingreso)
        { 
            this.ingreso = ingreso;
        }

        public string Ingreso
        {
            get => ingreso;
            set => ingreso = value;
        }
    }
    }
}
/*
cd C:\Program Files (x86)\Google\Chrome\Application
chrome.exe chromium-browser --disable-web-security --user-data-dir="C:\Users\adria\Documents"
*/