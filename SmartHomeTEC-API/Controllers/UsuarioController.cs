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
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("EditarPerfil")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta Editar_Perfil(Usuario usuario)
        {
            string jsonString = JsonSerializer.Serialize(usuario);
            Console.WriteLine("Lo que llega en EditarPerfil: "+ jsonString);
            Administrador.EditarUsuarioActual(usuario);
            return new respuesta("exito");
        }

        [HttpPost]
        [Route("ComparDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta compar_Dispositivo(Dispositivo disp)
        {
            string jsonString = JsonSerializer.Serialize(disp);
            Console.WriteLine("Lo que llega en Comprar: "+ jsonString);
            Administrador.comprarDispositivo(disp);
            return new respuesta("exito");
        }
        
        [HttpPost]
        [Route("DatosDactura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta datosFactura(Factura factura)
        {
            string jsonString = JsonSerializer.Serialize(factura);
            Console.WriteLine("Lo que llega en Datos factura: "+ jsonString);
            return new respuesta("exito");
        }
        
    }
}