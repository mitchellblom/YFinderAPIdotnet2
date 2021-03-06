using System;
using System.Collections.Generic;
using System.Linq;
using YfinderAPIdotnet2.Data;
using YfinderAPIdotnet2.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace YfinderAPIdotnet2.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowWhiteListOrigins")]
    public class HotspotController : Controller
    {

        private YfinderAPIdotnet2Context _context;
        public HotspotController(YfinderAPIdotnet2Context ctx)
        {
            _context = ctx;
        }

        // GET all Hotspots from hotspot table
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> hotspots = from hotspot in _context.Hotspot select hotspot;

            if (hotspots == null)
            {
                return NotFound();
            } 

                return Ok(hotspots);
        }

        //GET one hotspot from hotspot table
        [HttpGet("{id}", Name = "GetHotspot")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Hotspot hotspot = _context.Hotspot.Single(m => m.HotspotId == id);

                if (hotspot == null)
                {
                    return NotFound();
                }
                
                return Ok(hotspot);
            }
            catch (System.InvalidOperationException ex)
            {
                var filler = ex;
                return NotFound();
            }
        }

        // POST hotspot values to the hotspot table
        [HttpPost]
        public IActionResult Post([FromBody] Hotspot hotspot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Hotspot.Add(hotspot);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HotspotExists(hotspot.HotspotId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetHotspot", new { id = hotspot.HotspotId }, hotspot);
        }

    // Checks if the Hotspot has been created or not
    private bool HotspotExists(int hotspotId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing hotspot
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Hotspot hotspot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotspot.HotspotId)
            {
                return BadRequest();
            }

            _context.Entry(hotspot).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotspotExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Hotspot hotspot = _context.Hotspot.Single(r => r.HotspotId == id);
            if (hotspot == null)
            {
                return NotFound();
            }

            _context.Hotspot.Remove(hotspot);
            _context.SaveChanges();

            return Ok(hotspot);
        }

    }
}