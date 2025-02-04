using Microsoft.AspNetCore.Mvc;
using MSFercorp.Pago.Models;
using MSFercorp.Pago.Services;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : Controller
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService) => _pagoService = pagoService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _pagoService.GetAllPagos());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _pagoService.GetPago(id));

        [HttpPost]
        public async Task<IActionResult> Create(Models.Pago pago)
        {
            await _pagoService.CreatePago(pago);
            return CreatedAtAction(nameof(Get), new { id = pago.IdPago }, pago);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Models.Pago pago)
        {
            if (id != pago.IdPago) return BadRequest();
            await _pagoService.UpdatePago(pago);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pagoService.DeletePago(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
