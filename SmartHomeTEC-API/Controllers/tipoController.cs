using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;

namespace SmartHomeTEC_API.Controllers
{
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