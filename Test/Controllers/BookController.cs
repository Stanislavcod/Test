using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Model;
using System.Security.Claims;
using Test.ViewModels;

namespace Test.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBookLoanService _bookLoanService;
        public BookController(IBookService bookService, IBookLoanService bookLoanService)
        {
            _bookService = bookService;
            _bookLoanService = bookLoanService;
        }
        public IActionResult Storage()
        {
            var books = _bookService.GetAllBooks();

            return View(books);
        }
        public IActionResult Books()
        {
            var books = _bookService.GetAllBooks();

            return View(books);
        }
        public IActionResult AvailableBook()
        {
            int userId = GetUserIdClaim();

            var availableBooks = _bookService.GetAvailableBook();
            var borrowerBooks = _bookLoanService.GetBorrowerBookLoans(userId);

            var booksModel = new BooksModel
            {
                AvailableBooks = availableBooks,
                BorrowerBooks = borrowerBooks
            };

            return View("Books", booksModel);
        }
        public IActionResult CreateBook()
        {
            return View("CreateBook");
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.CreateBook(book);
                return RedirectToAction("AvailableBook", "Book");
            }
            return View("CreateBook", book);
        }
        public IActionResult TakeBook(int id)
        {
            try
            {
                int userId = GetUserIdClaim();

                _bookService.TakeBook(id, userId);

                return RedirectToAction("AvailableBook", "Book");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "Данная книга отсутсвует";
                return View("Error");
            }
        }
        public IActionResult ReturnBook(int id)
        {
            try
            {
                _bookService.ReturnBook(id);
                return RedirectToAction("AvailableBook", "Book");
            }
            catch (Exception)
            {
                ViewData["ErrorMessage"] = "У вас нет такой книги";
                return View("Error");
            }
        }
        private int GetUserIdClaim()
        {
            ClaimsPrincipal currentUser = this.User;

            Claim userIdClaim = currentUser.FindFirst(ClaimTypes.NameIdentifier);

            int userId = int.Parse(userIdClaim.Value);

            return userId;
        }
    }
}
