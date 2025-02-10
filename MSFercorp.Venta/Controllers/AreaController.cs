using Microsoft.AspNetCore.Mvc;
using MSFercorp.Venta.Models;
using MSFercorp.Venta.Services;
using System.Threading.Tasks;

namespace MSFercorp.Venta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : Controller
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService) => _areaService = areaService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _areaService.GetAllAreas());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _areaService.GetArea(id));

        [HttpPost]
        public async Task<IActionResult> Create(Area area)
        {
            await _areaService.CreateArea(area);
            return CreatedAtAction(nameof(Get), new { id = area.Id }, area);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Area area)
        {
            if (id != area.Id) return BadRequest();
            await _areaService.UpdateArea(area);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _areaService.DeleteArea(id);
            return NoContent();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
