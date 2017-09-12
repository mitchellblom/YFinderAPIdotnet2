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
    public class DescriptorController : Controller
    {

        private YfinderAPIdotnet2Context _context;
        public DescriptorController(YfinderAPIdotnet2Context ctx)
        {
            _context = ctx;
        }

        // GET all Descriptors from descriptor table
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> descriptors = from descriptor in _context.Descriptor select descriptor;

            if (descriptors == null)
            {
                return NotFound();
            } 

                return Ok(descriptors);
        }

        //GET one descriptor from descriptor table
        [HttpGet("{id}", Name = "GetDescriptor")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Descriptor descriptor = _context.Descriptor.Single(m => m.DescriptorId == id);

                if (descriptor == null)
                {
                    return NotFound();
                }
                
                return Ok(descriptor);
            }
            catch (System.InvalidOperationException ex)
            {
                var filler = ex;
                return NotFound();
            }
        }

        // POST descriptor values to the descriptor table
        [HttpPost]
        public IActionResult Post([FromBody] Descriptor descriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Descriptor.Add(descriptor);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DescriptorExists(descriptor.DescriptorId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetDescriptor", new { id = descriptor.DescriptorId }, descriptor);
        }

    // Checks if the Descriptor has been created or not
    private bool DescriptorExists(int descriptorId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing descriptor
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Descriptor descriptor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != descriptor.DescriptorId)
            {
                return BadRequest();
            }

            _context.Entry(descriptor).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptorExists(id))
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

        // Delete descriptors
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Descriptor descriptor = _context.Descriptor.Single(r => r.DescriptorId == id);
            if (descriptor == null)
            {
                return NotFound();
            }

            _context.Descriptor.Remove(descriptor);
            _context.SaveChanges();

            return Ok(descriptor);
        }

    }
}