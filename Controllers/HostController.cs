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
    public class HostController : Controller
    {

        private YfinderAPIdotnet2Context _context;
        public HostController(YfinderAPIdotnet2Context ctx)
        {
            _context = ctx;
        }

        // GET all Hosts from host table
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> hosts = from host in _context.Host select host;

            if (hosts == null)
            {
                return NotFound();
            } 

                return Ok(hosts);
        }

        //GET one host from host table
        [HttpGet("{id}", Name = "GetHost")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Host host = _context.Host.Single(m => m.HostId == id);

                if (host == null)
                {
                    return NotFound();
                }
                
                return Ok(host);
            }
            catch (System.InvalidOperationException ex)
            {
                var filler = ex;
                return NotFound();
            }
        }

        // POST host values to the host table
        [HttpPost]
        public IActionResult Post([FromBody] Host host)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Host.Add(host);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HostExists(host.HostId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetHost", new { id = host.HostId }, host);
        }

    // Checks if the Host has been created or not
    private bool HostExists(int hostId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing host
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Host host)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != host.HostId)
            {
                return BadRequest();
            }

            _context.Entry(host).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostExists(id))
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

            Host host = _context.Host.Single(r => r.HostId == id);
            if (host == null)
            {
                return NotFound();
            }

            _context.Host.Remove(host);
            _context.SaveChanges();

            return Ok(host);
        }

    }
}