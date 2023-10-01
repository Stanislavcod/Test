using Model.DataBaseContext;
using Model.Model;

namespace Model.Seed
{
    public class DataSeeder
    {
        private readonly ApplicationDataBaseContext _context;
        public DataSeeder(ApplicationDataBaseContext context)
        {
            _context = context;
        }
        public void Initialize()
        {
            SeedBooks();
            SeedUsers();
            SeedBookLoans();
            _context.SaveChanges();
        }
        public void SeedBooks()
        {
            if (!_context.Books.Any())
            {
                var books = new List<Book>
        {
            new Book { Name = "Евгений Онегин", Author = "Пушкин" },
            new Book { Name = "Война и мир", Author = "Толстой" },
            new Book { Name = "Преступление и наказание", Author = "Достоевский" },
            new Book { Name = "Капитанская дочка", Author = "Пушкин" }
        };
                _context.Books.AddRange(books);
                _context.SaveChanges();
            }
        }
        public void SeedUsers()
        {
            if (!_context.Users.Any())
            {
                var readers = new List<User>
                {
            new User { Name = "Иван", LastName = "Иванов" , MiddleName = "Иванович"},
            new User { Name = "Петр", LastName = "Петров", MiddleName= "Петрович" },
            new User { Name = "Анна", LastName = "Сидорова", MiddleName = "Сидоровна" }
        };
                _context.Users.AddRange(readers);
                _context.SaveChanges();
            }
        }
        public void SeedBookLoans()
        {
            if (!_context.BookLoans.Any())
            {
                var bookLoans = new List<BookLoan>
        {
            new BookLoan { BookId = 1, UserId = 1, LoanDate = DateTime.Now },
            new BookLoan { BookId = 2, UserId = 2, LoanDate = DateTime.Now },
            new BookLoan { BookId = 3, UserId = 3, LoanDate = DateTime.Now }
        };
                _context.BookLoans.AddRange(bookLoans);
                _context.SaveChanges();
            }
        }
    }
}
