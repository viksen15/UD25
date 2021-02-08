﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ej4.Models;

namespace API_ej4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly APIContext _context;

        public PeliculasController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Peliculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peliculas>>> GetPeliculas()
        {
            return await _context.Peliculas.ToListAsync();
        }

        // GET: api/Peliculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peliculas>> GetPeliculas(int id)
        {
            var peliculas = await _context.Peliculas.FindAsync(id);

            if (peliculas == null)
            {
                return NotFound();
            }

            return peliculas;
        }

        // PUT: api/Peliculas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeliculas(int id, Peliculas peliculas)
        {
            if (id != peliculas.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(peliculas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculasExists(id))
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

        // POST: api/Peliculas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Peliculas>> PostPeliculas(Peliculas peliculas)
        {
            _context.Peliculas.Add(peliculas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PeliculasExists(peliculas.Codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPeliculas", new { id = peliculas.Codigo }, peliculas);
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Peliculas>> DeletePeliculas(int id)
        {
            var peliculas = await _context.Peliculas.FindAsync(id);
            if (peliculas == null)
            {
                return NotFound();
            }

            _context.Peliculas.Remove(peliculas);
            await _context.SaveChangesAsync();

            return peliculas;
        }

        private bool PeliculasExists(int id)
        {
            return _context.Peliculas.Any(e => e.Codigo == id);
        }
    }
}
