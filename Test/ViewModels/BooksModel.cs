using Model.Model;

namespace Test.ViewModels
{
    public class BooksModel
    {
        public IEnumerable<Book> AvailableBooks { get; set; }
        public IEnumerable<Book> BorrowerBooks { get; set; }
    }
}
