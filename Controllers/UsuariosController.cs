using Aula_api_fuel_manager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula_api_fuel_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var type = await _context.Usuarios.ToListAsync();

            return Ok(type);

        }
        [HttpPost]
        public async Task<ActionResult> Create(UsuarioDto type)
        {
            Usuario novo = new Usuario();
            {
                Name = type.Name
                Password = BCrypt.Net.BCrypt.HashPassword(type.Password) // Criptografa a senha
                Perfil = type.Perfil
                 
            };
          

            _context.Usuarios.Add(novo); //Faz a inserção de Usuarios no BD
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = novo.Id }, novo);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var type = await _context.Usuarios
               // recupera os serviços do usuario especifico
                .FirstOrDefaultAsync(c => c.Id == id);

            if (type == null) return NotFound();  // Significa que o dado não foi encontrado

            GerarLinks(type);
            return Ok(type);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UsuarioDto type)
        {
            if (id != type.Id) return BadRequest();

            var typeDb = _context.Usuarios.AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (typeDb == null) return NotFound();

            typeDb.Name = type.Name;
            typeDb.Password = BCrypt.Net.BCrypt.HashPassword(type.Password);
            typeDb.Perfil = type.Perfil;

            _context.Usuarios.Update(typeDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var type = await _context.Usuarios.FindAsync(id);

            if (type == null) return NotFound();

            _context.Usuarios.Remove(type);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private void GerarLinks(Usuario type)
        {
          /*type.Links.Add(new LinkDto(type.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            type.Links.Add(new LinkDto(type.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            type.Links.Add(new LinkDto(type.Id, Url.ActionLink(), rel: "delete", metodo: "Delete"));*/
        }
    }
}

