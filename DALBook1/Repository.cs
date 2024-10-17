using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBook1
{
    public class Repository : IRepository
    {
        private BookContext _context;

        public Repository()
        {
            _context = new BookContext();
        }
        public List<BookDetails> ViewAllBooks()
        {
            return _context.BookDetails.ToList();
        }
        public bool AddBook(BookDetails book)
        {
            _context.BookDetails.Add(book);
            _context.SaveChanges();
            return true;
        }

        public BookDetails GetById(int id)
        {
            BookDetails book = _context.BookDetails.FirstOrDefault();
            return book;
        }

        public bool RemoveBook(int BookId)
        {
            BookDetails b= _context.BookDetails.Find(BookId);
            _context.BookDetails.Remove(b);
            _context.SaveChanges() ;
            return true;
        }

        
    }
}
