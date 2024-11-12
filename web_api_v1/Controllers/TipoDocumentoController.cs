using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace web_api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private WebApiContext _context;

        public TipoDocumentoController(WebApiContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<TipoDocumento> Get() => _context.TipoDocumentos.ToList();
    }
}
