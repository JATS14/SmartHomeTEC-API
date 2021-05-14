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
    //Clase encargada de gestionar a los usuario rsgistrados en el sistema, por medio de posts del web
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        //Funcion que edita a un usuario del sistema
        //Entrada: un usuario que este resgitrado en el sistema
        //Salida: una respuesta con el estado
        //restrucciones: el usuario no puede ser nulo y esta en la base de datos
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
        //Funcion que recibe los datos de un dispostivo comprado y lo asigna
        //Entrada: un dispositivo que este resgitrado en el sistema
        //Salida: una respuesta con el estado
        //restrucciones: el dispositivo no puede ser nulo y esta en la base de datos
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
        //Funcion que recibe los datos de una factura
        //Entrada: una factura 
        //Salida: una respuesta con el estado
        //restrucciones: la factura no puede ser nulo y esta en la base de datos        
        [HttpPost]
        [Route("DatosDactura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta datosFactura(Factura factura)
        {
            Administrador.enviarCorreoFactura(factura);
            string jsonString = JsonSerializer.Serialize(factura);
            Console.WriteLine("Lo que llega en Datos factura: "+ jsonString);
            return new respuesta("exito");
        }
        
    }
}