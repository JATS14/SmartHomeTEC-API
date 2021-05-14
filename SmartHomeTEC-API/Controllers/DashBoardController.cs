using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;

namespace SmartHomeTEC_API.Controllers
{
    //Clse necesaria para enviar en un get todos los datos necesarios para formar el dashboard en la web
    
    [ApiController]
    [Route("[controller]")]
    public class DashBoardController : ControllerBase
    {
        private readonly ILogger<DashBoardController> _logger;

        public DashBoardController(ILogger<DashBoardController> logger)
        {
            _logger = logger;
        }
        
        //Esta funcion es la encargada de hacer get a los datos necesarios para formar grafica
        [HttpGet]
        [Route("DatosDeGraficas")]
        public enviarDatosDashBoard ObtenerDatosDashBoard()
        {
            Administrador.obtener_Disp_Region();
            /*return new enviarDatosDashBoard(Administrador.lista_Dispositivos.Count,Administrador.prom_Dispo_usuario(),
                                            Administrador.cantidad_Dispo(),Administrador.disp_America,
                                            Administrador.disp_Europa, Administrador.disp_Asia,
                                            Administrador.disp_Africa, Administrador.disp_Oceania);
            */
            return new enviarDatosDashBoard(100, 15, 60, 10, 11, 12, 13, 14);

        }
        
        //Esta funcion es la encargada de hacer get a la lista de dispositiovs con usuario asignado
        [HttpGet]
        [Route("ListaDispositivosUsuario")]
        public IList<Dispositivo> ObtenerListaDispositivosUsuario()
        {
            return Administrador.obtener_Disp_Usuarios();
        }
        
        //Esta funcion es la encargada de hacer get a la lista de dispositiovs sin usuario asignado
        [HttpGet]
        [Route("ListaDispositivosSinUsuario")]
        public IList<Dispositivo> ObtenerListaDispositivosSinUsuario()
        {
            return Administrador.obtener_Disp_SinUsuarios();
        }
        
        //Esta funcion es la encargada de hacer get a los datos para formar los reportes de la vista usuario 
        [HttpGet]
        [Route("ReportesUsuario")]
        public enviarDatosUsuario ObtenerReportesUsuarioActual()
        {
            return new enviarDatosUsuario(1200,15,22,"Computadoras");
        }
        
        
        //Esta clase asigna los valores necesarios para generar los reportes de la vista usuario
        public class enviarDatosUsuario
        {
            public int consumoMensual;
            public int inicioHoraMasUso;
            public int finalHoraMasUso;
            public string TipoDeMayorUso;
            //Contructor
            public enviarDatosUsuario(int consumoMensual, int inicioHoraMasUso, int finalHoraMasUso, string tipoDeMayorUso)
            {
                this.consumoMensual = consumoMensual;
                this.inicioHoraMasUso = inicioHoraMasUso;
                this.finalHoraMasUso = finalHoraMasUso;
                TipoDeMayorUso = tipoDeMayorUso;
            }
            //getters y setters
            public int ConsumoMensual
            {
                get => consumoMensual;
                set => consumoMensual = value;
            }

            public int InicioHoraMasUso
            {
                get => inicioHoraMasUso;
                set => inicioHoraMasUso = value;
            }

            public int FinalHoraMasUso
            {
                get => finalHoraMasUso;
                set => finalHoraMasUso = value;
            }

            public string TipoDeMayorUso1
            {
                get => TipoDeMayorUso;
                set => TipoDeMayorUso = value;
            }
        }
        
        

        //Esta clase asigna los valores necesarios para formar una grafica en la web
        public class enviarDatosDashBoard
        {
            public int totalDispocitivos;
            public int promDispUsuario;
            public int cantDispAsociados;
            public int dispAmerica;
            public int dispEuropa;
            public int dispAsia;
            public int dispAfrica;
            public int dispOceania;
            
            //Contructor
            public enviarDatosDashBoard(int totalDispocitivos, int promDispUsuario,int cantDispAsociados,
                                        int dispAmerica, int dispEuropa, int dispAsia,
                                        int dispAfrica, int dispOceania)
            {
                this.totalDispocitivos = totalDispocitivos;
                this.promDispUsuario = promDispUsuario;
                this.cantDispAsociados = cantDispAsociados;
                this.dispAmerica = dispAmerica;
                this.dispEuropa = dispEuropa;
                this.dispAsia = dispAsia;
                this.dispAfrica = dispAfrica;
                this.dispOceania = dispOceania;
            }
            //getters y setters
            public int TotalDispocitivos
            {
                get => totalDispocitivos;
                set => totalDispocitivos = value;
            }

            public int PromDispUsuario
            {
                get => promDispUsuario;
                set => promDispUsuario = value;
            }

            public int CantDispAsociados
            {
                get => cantDispAsociados;
                set => cantDispAsociados = value;
            }

            public int DispAmerica
            {
                get => dispAmerica;
                set => dispAmerica = value;
            }

            public int DispEuropa
            {
                get => dispEuropa;
                set => dispEuropa = value;
            }

            public int DispAsia
            {
                get => dispAsia;
                set => dispAsia = value;
            }

            public int DispAfrica
            {
                get => dispAfrica;
                set => dispAfrica = value;
            }

            public int DispOceania
            {
                get => dispOceania;
                set => dispOceania = value;
            }
        }
        
        
        
    }
}