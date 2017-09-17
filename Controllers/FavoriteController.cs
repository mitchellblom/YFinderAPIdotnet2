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
    public class FavoriteController : Controller
    {

        private YfinderAPIdotnet2Context _context;
        public FavoriteController(YfinderAPIdotnet2Context ctx)
        {
            _context = ctx;
        }

        // GET all Favorites from favorite table
        [HttpGet]
        public IActionResult Get(string active)
        {
            IQueryable<object> favorites = from favorite in _context.Favorite select favorite;

            if (favorites == null)
            {
                return NotFound();
            } 

                return Ok(favorites);
        }

        //GET one favorite from favorite table
        [HttpGet("{id}", Name = "GetFavorite")]
        public IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Favorite favorite = _context.Favorite.Single(m => m.FavoriteId == id);

                if (favorite == null)
                {
                    return NotFound();
                }
                
                return Ok(favorite);
            }
            catch (System.InvalidOperationException ex)
            {
                var filler = ex;
                return NotFound();
            }
        }

        // POST favorite values to the favorite table
        [HttpPost]
        public IActionResult Post([FromBody] Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Favorite.Add(favorite);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FavoriteExists(favorite.FavoriteId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetFavorite", new { id = favorite.FavoriteId }, favorite);
        }

    // Checks if the Favorite has been created or not
    private bool FavoriteExists(int favoriteId)
    {
      throw new NotImplementedException();
    }

    // PUT edited values on existing favorite
    [HttpPut("{id}")]
         public IActionResult Put(int id, [FromBody] Favorite favorite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorite.FavoriteId)
            {
                return BadRequest();
            }

            _context.Entry(favorite).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteExists(id))
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

        // Delete favorites
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Favorite favorite = _context.Favorite.Single(r => r.FavoriteId == id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorite.Remove(favorite);
            _context.SaveChanges();

            return Ok(favorite);
        }

    }
}