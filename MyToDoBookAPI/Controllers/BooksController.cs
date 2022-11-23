﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDoBookAPI.Model.Models;
using Repository;
using System.Threading.Tasks;

namespace MyToDoBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBooks([FromBody]BookModel bookModel)
        {
            var id = await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new {id = id, controller = "books"}, id);
        }


        [HttpPut("")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromQuery] int id)
        {
             await _bookRepository.UpdateBookAsync(id,bookModel);
            return Ok();
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteBook( [FromQuery] int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
    }
}
