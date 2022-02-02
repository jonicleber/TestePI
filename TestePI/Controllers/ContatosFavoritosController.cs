using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestePI;

namespace TestePI.Controllers
{
    [Route("api/contatosfavoritos")]
    [ApiController]
    public class ContatosFavoritosController : ControllerBase
    {
        private readonly masterContext _context;

        public ContatosFavoritosController(masterContext context)
        {
            _context = context;
        }

        // GET: api/ContatosFavoritos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContatosFavoritos>>> GetContatosFavoritos()
        {
            return await _context.ContatosFavoritos.ToListAsync();
        }

        // GET: api/ContatosFavoritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContatosFavoritos>> GetContatosFavoritos(int id)
        {
            var contatosFavoritos = await _context.ContatosFavoritos.FindAsync(id);

            if (contatosFavoritos == null)
            {
                return NotFound();
            }

            return contatosFavoritos;
        }

        // PUT: api/ContatosFavoritos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatosFavoritos(int id, ContatosFavoritos contatosFavoritos)
        {
            if (id != contatosFavoritos.ICodFavorito)
            {
                return BadRequest();
            }

            _context.Entry(contatosFavoritos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosFavoritosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ContatosFavoritos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ContatosFavoritos>> PostContatosFavoritos(ContatosFavoritos contatosFavoritos)
        {
            _context.ContatosFavoritos.Add(contatosFavoritos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContatosFavoritos", new { id = contatosFavoritos.ICodFavorito }, contatosFavoritos);
        }

        // DELETE: api/ContatosFavoritos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ContatosFavoritos>> DeleteContatosFavoritos(int id)
        {
            var contatosFavoritos = await _context.ContatosFavoritos.FindAsync(id);
            if (contatosFavoritos == null)
            {
                return NotFound();
            }

            _context.ContatosFavoritos.Remove(contatosFavoritos);
            await _context.SaveChangesAsync();

            return contatosFavoritos;
        }

        private bool ContatosFavoritosExists(int id)
        {
            return _context.ContatosFavoritos.Any(e => e.ICodFavorito == id);
        }
    }
}
