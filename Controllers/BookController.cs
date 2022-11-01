using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookClub_app.DTOs.Book;
using BookClub_app.Services.BookService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClub_app.Controllers
{




    [Authorize]
    [ApiController]
    [Route("api/[controller]")]


    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> GetAll()
        {
            return Ok(await _bookService.GetAllBooks());
        }


        // GET api/Book
        //[AllowAnonymous]// no token required for access
        [HttpGet("GetAllbyUser")]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> Get()
        {


            return Ok(await _bookService.GetAllBooksbyUser());
        }

        // GET api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBookDto>>> GetaBook(int id)
        {
            return Ok(await _bookService.GetBookById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> AddBook(AddBookDto newbook)
        {
            // AllBooks.Add(newbook);
            return Ok(await _bookService.AddBook(newbook));

        }

        [HttpPut("updatebook")]
        public async Task<ActionResult<ServiceResponse<GetBookDto>>> UpdateBook(UpdateBookDto Updatebook)
        {
            // AllBooks.Add(newbook);
            var response = await _bookService.UpdateBook(Updatebook);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetBookDto>>>> DeleteBook(int id)
        {
            var response = await _bookService.DeleteBook(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}