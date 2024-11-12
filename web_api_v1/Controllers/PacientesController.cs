using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using web_api_v1.Models;

namespace web_api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private WebApiContext _context;

        public PacientesController(WebApiContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Paciente_sql> ListarPacientes()
        {
                var query = from pc in _context.Pacientes
                            join td in _context.TipoDocumentos on pc.Idtipodocumento equals td.Idtipodocumento
                            select new Paciente_sql
                            {
                                Idpaciente = pc.Idpaciente,
                                NumeroDocumento = pc.NumeroDocumento,
                                NombreCompleto = pc.NombreCompleto,
                                TipodeDocumento = td.Descripcion
                            };

                return query.ToList();
        }
    }
}
