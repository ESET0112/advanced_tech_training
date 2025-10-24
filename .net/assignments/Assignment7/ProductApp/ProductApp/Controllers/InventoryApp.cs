using Microsoft.AspNetCore.Mvc;
using ProductApp.Data.Repository;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryApp : ControllerBase
    {
        private readonly IinventoryRepository<Category> _categoryRepository;
        private readonly IinventoryRepository<Product> _productRepository;

        public InventoryApp(
            IinventoryRepository<Category> categoryRepository,
            IinventoryRepository<Product> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }


        [HttpGet("Categories/all")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("Categories/{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var category = await _categoryRepository.GetById(id);

            if (category == null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return Ok(category);
        }

        


        [HttpPost("Categories/Create")]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Author cannot be null");
            }

            var category = new Category
            {
                CategoryName = categoryDto.CategoryName
            };

            var result = await _categoryRepository.Create(category);
            return Ok(new { message = "Category created successfully", id = result });
        }

        [HttpPut("Categories/update")]
        public async Task<ActionResult<int>> UpdateCategory(int id, [FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Author cannot be null");
            }

            var existingCategory = await _categoryRepository.GetById(id);
            if (existingCategory == null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            existingCategory.CategoryName = categoryDto.CategoryName;
            

            var result = await _categoryRepository.Update(id, existingCategory);
            return Ok(new { message = "Category updated successfully", id = result });
        }

        [HttpDelete("Categories/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteAuthor(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _categoryRepository.Delete(id);

            if (!result)
            {
                return NotFound($"Author with ID {id} not found");
            }

            return Ok(new { message = "Author deleted successfully", success = true });
        }


        [HttpGet("Products/all")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("Products/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var products = await _productRepository.GetById(id);

            if (products == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            return Ok(products);
        }



        [HttpPost("Products/Create")]
        public async Task<ActionResult<int>> CreateProduct([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product cannot be null");
            }

            var categoryExists = await _categoryRepository.GetById(productDto.CategoryId);
            if (categoryExists == null)
            {
                return BadRequest($"Category with ID {productDto.CategoryId} does not exist");
            }


            var product = new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                CategoryId = productDto.CategoryId

            };

            var result = await _productRepository.Create(product);
            return Ok(new { message = "Product created successfully", id = result });
        }

        [HttpPut("Products/Update")]
        public async Task<ActionResult<int>> UpdateProduct(int id, [FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Book cannot be null");
            }


            var existingproduct = await _productRepository.GetById(id);
            if (existingproduct == null)
            {
                return NotFound($"Product with ID {id} not found");
            }

            var categoryExists = await _categoryRepository.GetById(productDto.CategoryId);
            if (categoryExists == null)
            {
                return BadRequest($"Category with ID {productDto.CategoryId} does not exist");
            }


            existingproduct.ProductName = productDto.ProductName;
            existingproduct.Price = productDto.Price;
            existingproduct.StockQuantity = productDto.StockQuantity;
            existingproduct.CategoryId = productDto.CategoryId;

            var result = await _productRepository.Update(id, existingproduct);
            return Ok(new { message = "Product updated successfully", id = result });
        }

        [HttpDelete("Books/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _productRepository.Delete(id);

            if (!result)
            {
                return NotFound($"Product with ID {id} not found");
            }

            return Ok(new { message = "Product deleted successfully", success = true });
        }
    }
}
