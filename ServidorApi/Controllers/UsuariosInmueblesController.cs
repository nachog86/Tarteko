using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServidorApi.Data;

namespace ServidorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosInmueblesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosInmueblesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosInmuebles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioInmueble>>> GetUsuarioInmuebles()
        {
          if (_context.UsuarioInmuebles == null)
          {
              return NotFound();
          }
            return await _context.UsuarioInmuebles.ToListAsync();
        }

        // GET: api/UsuariosInmuebles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioInmueble>> GetUsuarioInmueble(int id)
        {
          if (_context.UsuarioInmuebles == null)
          {
              return NotFound();
          }
            var usuarioInmueble = await _context.UsuarioInmuebles.FindAsync(id);

            if (usuarioInmueble == null)
            {
                return NotFound();
            }

            return usuarioInmueble;
        }

        // PUT: api/UsuariosInmuebles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioInmueble(int id, UsuarioInmueble usuarioInmueble)
        {
            if (id != usuarioInmueble.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(usuarioInmueble).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioInmuebleExists(id))
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

        // POST: api/UsuariosInmuebles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioInmueble>> PostUsuarioInmueble(UsuarioInmueble usuarioInmueble)
        {
          if (_context.UsuarioInmuebles == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UsuarioInmuebles'  is null.");
          }
            _context.UsuarioInmuebles.Add(usuarioInmueble);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioInmuebleExists(usuarioInmueble.UsuarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioInmueble", new { id = usuarioInmueble.UsuarioId }, usuarioInmueble);
        }

        // DELETE: api/UsuariosInmuebles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioInmueble(int id)
        {
            if (_context.UsuarioInmuebles == null)
            {
                return NotFound();
            }
            var usuarioInmueble = await _context.UsuarioInmuebles.FindAsync(id);
            if (usuarioInmueble == null)
            {
                return NotFound();
            }

            _context.UsuarioInmuebles.Remove(usuarioInmueble);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioInmuebleExists(int id)
        {
            return (_context.UsuarioInmuebles?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }
    }
}
