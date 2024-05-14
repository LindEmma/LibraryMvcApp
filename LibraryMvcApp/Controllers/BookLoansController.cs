using LibraryMvcApp.Data;
using LibraryMvcApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryMvcApp.Controllers
{
    [Authorize]
    public class BookLoansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookLoansController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET:
        public async Task<IActionResult> AllLoans() //shows all loans
        {
            var allLoans = await _context.BookLoans
                .Include(b => b.Book)
                .Include(c => c.Customer)
                 .OrderBy(c => c.LoanDate)
                 .ToListAsync();

            if (allLoans == null)
            {
                return NotFound(allLoans);
            }
            else
            {
                return View(allLoans);
            }
        }

        //GET:
        [Authorize]
        public async Task<IActionResult> MyLoans() //shows the logged in users loans
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var myLoans = await _context.BookLoans
                                      .Include(bl => bl.Book)
                                      .Where(b => b.CustomerId == userId)
                                      .ToListAsync();
            return View(myLoans);
        }

        //[HttpGet]
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int bookId) //creates book loan
        {
            //creates new book loan for logged in user
            var bookLoan = new BookLoan
            {
                BookId = bookId,
                CustomerId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                LoanDate = DateTime.Now,
                LastLoanDate = DateTime.Now.AddDays(30),
                LoanStatus = LoanStatus.Utlånad
            };
            var book = await _context.Books.FindAsync(bookId);

            if (book != null) //changes the books stock info when a loan is made
            {
                book.InStock = false;
            }

            _context.BookLoans.Add(bookLoan);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(int id) //adds a return date to book loan
        {
            var bookLoan = await _context.BookLoans.FindAsync(id);

            if (bookLoan == null)
            {
                return NotFound();
            }

            bookLoan.ReturnDate = DateTime.Now;

            bookLoan.UpdateLoanStatus();

            var book = await _context.Books.FindAsync(bookLoan.BookId);
            if (book != null) // book is now in stock!
            {
                book.InStock = true;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MyLoans));
        }
    }
}
