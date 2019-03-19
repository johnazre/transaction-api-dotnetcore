using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransactionAPI.Models;

namespace TransactionAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    // Declare the DataContext
    private DataContext _context;
    public UsersController(DataContext context)
    {
      _context = context;
    }

    // GET api/users
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
      return _context.Users;
    }

    // GET api/users/5
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
      return _context.Users
          // Find the first user that meets this condition
          .FirstOrDefault(user => user.Id == id);
    }

    // POST api/users
    [HttpPost]
    public void Post([FromBody] User newUser)
    {
      // Set Dates
      newUser.CreatedAt = DateTime.Now;
      newUser.UpdatedAt = DateTime.Now;

      // Execute insert
      _context.Users.Add(newUser);
      _context.SaveChanges();

    }

    // PUT api/users/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] User updatedUser)
    {
      var entity = _context.Users.FirstOrDefault(user => user.Id == id);

      // If the user can be found
      if (entity != null)
      {
        // Update each field
        entity.Email = updatedUser.Email;
        entity.Password = updatedUser.Password;
        entity.UpdatedAt = DateTime.Now;

        // Execute and save the changes in the database
        _context.Users.Update(entity);
        _context.SaveChanges();
      }
    }

    // DELETE api/users/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var entity = _context.Users.FirstOrDefault(user => user.Id == id);

      if (entity != null)
      {
        _context.Users.Remove(entity);
        _context.SaveChanges();
      }
    }
  }
}