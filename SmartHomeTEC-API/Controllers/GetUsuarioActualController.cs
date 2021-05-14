using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;


namespace SmartHomeTEC_API.Controllers
{
    //clase con un get que coloca la lista de ususario en un link para ser obtenido en la aplicacion web
    [ApiController]
    [Route("[controller]")]
    public class GetUsuarioActualController : ControllerBase
    {
        private readonly ILogger<GetUsuarioActualController> _logger;

        public GetUsuarioActualController(ILogger<GetUsuarioActualController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IList<Usuario> Get()
        {
            IList<Usuario> list = new List<Usuario>();
            list.Add(Administrador.obtenerUsuarioActual());
            return list;
        }
        
        
    }
}