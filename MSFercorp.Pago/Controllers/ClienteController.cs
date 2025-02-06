using Microsoft.AspNetCore.Mvc;
using MSFercorp.Pago.Models;
using MSFercorp.Pago.Services;
using System.Threading.Tasks;

namespace MSFercorp.Pago.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) => _clienteService = clienteService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _clienteService.GetAllClientes());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _clienteService.GetCliente(id));
       
        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await _clienteService.CreateCliente(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            await _clienteService.UpdateCliente(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.DeleteCliente(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
