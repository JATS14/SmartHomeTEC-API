using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;


namespace SmartHomeTEC_API.Controllers
{
    //Clase que hace un get con los datos de todos los distibuidores
    [ApiController]
    [Route("[controller]")]
    public class DistribuidoresController : ControllerBase
    {
        private readonly ILogger<DistribuidoresController> _logger;

        public DistribuidoresController(ILogger<DistribuidoresController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IList<Distribuidor> Get()
        {
            return Administrador.getDistribuidores();
        }
    }
}