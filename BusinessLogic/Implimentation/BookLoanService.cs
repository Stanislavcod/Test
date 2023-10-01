using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using Model.Model;

namespace BusinessLogic.Implimentation
{
    public class BookLoanService : IBookLoanService
    {
        private readonly ApplicationDataBaseContext _context;

        public BookLoanService(ApplicationDataBaseContext context)
        {
            _context = context;
        }

        public void Create(BookLoan bookLoan)
        {
            _context.Add(bookLoan);

            _context.SaveChanges();
        }

        public IEnumerable<BookLoan> GetAllBookLoans()
        {
            return _context.BookLoans.Include(x => x.User).Include(x => x.Book).ToList();
        }
        public IEnumerable<Book> GetBorrowerBookLoans(int userId)
        {
            var bookLoans = _context.BookLoans.Include(x => x.Book)
          .Where(x => x.UserId == userId && x.Book.IsAvailable == false)
          .Select(x => x.Book)
          .ToList();

            return bookLoans;
        }
        public void Update(int bookId)
        {
            var bookLoan = _context.BookLoans.FirstOrDefault(x => x.BookId == bookId);
            bookLoan.ReturnDate = DateTime.Now;
            _context.Update(bookLoan);
            _context.SaveChanges();

        }
    }
}
