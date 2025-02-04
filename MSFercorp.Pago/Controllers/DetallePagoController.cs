using Microsoft.AspNetCore.Mvc;
using MSFercorp.Pago.Models;
using MSFercorp.Pago.Services;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetallePagoController : Controller
    {
        private readonly IDetallePagoService _detallepagoService;

        public DetallePagoController(IDetallePagoService detallepagoService) => _detallepagoService = detallepagoService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _detallepagoService.GetAllDetallePagos());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _detallepagoService.GetDetallePago(id));
       
        [HttpPost]
        public async Task<IActionResult> Create(DetallePago detallepago)
        {
            await _detallepagoService.CreateDetallePago(detallepago);
            return CreatedAtAction(nameof(Get), new { id = detallepago.Id }, detallepago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DetallePago detallepago)
        {
            if (id != detallepago.Id) return BadRequest();
            await _detallepagoService.UpdateDetallePago(detallepago);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _detallepagoService.DeleteDetallePago(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
