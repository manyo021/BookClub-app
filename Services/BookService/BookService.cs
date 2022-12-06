using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BookClub_app.Data;
using BookClub_app.DTOs.Book;
using Microsoft.EntityFrameworkCore;

namespace BookClub_app.Services.BookService
{
    public class BookService : IBookService
    {


        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccess;

        public BookService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccess)
        {
            _context = context;
            _httpContextAccess = httpContextAccess;
            _mapper = mapper;
        }


        private int GetUserId() => int.Parse(_httpContextAccess.HttpContext.User
        .FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<List<GetBookDto>>> AddBook(AddBookDto newBook)
        {
            var serviceResponse = new ServiceResponse<List<GetBookDto>>();
            Books book = _mapper.Map<Books>(newBook);
            book.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            _context.AllBooks.Add(book);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.AllBooks
            .Where(c => c.User.Id == GetUserId())
            .Select(b => _mapper.Map<GetBookDto>(b))
            .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookDto>>> DeleteBook(int id)
        {
            ServiceResponse<List<GetBookDto>> response = new ServiceResponse<List<GetBookDto>>();
            try
            {
                Books book = await _context.AllBooks
                .FirstOrDefaultAsync(b => b.Id == id && b.User.Id == GetUserId());
                if (book != null)
                {
                    _context.AllBooks.Remove(book);
                    await _context.SaveChangesAsync();
                    response.Data = _context.AllBooks
                    .Where(b => b.User.Id == GetUserId())
                    .Select(b => _mapper.Map<GetBookDto>(b)).ToList();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Book not found";
                }




            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;

        }

        // Use this to get all books without userID
        public async Task<ServiceResponse<List<GetBookDto>>> GetAllBooks()
        {
            var response = new ServiceResponse<List<GetBookDto>>();//Initializing the response for the user
            var dbBooks = await _context.AllBooks.ToListAsync();//assigning dbBooks to the database
            response.Data = dbBooks.Select(b => _mapper.Map<GetBookDto>(b)).ToList();//assigning response to Data

            return response; //Returning Data with response
        }
        public async Task<ServiceResponse<List<GetBookDto>>> GetAllBooksbyUser()
        {
            var response = new ServiceResponse<List<GetBookDto>>();//Initializing the response for the user
            var dbBooks = await _context.AllBooks
            .Where(c => c.User.Id == GetUserId())
            .ToListAsync();//assigning dbBooks to the database
            response.Data = dbBooks.Select(b => _mapper.Map<GetBookDto>(b)).ToList();//assigning response to Data

            return response; //Returning Data with response
        }

        public async Task<ServiceResponse<GetBookDto>> GetBookById(int id)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            var dbbook = await _context.AllBooks
            .FirstOrDefaultAsync(b => b.Id == id && b.User.Id == GetUserId());
            serviceResponse.Data = _mapper.Map<GetBookDto>(dbbook);
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetBookDto>> UpdateBook(UpdateBookDto UpdatedBook)
        {

            ServiceResponse<GetBookDto> response = new ServiceResponse<GetBookDto>();
            try
            {
                var book = await _context.AllBooks
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.Id == UpdatedBook.Id);

                if (book.User.Id == GetUserId())
                {
                    book.Title = UpdatedBook.Title;
                    book.Author = UpdatedBook.Author;
                    book.Description = UpdatedBook.Description;
                    book.Rating = UpdatedBook.Rating;
                    book.Genres = UpdatedBook.Genres;

                    await _context.SaveChangesAsync();
                    response.Data = _mapper.Map<GetBookDto>(book);
                    response.Message = "Character saved successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Book not found";
                }



            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }
            return response;

        }
    }
}