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
        public async Task<IActionResult> AllLoans()
        {
            var allLoans = await _context.BookLoans
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
        public async Task<IActionResult> MyLoans()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Hämta användarens ID
            var myLoans = await _context.BookLoans
                                      .Include(bl => bl.Book) // Inkludera Book-egenskapen
                                      .Where(b => b.CustomerId == userId)
                                      .ToListAsync(); // Filtrera boklån för den aktuella användaren
            return View(myLoans);
        }
        //[HttpGet]
        public IActionResult Create()
        {
            //// Kolla om ViewBag redan innehåller bokdata
            //if (ViewBag.Books == null)
            //{
            //    // Hämta en lista över alla böcker och fyll ViewBag med dem
            //    var books = _context.Books.ToList();
            //    ViewBag.Books = books;
            //}

            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int bookId, BookLoan bookLoan)
        {
            if (ModelState.IsValid)
            {
                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);

                if (book == null)
                {
                    return NotFound();
                }

                //Sätt egenskaper för BookLoan-objektet
                bookLoan.BookId = bookId;
                //bookLoan.CustomerId = userId;
                //bookLoan.LoanDate = DateTime.Now;
                //bookLoan.LastLoanDate = DateTime.Now.AddDays(30); // Exempelvis 30 dagar från utlåningsdatumet

                // Lägg till och spara i databasen
                _context.Add(bookLoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyLoans));

            }

            //if (ViewBag.Books == null)
            //{
            //    var books = _context.Books.ToList();
            //    ViewBag.Books = books;
            //}

            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookName");
            return View(bookLoan);
        }
    }
}
