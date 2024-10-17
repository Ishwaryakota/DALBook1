using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBook1
{
    public interface IRepository
    {
        public List<BookDetails> ViewAllBooks();
        public BookDetails GetById(int id);
        public bool AddBook(BookDetails book);
        public bool RemoveBook(int BookId);
    }
}
