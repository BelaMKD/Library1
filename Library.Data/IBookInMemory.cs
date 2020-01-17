using Library.Core;
using System.Collections.Generic;

namespace Library.Data
{
    public interface IBookInMemory
    {
        IEnumerable<Book> GetBooks(string title = null, string author = null);
        Book GetBook(int Id);
        Book Update(Book book);
        int Commit();
        Book Create(Book book);
    }
}
