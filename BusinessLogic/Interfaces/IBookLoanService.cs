using Model.Model;

namespace BusinessLogic.Interfaces
{
    public interface IBookLoanService
    {
        void Create(BookLoan bookLoan);
        IEnumerable<BookLoan> GetAllBookLoans();
        IEnumerable<Book> GetBorrowerBookLoans(int userId);
        void Update(int bookId);
    }
}
