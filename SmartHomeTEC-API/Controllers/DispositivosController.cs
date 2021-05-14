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
        //Esta funcion es la encargada de hacer post para agregar dispositivo
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
        //Esta funcion es la encargada de hacer post para editar dispositivo
        [HttpPost]
        [Route("editarDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public respuesta editar_dispositivo(dispositivoEntradaEditado edicion)
        {
            string jsonString = JsonSerializer.Serialize(edicion);
            Console.WriteLine("Lo que llega de Editar Usuario: "+ jsonString);

            int index = -1;
            for (int i = 0; i < Administrador.lista_Dispositivos.Count; i++)
            {
                if (Administrador.Lista_tipos[i].nombre.Equals(edicion.tipoEditar))
                {
                    index = i;
                }
            }

            Tipo tipoeditar = new Tipo("nombre", "", 0);

            if (index != -1)
            {
                tipoeditar = Administrador.Lista_tipos[index];
            }

            Dispositivo newDisp = new Dispositivo(edicion.nombreEditar, edicion.precioEditar,tipoeditar,
                            edicion.numero_SerieEditar,edicion.marcaEditar,edicion.consumo_ElectricoEditar);

            Administrador.editar_Dispositivo(newDisp);
            
            return new respuesta("exito");
        }
        
        //Esta funcion es la encargada de hacer post para eliminar dispositivo
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
        
        //Esta funcion es la encargada de hacer post para buscar dispositivo
        [HttpPost]
        [Route("buscarDispositivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IList<Dispositivo> buscar_dispositivo(busquedaEntrada entrada)
        {
            string jsonString = JsonSerializer.Serialize(entrada);
            Console.WriteLine("Lo que llega de Buscar Dispositivo: "+ jsonString);
            return Administrador.buscar_Dispositivo(entrada.BusquedaEnt);
        }

        
        
        //Clase con datos recibidos de un buscar en la aplicacion web
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
        
        //Clase con datos recibidos de un dispositiov sin tipo en la aplicacion web
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
        
        //Clase con datos recibidos de un buscar en la aplicacion web
        public class dispositivoEntradaEditado
        {
            public string nombreEditar;
            public int precioEditar;
            public string tipoEditar;
            public int numero_SerieEditar;
            public string marcaEditar;
            public int consumo_ElectricoEditar;

            public dispositivoEntradaEditado(string nombreEditar, int precioEditar, string tipoEditar, int numeroSerieEditar, string marcaEditar, int consumoElectricoEditar)
            {
                this.nombreEditar = nombreEditar;
                this.precioEditar = precioEditar;
                this.tipoEditar = tipoEditar;
                numero_SerieEditar = numeroSerieEditar;
                this.marcaEditar = marcaEditar;
                consumo_ElectricoEditar = consumoElectricoEditar;
            }

            public string NombreEditar
            {
                get => nombreEditar;
                set => nombreEditar = value;
            }

            public int PrecioEditar
            {
                get => precioEditar;
                set => precioEditar = value;
            }

            public string TipoEditar
            {
                get => tipoEditar;
                set => tipoEditar = value;
            }

            public int NumeroSerieEditar
            {
                get => numero_SerieEditar;
                set => numero_SerieEditar = value;
            }

            public string MarcaEditar
            {
                get => marcaEditar;
                set => marcaEditar = value;
            }

            public int ConsumoElectricoEditar
            {
                get => consumo_ElectricoEditar;
                set => consumo_ElectricoEditar = value;
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