
using AutoMapper;
using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Models.DTO.BookDTOs;
using BookLibrary.Domain.Services.InfrastructureServices;
using BookLibrary.Infrastructure.Data.DatabaseContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookLibraryGenericQuery<Book> _bookQueryCommand;
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;

        public BookController(IBookLibraryGenericQuery<Book> bookQueryCommand, ILogger<BookController> logger, IMapper mapper)
        {
            _bookQueryCommand = bookQueryCommand;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Books.
        /// </summary>
        ///<response code="200">Returned all books or empty array</response>
        ///
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]

        //public async Task<ActionResult> GetAllBooksAsync([FromQuery] RequestParams requestParams)
        //{
        //    var books = await _bookQueryCommand.GetAllAsync(requestParams);
        //    var bookLists = _mapper.Map<IList<BookResponseDTO>>(books).Where(f => f.IsFavorite == true);
        //    return Ok(bookLists);
        //}

        /// <summary>
        /// Get Book by id
        /// </summary>
        ///<response code="200">Returned single book or empty array</response>
        ///
        [HttpGet("{id:int}", Name = "GetBookAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookAsync(int id)
        {
            if (id != 0)
            {
                var book = await _bookQueryCommand.GetByIdAsync(id);
                if (book == null)
                {
                    _logger.LogError($"Invalid GET attemp in {nameof(GetBookAsync)}");
                    return NotFound();
                }
                var results = _mapper.Map<BookResponseDTO>(book);
                return Ok(results);
            }
            return BadRequest();
        }

        /// <summary>
        /// Add a new Book.
        /// </summary>
        ///<response code="201">Returned for book added successfuly</response>
        ///
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddNewBookToBookLibraryAsync([FromBody] BookRequestDTO bookDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(AddNewBookToBookLibraryAsync)}");
                return BadRequest(ModelState);
            }

            var book = _mapper.Map<Book>(bookDto);
            await _bookQueryCommand.AddAsync(book);

            return CreatedAtRoute("GetBookAsync", new { id = book.Id }, book);
        }

        /// <summary>
        /// Edit an existing book.
        /// </summary>
        ///<response code="204">Returned when book is edited successfully</response>
        ///<response code="400">Returned when id in request route doesnt match request body</response>
        ///<response code="404">Returned when book does not exist</response>
        ///
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditBookAsync(int id, [FromBody] BookRequestDTO bookDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(EditBookAsync)}");
                return BadRequest(ModelState);
            }

            var book = await _bookQueryCommand.GetByIdAsync(id);
            if (book == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(EditBookAsync)}");
                return BadRequest(ModelState);
            }

            _mapper.Map(bookDto, book);
            await _bookQueryCommand.UpdateAsync(book);
            return NoContent();
        }

        /// <summary>
        /// Delete an existing book.
        /// </summary>
        ///<response code="204">Returned when book is deleted successfully</response>
        ///<response code="404">Returned when book is not found</response>
        ///
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteBookAsync)}");
                return NotFound();
            }

            var book = await _bookQueryCommand.GetByIdAsync(id);
            if (book == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteBookAsync)}");
                return NotFound("Invalid Data");
            }
            await _bookQueryCommand.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Get list of favorite Books.
        /// </summary>
        ///<response code="200">Returned all favorite books or empty array</response>
        //[HttpGet("favorite")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetFavoriteBooksAsync([FromQuery] RequestParams requestParams)
        //{
        //    var books = await _bookQueryCommand.GetAllAsync(requestParams);
        //    var favoriteBookList = _mapper.Map<IList<BookResponseDTO>>(books).Where(f => f.IsFavorite == true);
        //    return Ok(favoriteBookList);
        //}
    }
}
