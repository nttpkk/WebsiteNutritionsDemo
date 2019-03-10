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
        [HttpGet]
        [Route("")]
        public List<Foods> Listing()
        {
            NutritionsDBContext context = new NutritionsDBContext();
            List<Foods> allFoods = context.Foods.ToList();

            return allFoods;
        }
        [HttpPost]
        [Route("")]
        public bool CreateNewEvent([FromBody] Events newEvent)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            context.Events.Add(newEvent);
            context.SaveChanges();
            return true;
        }

        [HttpPut]
        [Route("{foodID}")]
        public Events ModifyEvent(int foodID, Events updatedEvent)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            Events foodVariable = context.Events.Find(foodID);
            if (foodVariable == null)
            {
                return null;
            }
            foodVariable.FoodAmount = updatedEvent.FoodAmount;
            context.SaveChanges();

            return foodVariable;
        }

        [HttpDelete]
        [Route("{foodID}")]
        public bool DeleteEvent(int foodID)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            Events foodVariable = context.Events.Find(foodID);

            if (foodVariable == null)
            {
                return false;
            }

            context.Events.Remove(foodVariable);
            context.SaveChanges();

            return true;
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
