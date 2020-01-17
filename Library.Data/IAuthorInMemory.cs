using Library.Core;
using System.Collections.Generic;

namespace Library.Data
{
    public interface IAuthorInMemory
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthor(int Id);
        Author Update(Author author);
        Author Create(Author author);
    } 
}
