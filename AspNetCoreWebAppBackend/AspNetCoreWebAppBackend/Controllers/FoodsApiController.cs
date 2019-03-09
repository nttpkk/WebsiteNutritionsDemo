using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebAppBackend.Database;

namespace AspNetCoreWebAppBackend.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodsApiController : ControllerBase
    {
        [Route("")]
        public List<Foods> Listing()
        {
            NutritionsDBContext context = new NutritionsDBContext();
            List<Foods> allFoods = context.Foods.ToList();

            return allFoods;
        }
        //private readonly NutritionsDBContext _context;

        //public FoodsApiController(NutritionsDBContext context)
        //{
        //    _context = context;
        //}

        //// GET: api/FoodsApi
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Foods>>> GetFoods()
        //{
        //    return await _context.Foods.ToListAsync();
        //}

        //// GET: api/FoodsApi/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Foods>> GetFoods(int id)
        //{
        //    var foods = await _context.Foods.FindAsync(id);

        //    if (foods == null)
        //    {
        //        return NotFound();
        //    }

        //    return foods;
        //}

        //// PUT: api/FoodsApi/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFoods(int id, Foods foods)
        //{
        //    if (id != foods.FoodId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(foods).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FoodsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/FoodsApi
        //[HttpPost]
        //public async Task<ActionResult<Foods>> PostFoods(Foods foods)
        //{
        //    _context.Foods.Add(foods);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFoods", new { id = foods.FoodId }, foods);
        //}

        //// DELETE: api/FoodsApi/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Foods>> DeleteFoods(int id)
        //{
        //    var foods = await _context.Foods.FindAsync(id);
        //    if (foods == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Foods.Remove(foods);
        //    await _context.SaveChangesAsync();

        //    return foods;
        //}

        //private bool FoodsExists(int id)
        //{
        //    return _context.Foods.Any(e => e.FoodId == id);
        //}
    }
}
