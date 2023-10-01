using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Model.Model;

namespace BusinessLogic.Implimentation
{
    public class BookService : IBookService
    {
        private readonly IBookLoanService _bookLoanService;
        private readonly ApplicationDataBaseContext _context;

        public BookService(ApplicationDataBaseContext context, IBookLoanService bookLoanService)
        {
            _context = context;
            _bookLoanService = bookLoanService;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            var existBook = _context.Books.FirstOrDefault(x => x.Id == id);
            return existBook;
        }

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void TakeBook(int id, int userId)
        {
            var existBook = _context.Books.Include(x => x.BookLoans).FirstOrDefault(x => x.Id == id);
            if (existBook != null && existBook.IsAvailable == true)
            {
                _bookLoanService.Create(new BookLoan { BookId = id, UserId = userId, LoanDate = DateTime.Now });
                existBook.IsAvailable = false;
                _context.SaveChanges();

            }
            else
            {
                throw new Exception("Данная книга отсутсвует");
            }

        }
        public void ReturnBook(int id)
        {
            var existBook = _context.Books.FirstOrDefault(x => x.Id == id);
            if (existBook != null)
            {
                existBook.IsAvailable = true;
                _bookLoanService.Update(id);
            }
            else
            {
                throw new Exception("У вас нет такой книги");
            }
            _context.SaveChanges();
        }
        public IEnumerable<Book> GetAvailableBook()
        {
            var books = _context.Books.Where(x => x.IsAvailable == true).ToList();

            return books;
        }

    }
}
