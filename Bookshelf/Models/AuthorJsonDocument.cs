using System.Text.Json.Serialization;

namespace Bookshelf.Models
{
    public class AuthorJsonDocument
    {
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("language")]
        public string Lang { get; set; }

        public static AuthorJsonDocument From(AuthorDbDocument dbDoc)
        {
            return new AuthorJsonDocument
            {
                Name = dbDoc.Name,
                Lang = dbDoc.Lang
            };
        }
    }
}
