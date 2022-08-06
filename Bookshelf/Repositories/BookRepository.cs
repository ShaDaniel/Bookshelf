using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Bookshelf.Models;
using Microsoft.Extensions.Configuration;

namespace Bookshelf.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Dictionary<string, BookDbDocument> collection;
        public BookRepository(IConfiguration config)
        {
            var dbFileName = config["ConnectionStrings:DbFile"];
            var fileDbData = File.ReadAllText(dbFileName);
            var deserializedData = JsonSerializer.Deserialize<IEnumerable<BookDbDocument>>(fileDbData);

            collection = deserializedData.ToDictionary(x => x.Id, x => x);
        }

        public BookDbDocument GetDescriptionById(string id)
        {
            if (collection.TryGetValue(id, out var res))
            {
                return res;
            }

            return null;
        }
        public IEnumerable<BookDbDocument> GetDescriptionsByAuthor(string author)
        {
            var res = collection
                .Where(x => x.Value.Authors
                    .Any(a => a.Name == author))
                .Select(x => x.Value);

            return res;
        }
        
        public IEnumerable<BookDbDocument> GetDescriptionsByGenre(string category)
        {
            var res = collection
                .Where(x => x.Value.Category == category)
                .Select(x => x.Value);

            return res;
        }
    }
}
