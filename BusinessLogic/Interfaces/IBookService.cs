using Model.Model;

namespace BusinessLogic.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAvailableBook();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void TakeBook(int id, int userId);
        void ReturnBook(int id);
    }
}
