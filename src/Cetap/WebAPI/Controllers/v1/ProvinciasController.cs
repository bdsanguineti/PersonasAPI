using Cetap.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public ProvinciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetProvincias()
        {
            List<Provincia> listaProvincia = new List<Provincia>();

            try
            {
                listaProvincia = _context.Provincias.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = listaProvincia });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = listaProvincia });
            }
            //return await _context.Provincias.ToListAsync();
        }
    }
}
