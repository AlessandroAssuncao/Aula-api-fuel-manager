﻿using Aula_api_fuel_manager.Models;
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
            var type = await _context.Estabelecimento.ToListAsync();

            return Ok(type);

        }
        [HttpPost]
        public async Task<ActionResult> Create(Estabelecimento type)
        {
            _context.Estabelecimento.Add(type); //Faz a inserção de Estabelecimentos no BD
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = type.Id }, type);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var type = await _context.Estabelecimento
                .Include(t => t.Servicos)// recupera os serviços do estabelecimento especifico
                .FirstOrDefaultAsync(c => c.Id == id);

            if (type == null) return NotFound();  // Significa que o dado não foi encontrado

            GerarLinks(type);
            return Ok(type);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Estabelecimento type)
        {
            if (id != type.Id) return BadRequest();

            var typeDb = _context.Estabelecimento.AsNoTracking()
                 .FirstOrDefaultAsync(c => c.Id == id);

            if (typeDb == null) return NotFound();

            _context.Estabelecimento.Update(type);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var type = await _context.Estabelecimento.FindAsync(id);

            if (type == null) return NotFound();  

            _context.Estabelecimento.Remove(type);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private void GerarLinks(Estabelecimento type)
        {
            type.Links.Add(new LinkDto(type.Id, Url.ActionLink(), rel : "self", metodo: "GET"));
            type.Links.Add(new LinkDto(type.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            type.Links.Add(new LinkDto(type.Id, Url.ActionLink(), rel: "delete", metodo: "Delete"));
        }
    }
}
