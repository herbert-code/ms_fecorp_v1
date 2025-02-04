using Microsoft.AspNetCore.Mvc;
using MSFercorp.Venta.Models;
using MSFercorp.Venta.Services;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService) => _empresaService = empresaService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _empresaService.GetAllEmpresas());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _empresaService.GetEmpresa(id));

        [HttpPost]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            await _empresaService.CreateEmpresa(empresa);
            return CreatedAtAction(nameof(Get), new { id = empresa.Id }, empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Empresa empresa)
        {
            if (id != empresa.Id) return BadRequest();
            await _empresaService.UpdateEmpresa(empresa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _empresaService.DeleteEmpresa(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
