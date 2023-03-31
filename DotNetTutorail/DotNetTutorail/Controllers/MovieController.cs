using DotNetTutorail.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DotNetTutorail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _movieContext;
        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        /*Get All Movies*/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovie()
        {
            if (_movieContext == null)
            {
                return NotFound();
            }
            return await _movieContext.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetOneMovie(int id)
        {
            if (_movieContext == null)
            {
                return NotFound();
            }
            var getMovieById = await _movieContext.Movies.FindAsync(id);
            if (getMovieById == null)
            {
                return NotFound();
            }
            return getMovieById;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            Console.WriteLine(movie);
            _movieContext.Movies.Add(movie);
            
            await _movieContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOneMovie), new { id = movie.Id }, movie);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(Movie movie,int id)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            _movieContext.Entry(movie).State=EntityState.Modified;
            try
            {
                await _movieContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                if (!MovieExists(id))
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
        private bool MovieExists(int id)
        {
            return (_movieContext.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_movieContext.Movies == null)
            {
                return NotFound();
            }
            var movie = await _movieContext.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            _movieContext.Remove(movie);
            await _movieContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
