using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Diagnostics;

namespace WebApplication1.Controllers
{

    [Route("api")]
    public class ServiceApiController : Controller
    {
        static readonly object setupLock = new object();
        static readonly SemaphoreSlim parallelism = new SemaphoreSlim(2);

        [HttpGet("setup")]
        public IActionResult SetupDatabase()
        {
            lock (setupLock)
            {
                using (var context = new AppDbContext())
                {
                    // Create database
                    context.Database.EnsureCreated();
                }
                return Ok("database created");
            }
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                await parallelism.WaitAsync();

                using (var context = new AppDbContext())
                {
                    
                    return Ok(context.Users.ToList());
                }
            }
            finally
            {
                parallelism.Release();
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser([FromQuery]int id)
        {
            using (var context = new AppDbContext())
            {
                return Ok(await context.Users.FirstOrDefaultAsync(x => x.Id == id));
            }
        }

        [HttpPut("users")]
        public async Task<IActionResult> CreateUser([FromBody]User user)
        {
            
            using (var context = new AppDbContext())
            {
               
                context.Users.Add(user);

                await context.SaveChangesAsync();

                return Ok();
            }
        }

        [HttpPost("users")]
        public async Task<IActionResult> UpdateUser([FromBody]User user)
        { 
            using (var context = new AppDbContext())
            {
                
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return Ok();
            }
        }


        [HttpDelete("users")]
        public async Task<IActionResult> DeleteUser([FromQuery]int id)
        {
            using (var context = new AppDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpGet("concerts")]
        public async Task<IActionResult> GetConcerts()
        {
            try
            {
                await parallelism.WaitAsync();

                using (var context = new AppDbContext())
                {
                    return Ok(context.Concerts.ToList());
                }
            }
            finally
            {
                parallelism.Release();
            }
        }

        [HttpGet("concert")]
        public async Task<IActionResult> GetConcert([FromQuery]int id)
        {
            using (var context = new AppDbContext())
            {
                return Ok(await context.Concerts.FirstOrDefaultAsync(x => x.Id == id));
            }
        }

        [HttpPut("concerts")]
        public async Task<IActionResult> CreateConcert([FromBody]Concert concert)
        {
            using (var context = new AppDbContext())
            {
                context.Concerts.Add(concert);

                await context.SaveChangesAsync();

                return Ok();
            }
        }

        [HttpPost("concerts")]
        public async Task<IActionResult> UpdateConcert([FromBody]Concert concert)
        {
            using (var context = new AppDbContext())
            {
                context.Concerts.Update(concert);
                await context.SaveChangesAsync();
                return Ok();
            }
        }


        [HttpDelete("concerts")]
        public async Task<IActionResult> DeleteConcert([FromQuery]int id)
        {
            using (var context = new AppDbContext())
            {
                var concert = await context.Concerts.FirstOrDefaultAsync(x => x.Id == id);
                context.Concerts.Remove(concert);
                await context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}