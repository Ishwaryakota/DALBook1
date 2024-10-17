using DALBook1;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using MVCBook1.Models;

namespace MVCBook1.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepository _repository;

        public List<BookDetails> dalBooks {  get; set; }

        public List<BookInfo> mvcBooks { get; set; }

        public BookController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Display()
        {
            List <BookInfo>mvcBooks = new List<BookInfo>();
            dalBooks = _repository.ViewAllBooks();
            foreach(var book in dalBooks)
            {
                BookInfo bookInfo = new BookInfo();
                bookInfo.Id = book.Id;
                bookInfo.BookName = book.BookName;
                bookInfo.Genre = book.Genre;
                bookInfo.AvailabilityStatus = book.AvailabilityStatus;
                mvcBooks.Add(bookInfo);
            }
            return View(mvcBooks);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookInfo book)
        {
            BookDetails b= new BookDetails();
            b.Id = book.Id;
            b.BookName = book.BookName;
            b.Genre = book.Genre;
            b.AvailabilityStatus = book.AvailabilityStatus;
            _repository.AddBook(b);
            return RedirectToAction("Display");

        }
        public IActionResult Delete(int BookId)
        {
            BookDetails book=_repository.GetById(BookId);
            BookInfo bookInfo = new BookInfo();
            bookInfo.Id = book.Id;
            bookInfo.BookName= book.BookName;
            bookInfo.Genre=book.Genre;
            book.AvailabilityStatus = book.AvailabilityStatus;
            return View(bookInfo);

           
        }
        [HttpPost]
        public IActionResult Delete(BookInfo book)
        {
            BookDetails b= new BookDetails();
            b.Id = book.Id;
            b.BookName = book.BookName;
            b.Genre = book.Genre;
            b.AvailabilityStatus = book.AvailabilityStatus;
            _repository.RemoveBook(b.Id);
            return RedirectToAction("Display");
        }
    }
}
