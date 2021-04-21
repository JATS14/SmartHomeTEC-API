using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;

namespace SmartHomeTEC_API.Controllers
{
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