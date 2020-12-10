using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTienda.Models;

namespace ApiTienda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaItemsController : ControllerBase
    {
        private readonly TiendaContext _context;

        public TiendaItemsController(TiendaContext context)
        {
            _context = context;
        }

        // GET: api/TiendaItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiendaItem>>> GetTiendaItems()
        {
            return await _context.TiendaItems.ToListAsync();
        }

        // GET: api/TiendaItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiendaItem>> GetTiendaItem(int id)
        {
            var tiendaItem = await _context.TiendaItems.FindAsync(id);

            if (tiendaItem == null)
            {
                return NotFound();
            }

            return tiendaItem;
        }

        // PUT: api/TiendaItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiendaItem(int id, TiendaItem tiendaItem)
        {
            if (id != tiendaItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tiendaItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiendaItemExists(id))
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

        // POST: api/TiendaItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TiendaItem>> PostTiendaItem(TiendaItem tiendaItem)
        {
            _context.TiendaItems.Add(tiendaItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTiendaItem", new { id = tiendaItem.Id }, tiendaItem);
            return CreatedAtAction(nameof(GetTiendaItem), new { id = tiendaItem.Id }, tiendaItem);
        }

        // DELETE: api/TiendaItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TiendaItem>> DeleteTiendaItem(int id)
        {
            var tiendaItem = await _context.TiendaItems.FindAsync(id);
            if (tiendaItem == null)
            {
                return NotFound();
            }

            _context.TiendaItems.Remove(tiendaItem);
            await _context.SaveChangesAsync();

            return tiendaItem;
        }

        private bool TiendaItemExists(int id)
        {
            return _context.TiendaItems.Any(e => e.Id == id);
        }
    }
}
