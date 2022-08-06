using System.Text.Json.Serialization;

namespace Bookshelf.Models
{
    public class AuthorDbDocument
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("lang")]
        public string Lang { get; set; }
    }
}
