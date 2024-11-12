using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace web_api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private WebApiContext _context;

        public EspecialidadController(WebApiContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Especialidad> Get() => _context.Especialidads.ToList();
    }
}
