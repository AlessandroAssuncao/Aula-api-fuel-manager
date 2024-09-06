using Aula_api_fuel_manager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_api_fuel_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstabelecimentosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Estabelecimento.ToListAsync();

            return Ok(model);
        }
    }
}
