
using LibraryManagementAPI.Data;
using LibraryManagementAPI.Data.Repository;
using LibraryManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryApp : ControllerBase
    {
        private readonly ILibraryRepository<Author> _authorRepository;
        private readonly ILibraryRepository<Book> _bookRepository;

        public LibraryApp(
            ILibraryRepository<Author> authorRepository,
            ILibraryRepository<Book> bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }


        [HttpGet("Authors/all")]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAll();
            return Ok(authors);
        }

        [HttpGet("Authors/{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var author = await _authorRepository.GetById(id);

            if (author == null)
            {
                return NotFound($"Author with ID {id} not found");
            }

            return Ok(author);
        }

        [HttpGet("Authors/Name/{name}")]
        public async Task<ActionResult<Author>> GetAuthorByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty");
            }

            var author = await _authorRepository.GetByName(name);

            if (author == null)
            {
                return NotFound($"Author with name '{name}' not found");
            }

            return Ok(author);
        }


        [HttpPost("Authors/Create")]
        public async Task<ActionResult<int>> CreateAuthor([FromBody] AuthorDTO authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest("Author cannot be null");
            }

            var author = new Author
            {
                Name = authorDto.Name,
                Country = authorDto.Country
            };

            var result = await _authorRepository.Create(author);
            return Ok(new { message = "Author created successfully", id = result });
        }

        [HttpPut("Authors/update")]
        public async Task<ActionResult<int>> UpdateAuthor(int id, [FromBody] AuthorDTO authorDto)
        {
            if (authorDto == null)
            {
                return BadRequest("Author cannot be null");
            }

            var existingAuthor = await _authorRepository.GetById(id);
            if (existingAuthor == null)
            {
                return NotFound($"Author with ID {id} not found");
            }

            existingAuthor.Name = authorDto.Name;
            existingAuthor.Country = authorDto.Country;

            var result = await _authorRepository.Update(id, existingAuthor);
            return Ok(new { message = "Author updated successfully", id = result });
        }

        [HttpDelete("Authors/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteAuthor(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _authorRepository.Delete(id);

            if (!result)
            {
                return NotFound($"Author with ID {id} not found");
            }

            return Ok(new { message = "Author deleted successfully", success = true });
        }


        [HttpGet("Books/all")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books = await _bookRepository.GetAll();
            return Ok(books);
        }

        [HttpGet("Books/{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var course = await _bookRepository.GetById(id);

            if (course == null)
            {
                return NotFound($"Book with ID {id} not found");
            }

            return Ok(course);
        }

        [HttpGet("Books/Name/{name}")]
        public async Task<ActionResult<Book>> GetBookByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty");
            }

            var book = await _bookRepository.GetByName(name);

            if (book == null)
            {
                return NotFound($"Book with name '{name}' not found");
            }

            return Ok(book);
        }


        [HttpPost("Books/Create")]
        public async Task<ActionResult<int>> CreateCourse([FromBody] BookDTO bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Book cannot be null");
            }

            var authorExists = await _authorRepository.GetById(bookDto.AuthorId);
            if (authorExists == null)
            {
                return BadRequest($"Author with ID {bookDto.AuthorId} does not exist");
            }


            var book = new Book
            {
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                AuthorId = bookDto.AuthorId
            };

            var result = await _bookRepository.Create(book);
            return Ok(new { message = "Book created successfully", id = result });
        }

        [HttpPut("Books/Update")]
        public async Task<ActionResult<int>> UpdateCourse(int id, [FromBody] BookDTO bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest("Book cannot be null");
            }


            var existingBook = await _bookRepository.GetById(id);
            if (existingBook == null)
            {
                return NotFound($"Book with ID {id} not found");
            }

            var authorExists = await _authorRepository.GetById(bookDto.AuthorId);
            if (authorExists == null)
            {
                return BadRequest($"Author with ID {bookDto.AuthorId} does not exist");
            }


            existingBook.Title = bookDto.Title;
            existingBook.Genre = bookDto.Genre;
            existingBook.AuthorId = bookDto.AuthorId;

            var result = await _bookRepository.Update(id, existingBook);
            return Ok(new { message = "Book updated successfully", id = result });
        }

        [HttpDelete("Books/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteCourse(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _bookRepository.Delete(id);

            if (!result)
            {
                return NotFound($"Book with ID {id} not found");
            }

            return Ok(new { message = "Book deleted successfully", success = true });
        }
    }

}
