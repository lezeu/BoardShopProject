/*
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppShop.Model;

namespace WebAppShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ProductContext _context;

        public LogInController(ProductContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new LogIn
                {
                    UserName = "admin",
                    Password = "admin",
                    Email = "admin@admin.ro",
                    Role = 1,
                });
            }

        }


        [HttpGet]
        public IEnumerable GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult<LogIn>> GetLogIn(long id)
        {
            var logIn = await _context.Users.FindAsync(id);

            if (logIn == null)
            {
                return (IActionResult<LogIn>)NotFound();
            }

            return (IActionResult<LogIn>)logIn;
        }
    

        [HttpPost]
        public async Task<ActionResult<LogIn>> PostSingUp(LogIn logIn)
        {
            _context.Users.Add(logIn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogIn", new { id = logIn.Id }, logIn);
        }

        [HttpPost]
        [Route("/{username}/{password}")]
        public IActionResult Login([FromRoute] String username, [FromRoute] String password)
        {
            LogIn logIn = _context.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            if(logIn == null)
            {
                return NotFound();
            }
            return Ok(logIn);
        }

        [HttpPut]
        public void Update([FromBody] LogIn item)
        {

            _context.Users.Update(item);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSingUp(long id, LogIn logIn)
        {
            if (id != logIn.Id)
            {
                return BadRequest();
            }

            _context.Entry(logIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogInExists(id))
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
        private bool LogInExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var prod = _context.Users.FirstOrDefault(t => t.Id == id);
            if (prod == null)
            {
                return NotFound();
            }

            _context.Users.Remove(prod);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppShop.Model;

namespace WebAppShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly ProductContext _context;

        public LogInController(ProductContext context)
        {
            _context = context;
            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new LogIn
                {
                    UserName = "admin",
                    Password = "admin",
                    Email = "admin@admin.ro",
                    Role = 1,
                });
            }
        }

        // GET: api/SingUps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogIn>>> GetSingUp()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/SingUps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogIn>> GetSingUp(int id)
        {
            var singUp = await _context.Users.FindAsync(id);

            if (singUp == null)
            {
                return NotFound();
            }

            return singUp;
        }

        // PUT: api/SingUps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSingUp(int id, LogIn logIn)
        {
            if (id != logIn.Id)
            {
                return BadRequest();
            }

            _context.Entry(logIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SingUpExists(id))
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

        // POST: api/SingUps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogIn>> PostSingUp(LogIn logIn)
        {
            _context.Users.Add(logIn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSingUp", new { id = logIn.Id }, logIn);
        }

        // DELETE: api/SingUps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSingUp(int id)
        {
            var singUp = await _context.Users.FindAsync(id);
            if (singUp == null)
            {
                return NotFound();
            }

            _context.Users.Remove(singUp);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost]
        [Route("{username}/{password}")]
        public IActionResult Login([FromRoute] String username, [FromRoute] String password)
        {
            LogIn logIn = _context.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

            if (logIn == null)
            {
                return NotFound();
            }

            return Ok(logIn);
        }


        private bool SingUpExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}