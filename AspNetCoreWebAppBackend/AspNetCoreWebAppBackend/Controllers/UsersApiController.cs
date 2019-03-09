﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreWebAppBackend.Database;

namespace AspNetCoreWebAppBackend.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public List<Users> ListUsers()
        {
            NutritionsDBContext context = new NutritionsDBContext();
            List<Users> allUsers = context.Users.ToList();

            return allUsers;
        }

        [HttpPost]
        [Route("")]
        public bool CreateNewUser([FromBody] Users newUser)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            context.Users.Add(newUser);
            context.SaveChanges();
            return true;
        }

        [HttpPut]
        [Route("{userID}")]
        public Users ModifyUser(int userID, [FromBody] Users updatedUser)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            Users user = context.Users.Find(userID);

            // Are we able to find user with given ID?
            if (user == null)
            {
                return null;
            }

            // modification takes places
            user.UserName = updatedUser.UserName;
            context.SaveChanges();

            return user;
        }

        [HttpDelete]
        [Route("{userID}")]
        public bool DeleteUser(int userID)
        {
            NutritionsDBContext context = new NutritionsDBContext();
            Users user = context.Users.Find(userID);

            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            context.SaveChanges();

            return true;
        }

        //private readonly NutritionsDBContext _context;
        //public UsersApiController(NutritionsDBContext context)
        //{
        //    _context = context;
        //}
        //// GET: api/UsersApi
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        //{
        //    return await _context.Users.ToListAsync();
        //}
        //// GET: api/UsersApi/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Users>> GetUsers(int id)
        //{
        //    var users = await _context.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return users;
        //}
        //// PUT: api/UsersApi/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUsers(int id, Users users)
        //{
        //    if (id != users.userID)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(users).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsersExists(id))
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
        //// POST: api/UsersApi
        //[HttpPost]
        //public async Task<ActionResult<Users>> PostUsers(Users users)
        //{
        //    _context.Users.Add(users);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction("GetUsers", new { id = users.userID }, users);
        //}
        //// DELETE: api/UsersApi/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Users>> DeleteUsers(int id)
        //{
        //    var users = await _context.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Users.Remove(users);
        //    await _context.SaveChangesAsync();
        //    return users;
        //}
        //private bool UsersExists(int id)
        //{
        //    return _context.Users.Any(e => e.userID == id);
        //}
    }
}
