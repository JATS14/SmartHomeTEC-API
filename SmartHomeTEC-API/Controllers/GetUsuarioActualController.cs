using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHomeTEC_API.API;


namespace SmartHomeTEC_API.Controllers
{
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