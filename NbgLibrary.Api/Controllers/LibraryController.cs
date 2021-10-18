using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbgLibrary.Entities;
using NbgLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbgLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> logger;
        private readonly IBookService bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            this.logger = logger;
            this.bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            logger.LogInformation("GetBooks");
            return await bookService.GetAllBooksAsync();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<Book> GetBook(int id)
        {
            logger.LogInformation($"GetBook id= {id}");
            return await bookService.GetBookAsync(id);
        }


    }
}
