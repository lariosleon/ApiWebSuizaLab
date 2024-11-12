using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using web_api_v1.Models;


namespace web_api_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
  
        private WebApiContext _context;
       

        public CitasController(WebApiContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IEnumerable<Cita_sql> ListarCitas()
        {
            var query = from ct in _context.Citass
                        join pc in _context.Pacientes on ct.Idpaciente equals pc.Idpaciente
                        join ep in _context.Especialidads on ct.Idespecialidad equals ep.Idespecialidad
                        orderby ct.Fechacita descending
                        select new Cita_sql
                        {
                            Idcita = ct.Idcita,
                            Paciente = pc.NombreCompleto,
                            Especialidad = ep.Descripcion,
                            FechaCita = ct.Fechacita
                        };

            return query.ToList();
        }

        [HttpPost]
        public ActionResult grabar(Cita solcitas)
        {
            var _citas = new Citas();

            _citas.Idpaciente = solcitas.Idpaciente;
            _citas.Idespecialidad = solcitas.Idespecialidad;
            _citas.Fechacita = DateTime.Now;

            _context.Citass.Add(_citas);
            _context.SaveChanges();

            return Ok(_citas);
        }
        [HttpPut]
        public ActionResult modificar(Cita solcitas,int Idcita)
        {
            var _citasactualizar = _context.Citass.Find(Idcita);

            _citasactualizar.Idpaciente = solcitas.Idpaciente;
            _citasactualizar.Idespecialidad = solcitas.Idespecialidad;
            _citasactualizar.Fechacita = DateTime.Now;

            _context.Entry(_citasactualizar).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok("Cita Actualizada con codigo:" + Idcita);
        }

        [HttpDelete]
        public ActionResult eliminar(int Idcita)
        {
            var _citaseliminar = _context.Citass.Find(Idcita);
            _context.Remove(_citaseliminar);
            _context.SaveChanges();

            return Ok("Cita eliminada con codigo:" + Idcita);
        }
     }
}
