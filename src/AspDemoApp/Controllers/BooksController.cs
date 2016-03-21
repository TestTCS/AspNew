using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using AspDemoApp.DB;
using AspDemoApp.Models;

namespace AspDemoApp.Controllers
{
    public class BooksController : Controller
    {
        private MyDbContext _context;

        public BooksController()
        {
           // _context = ;    
        }

        // GET: Books
        public ActionResult Index()
        {
            var myDbContext = new SampleData().GetsBooks();
                return View(myDbContext);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = await _context.Books.SingleAsync(m => m.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Author");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Author", book.AuthorID);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = await _context.Books.SingleAsync(m => m.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Author", book.AuthorID);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["AuthorID"] = new SelectList(_context.Authors, "AuthorID", "Author", book.AuthorID);
            return View(book);
        }

        // GET: Books/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = await _context.Books.SingleAsync(m => m.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Book book = await _context.Books.SingleAsync(m => m.BookID == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
