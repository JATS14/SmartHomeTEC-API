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
    //clase con los post necesarios para poder insertar, eliminar, buscar y editar tipos del sistema
    [ApiController]
    [Route("[controller]")]
    public class GestionarTipoController : ControllerBase
    {
        
        //Esta funcion es la encargada de hacer post para agregar tipo
        [HttpPost]
        [Route("agregarTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta insertar_Tipo(Tipo tipo)
        {
            string jsonString = JsonSerializer.Serialize(tipo);
            Console.WriteLine("Lo que llega de Insertar Tipo: "+ jsonString);

            Administrador.insertar_Tipo(tipo);
            return new respuesta("agregado"); 
        }
        
        //Esta funcion es la encargada de hacer post para editar tipo
        [HttpPost]
        [Route("editarTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta editar_Tipo(Tipo edicion)
        {
            Administrador.editar_Tipo(edicion);
            return new respuesta("exito");
        }
        //Esta funcion es la encargada de hacer post para eliminar tipo       
        [HttpPost]
        [Route("eliminarTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta eliminar_Tipo(Tipo tipo)
        {
            Administrador.eliminar_Tipo(tipo.nombre);
            return new respuesta("exito");
        }
        
        //Esta funcion es la encargada de hacer post para buscar tipo
        [HttpPost]
        [Route("buscarTipo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IList<Tipo> buscar_Tipo(BusquedaEntrada entrada)
        {
            return Administrador.Buscar_Tipo(entrada.busquedaEnt);
        }
        

        //Clase plantilla de datos de entrada desde la apliaccion web
        public class BusquedaEntrada
        {
            public string busquedaEnt;

            public BusquedaEntrada(string busquedaEnt)
            {
                this.busquedaEnt = busquedaEnt;
                
            }

            public string BusquedaEnt
            {
                get => busquedaEnt;
                set => busquedaEnt = value;
            }
        }
        
        
    }
}