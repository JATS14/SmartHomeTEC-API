using System;
using System.Collections.Generic;
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
    public class PostUsuarioActualController : ControllerBase
    {
        [HttpPost]
        [Route("agregarUsuarioActual")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta insertarUsuarioActual(LoginUsuarioActual usuarioActual)
        {
            
            Administrador.cambiarUsuarioActual(usuarioActual.correo);
            return new respuesta("Cambiado"); 
        }
        
        
        public class LoginUsuarioActual
        {
            public string correo;
            public string contrasena;

            public LoginUsuarioActual(string correo, string contrasena)
            {
                this.correo = correo;
                this.contrasena = contrasena;
            }

            public string Correo
            {
                get => correo;
                set => correo = value;
            }

            public string Contrasena
            {
                get => contrasena;
                set => contrasena = value;
            }
        }
        
    }
}