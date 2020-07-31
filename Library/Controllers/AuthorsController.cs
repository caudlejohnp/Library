using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.ApiModels;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {

        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public IActionResult Get()
        {
            var author = _authorService.GetAll().ToApiModel();
            return Ok(author);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _authorService.Get(id).ToApiModel();
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthorModel newAuthor)
        {
            var author = _authorService.Add(newAuthor.ToDomainModel());
            if (author == null) return BadRequest();
            return CreatedAtAction("Get", new { newAuthor.Id }, newAuthor);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] AuthorModel updatedAuthor)
        {
            var author = _authorService.Update(updatedAuthor.ToDomainModel());
            if (author == null) return BadRequest();
            return Ok(author);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.Remove(id);
            return NoContent();
        }
    }
}
