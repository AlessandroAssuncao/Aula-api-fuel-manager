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
        [HttpPost]
        public async Task<ActionResult> Create(Estabelecimento model)
        {
            _context.Estabelecimento.Add(model); //Faz a inserção de Estabelecimentos no BD
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Estabelecimento.FirstOrDefaultAsync(c => c.Id == id);

            if(model == null) NotFound();  // Significa que o dado não foi encontrado

            return Ok(model);

        }
    }
}
