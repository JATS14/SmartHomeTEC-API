using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;

namespace SmartHomeTEC_API.Controllers
{
   //clase con un get que coloca la lista de ususario en un link para ser obtenido en la aplicacion web
    [ApiController]
    [Route("[controller]")]
    public class ListaDispositivosController : ControllerBase
    {
        private readonly ILogger<ListaDispositivosController> _logger;

        public ListaDispositivosController(ILogger<ListaDispositivosController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IList<Dispositivo> Get()
        {
            return Administrador.getDipositivos();
        }
        

    }
}