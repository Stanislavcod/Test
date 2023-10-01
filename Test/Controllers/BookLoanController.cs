using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace Test.Controllers
{
    public class BookLoanController : Controller
    {
        private readonly IBookLoanService _bookLoanService;

        public BookLoanController(IBookLoanService bookLoanService)
        {
            _bookLoanService = bookLoanService;
        }

        public IActionResult Accounting()
        {
            var loans = _bookLoanService.GetAllBookLoans();
            return View(loans);
        }
    }
}
