using System.Linq;
using System.Text.Json.Serialization;

namespace Bookshelf.Models
{
    public class BookJsonDocument
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
        
        [JsonPropertyName("authors")]
        public AuthorJsonDocument[] Authors { get; set; }
        
        [JsonPropertyName("language")]
        public string Lang { get; set; }
        
        [JsonPropertyName("publication_date")]
        public string PublicationDate { get; set; }
        
        [JsonPropertyName("pages")]
        public int Pages { get; set; }
        
        [JsonPropertyName("age_limit")]
        public int AgeLimit { get; set; }

        public static BookJsonDocument From(BookDbDocument dbDoc)
        {
            return new BookJsonDocument
            {
                Id = dbDoc.Id,
                Title = dbDoc.Title,
                Category = dbDoc.Category,
                Authors = dbDoc.Authors.Select(AuthorJsonDocument.From).ToArray(),
                Lang = dbDoc.Lang,
                PublicationDate = dbDoc.PublicationDate,
                Pages = dbDoc.Pages,
                AgeLimit = dbDoc.AgeLimit
            };
        }
    }
}
