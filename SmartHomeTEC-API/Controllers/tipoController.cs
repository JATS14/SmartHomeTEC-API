using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;
using Microsoft.AspNetCore.Http;

namespace SmartHomeTEC_API.Controllers
{
    //clase con un get que coloca la lista de Tipos en un link para ser obtenido en la aplicacion web

    [ApiController]
    [Route("[controller]")]
    public class tipoController : ControllerBase
    {
        private readonly ILogger<tipoController> _logger;

        public tipoController(ILogger<tipoController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IList<Tipo> Get()
        {
            return Administrador.getTipo();
        }
    }

}