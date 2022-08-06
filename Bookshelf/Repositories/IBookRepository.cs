using System.Collections.Generic;
using Bookshelf.Models;

namespace Bookshelf.Repositories
{
    public interface IBookRepository
    {
        BookDbDocument GetDescriptionById(string id);

        IEnumerable<BookDbDocument> GetDescriptionsByAuthor(string author);

        IEnumerable<BookDbDocument> GetDescriptionsByGenre(string category);
    }
}
