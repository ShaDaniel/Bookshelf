using System.Text.Json.Serialization;

namespace Bookshelf.Models
{
    public class BookDbDocument
    {
        
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("category")]
        public string Category { get; set; }
        
        [JsonPropertyName("authors")]
        public AuthorDbDocument[] Authors { get; set; }
        
        [JsonPropertyName("lang")]
        public string Lang { get; set; }
        
        [JsonPropertyName("publicationDate")]
        public string PublicationDate { get; set; }
        
        [JsonPropertyName("pages")]
        public int Pages { get; set; }
        
        [JsonPropertyName("ageLimit")]
        public int AgeLimit { get; set; }
    }
}
