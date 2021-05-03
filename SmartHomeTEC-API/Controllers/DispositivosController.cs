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
    public class DispositivosController : ControllerBase
    {

        [HttpPost]
        [Route("agregarDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta insertarDispositivo(dispositivoEntrada dispositivo)
        {
            string jsonString = JsonSerializer.Serialize(dispositivo);
            Console.WriteLine("Lo que llega de Insertar Dispositivos: "+ jsonString);

            Dispositivo newdispo = new Dispositivo(dispositivo.nombre,dispositivo.precio,
                                Administrador.obtnenerTipo(dispositivo.tipo),
                                Administrador.genenerar_Numero_Serie(),dispositivo.marca,dispositivo.consumo_Electrico);
            
            
            Administrador.adregar_Dispositivo(newdispo);
            return new respuesta("agregado"); 
        }
        
        [HttpPost]
        [Route("editarDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta editar_dispositivo(Dispositivo edicion)
        {
            string jsonString = JsonSerializer.Serialize(edicion);
            Console.WriteLine("Lo que llega de Insertar Usuario: "+ jsonString);
            //int resp = Administrador.editar_Dispositivo(edicion.queEditar,edicion.nombre,edicion.editarS);
            //if (resp == 1){
            //    return new respuesta("exito");
            //}
            return new respuesta("error");
        }
        [HttpPost]
        [Route("eliminarDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta eliminar_dispositivo(Dispositivo entrada)
        {
            string jsonString = JsonSerializer.Serialize(entrada);
            Console.WriteLine("Lo que llega de Buscar Dispositivo: "+ jsonString);
            Administrador.eliminar_Dispositivo(entrada.nombre);
            return new respuesta("exito");
        }
        
        [HttpPost]
        [Route("buscarDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IList<Dispositivo> buscar_dispositivo(busquedaEntrada entrada)
        {
            string jsonString = JsonSerializer.Serialize(entrada);
            Console.WriteLine("Lo que llega de Buscar Dispositivo: "+ jsonString);
            return Administrador.buscar_Dispositivo(entrada.BusquedaEnt);
        }

        
        
        
        public class editar
        {
            public string queEditar;
            public string nombre;
            public string editarS;

            public editar(string queEditar, string nombre, string editarS)
            {
                this.queEditar = queEditar;
                this.nombre = nombre;
                this.editarS = editarS;
            }

            public string QueEditar
            {
                get => queEditar;
                set => queEditar = value;
            }

            public string Nombre
            {
                get => nombre;
                set => nombre = value;
            }

            public string EditarS
            {
                get => editarS;
                set => editarS = value;
            }
        }

        public class dispositivoEntrada
        {
            public string nombre;
            public int precio;
            public string tipo;
            public int numero_Serie;
            public string marca;
            public int consumo_Electrico;

            public dispositivoEntrada(string nombre, int precio, string tipo, int numeroSerie, string marca, int consumoElectrico)
            {
                this.nombre = nombre;
                this.precio = precio;
                this.tipo = tipo;
                numero_Serie = numeroSerie;
                this.marca = marca;
                consumo_Electrico = consumoElectrico;
            }

            public string Nombre
            {
                get => nombre;
                set => nombre = value;
            }

            public int Precio
            {
                get => precio;
                set => precio = value;
            }

            public string Tipo
            {
                get => tipo;
                set => tipo = value;
            }

            public int NumeroSerie
            {
                get => numero_Serie;
                set => numero_Serie = value;
            }

            public string Marca
            {
                get => marca;
                set => marca = value;
            }

            public int ConsumoElectrico
            {
                get => consumo_Electrico;
                set => consumo_Electrico = value;
            }
            
            
        }

        public class busquedaEntrada
        {
            private string busquedaEnt;

            public busquedaEntrada(string busquedaEnt)
            {
                this.busquedaEnt = busquedaEnt;
            }

            public string BusquedaEnt => busquedaEnt;
        }
        
        

    }
}