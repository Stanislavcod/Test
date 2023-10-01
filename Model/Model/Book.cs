namespace Model.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public string Author { get; set; } = string.Empty;
        public int? BorrowerUserId { get; set; }
        public User? Borrower { get; set; }
        public List<BookLoan>? BookLoans { get; set; }
    }
}
