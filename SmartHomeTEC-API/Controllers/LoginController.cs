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
    //funcion encargada del registro y de logeo de los usuarios
    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        // funcion encargada de verificar los datos de log in de un usuario
        //Entrada: los datos en forma de loginEntrada de correo y contraseña
        //Salida: la respuesta de si es admitido o no, y si es usuario o administrador
        //Restricciones: no posee restricciones
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
        // funcion que hace un registro de los datos de un nuevo usuario
        //Entrada: la entrada son los datos para un nuevo usuario
        //Salida: respuesta de registrado o no
        //Restricciones: el nuevo usuario no puede ser nulo
        [HttpPost]
        [Route("registrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta Verificar_registro(Usuario nuevoUsuario)
        {
            string jsonString = JsonSerializer.Serialize(nuevoUsuario);
            Console.WriteLine("Lo que llega de registrarse: "+ jsonString);

            Administrador.registrarUsuario(nuevoUsuario);
            return new respuesta("ok");
        }

        //Plantilla de datos ingresados por el usuario desde la web app
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
    }
}
