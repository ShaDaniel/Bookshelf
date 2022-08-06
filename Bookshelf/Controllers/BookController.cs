using System.Linq;
using System.Net;
using Bookshelf.Models;
using Bookshelf.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bookshelf.Controllers
{
    [ApiController]
    [Route("api/v1/bookshelf/")]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;
        private readonly IBookRepository repository;

        public BookController(ILogger<BookController> logger, IBookRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(JsonResult))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult Get(string id)
        {
            var description = repository.GetDescriptionById(id);
            if (description == null)
            {
                logger.LogWarning($"Queried by inexistent id: {id}");
                return NotFound();
            }

            logger.LogInformation($"Queried by id: {id}");
            return new JsonResult(BookJsonDocument.From(description));
        }

        [HttpGet]
        [ProducesResponseType((int) HttpStatusCode.OK, Type = typeof(JsonResult))]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public ActionResult Get(string author, string genre)
        {
            if (string.IsNullOrEmpty(author) == false)
            {
                logger.LogInformation($"Queried by author: {author}");
                var descriptions = repository.GetDescriptionsByAuthor(author);
                return new JsonResult(descriptions.Select(BookJsonDocument.From));
            }

            if (string.IsNullOrEmpty(genre) == false)
            {
                logger.LogInformation($"Queried by category: {genre}");
                var descriptions = repository.GetDescriptionsByGenre(genre);
                return new JsonResult(descriptions.Select(BookJsonDocument.From));
            }
            
            logger.LogWarning("Empty query");
            return NotFound();
        }
    };
}