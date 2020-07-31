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
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IActionResult Get()
        {
            var book = _bookService.GetAll().ToApiModels();
            return Ok(book);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookService.Get(id).ToApiModel();
            if (book == null) return NotFound();
            return Ok(book);
        }

        //Get api/<BooksController>/5
        [HttpGet("/api/series/{seriesid}/books")]
        public IActionResult GetBooksBySeries(int seriesId)
        {
            var book = _bookService.GetBooksBySeries(seriesId).ToApiModels();
            if (book == null) return NotFound();
            return Ok(book);
        }

        //Get api/<BooksController>/5
        [HttpGet("api/authors/{authorid}/books")]
        public IActionResult GetBooksByAuthor(int authorId)
        {
            var book = _bookService.GetBooksByAuthor(authorId).ToApiModels();
            if (book == null) NotFound();
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public IActionResult Post([FromBody] BookModel newBook)
        {
            var book = _bookService.Add(newBook.ToDomainModel());
            if (book == null) return BadRequest();
            return CreatedAtAction("Get", new { newBook.Id }, newBook);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookModel updatedBook)
        {
            var book = _bookService.Update(updatedBook.ToDomainModel());
            if (book == null) return BadRequest();
            return Ok(book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Remove(id);
            return NoContent();
        }
    }
}
