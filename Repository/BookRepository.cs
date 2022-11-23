using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyToDoBookAPI.Model.Data;
using MyToDoBookAPI.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ToDoBookContext _context;
        private readonly IMapper _mapper;

        public BookRepository(ToDoBookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await _context.Books.Select(x =>new BookModel()
            {
                Id = x.Id,
                Book = x.Book,
                Description = x.Description,
            }).ToListAsync();

            return records;

            //var records = await _context.Books.ToListAsync();
            //return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var records = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Book = x.Book,
                Description = x.Description,
            }).FirstOrDefaultAsync();

            return records;

            //var book = await _context.Books.FirstAsync(book);
            //return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Book = bookModel.Book,
                Description = bookModel.Description
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(bookId);
            //if(book != null)
            //{
            //    book.Book = bookModel.Book;
            //    book.Description = bookModel.Description;

            //    await _context.SaveChangesAsync();
            //}

            var book = new Books()
            {
                Id=bookId,
                Book = bookModel.Book,
                Description = bookModel.Description
            };
             _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books() { Id = bookId};
           
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            
        }
    }
}
