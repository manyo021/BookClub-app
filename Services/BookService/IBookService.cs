using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookClub_app.DTOs.Book;

namespace BookClub_app.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<List<GetBookDto>>> GetAllBooksbyUser();



        Task<ServiceResponse<List<GetBookDto>>> GetAllBooks();

        Task<ServiceResponse<GetBookDto>> GetBookById(int id);

        Task<ServiceResponse<List<GetBookDto>>> AddBook(AddBookDto newBook);

        Task<ServiceResponse<GetBookDto>> UpdateBook(UpdateBookDto UpdatedBook);

        Task<ServiceResponse<List<GetBookDto>>> DeleteBook(int id);


    }
}