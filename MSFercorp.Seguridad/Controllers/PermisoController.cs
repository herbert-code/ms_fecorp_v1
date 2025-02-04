using Microsoft.AspNetCore.Mvc;
using MSFercorp.Seguridad.Models;
using MSFercorp.Seguridad.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MSFercorp.Seguridad.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : Controller
    {
        private readonly IPermisoService _permisoService;

        public PermisoController(IPermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permiso>>> GetPermisos()
        {
            var permisos = await _permisoService.GetAllPermisos();
            return Ok(permisos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permiso>> GetPermiso(int id)
        {
            var permiso = await _permisoService.GetPermisoById(id);
            return permiso == null ? NotFound() : Ok(permiso);
        }

        [HttpPost]
        public async Task<ActionResult<Permiso>> CreatePermiso(Permiso permiso)
        {
            var createdPermiso = await _permisoService.CreatePermiso(permiso);
            return CreatedAtAction(nameof(GetPermiso), new { id = createdPermiso.ID_Permiso }, createdPermiso);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
