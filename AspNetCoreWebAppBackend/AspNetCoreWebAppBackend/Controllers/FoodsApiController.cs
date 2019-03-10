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
        public List<Foods> ListFoods()
        {
            NutritionsDBContext context = new NutritionsDBContext();
            List<Foods> allFoods = context.Foods.ToList();

            return allFoods;
        }

        [HttpPost]
        [Route("")]
        public bool CreateNewFood([FromBody] Foods newFood)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            context.Foods.Add(newFood);
            context.SaveChanges();
            return true;
        }

        //[HttpPut]
        //[Route("{foodID}")]
        //public Foods ModifyFood(int foodID, Foods updatedFood)
        //{
        //    NutritionsDBContext context = new NutritionsDBContext();
        //    Foods foodVariable = context.Foods.Find(foodID);
        //    if (foodVariable == null)
        //    {
        //        return null;
        //    }
        //    foodVariable.FoodName = updatedFood.FoodName;
        //    context.SaveChanges();

        //    return foodVariable;
        //}

        [HttpDelete]
        [Route("{foodID}")]
        public bool DeleteFood(int foodID)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            Foods foodVariable = context.Foods.Find(foodID);

            if (foodVariable == null)
            {
                return false;
            }

            context.Foods.Remove(foodVariable);
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
