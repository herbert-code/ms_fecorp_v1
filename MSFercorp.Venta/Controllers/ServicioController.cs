using Microsoft.AspNetCore.Mvc;
using MSFercorp.Venta.Models;
using MSFercorp.Venta.Services;
using System;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioController : Controller
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService) => _servicioService = servicioService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _servicioService.GetAllServicios());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _servicioService.GetServicio(id));

        [HttpPost]
        public async Task<IActionResult> Create(Servicio servicio)
        {            
            await _servicioService.CreateServicio(servicio);
            return CreatedAtAction(nameof(Get), new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Servicio servicio)
        {
            if (id != servicio.Id) return BadRequest();
            await _servicioService.UpdateServicio(servicio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicioService.DeleteServicio(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
