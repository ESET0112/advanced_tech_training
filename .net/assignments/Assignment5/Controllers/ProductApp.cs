using Product.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApp: ControllerBase
    {
        //All
        [HttpGet]
        [Route("All")]

        public ActionResult<IEnumerable<ProductDTO>> getproducts()
        {
            return Ok(ProductRepository.Products);
        }





        //by id
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ProductDTO> getproductsbyid(int id) 
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var products = ProductRepository.Products
                           .Where(n=>n.ProductID==id)
                           .FirstOrDefault();

            var productDTO = new ProductDTO
            {
                ProductID = id,
                Name = products.Name,
                Category = products.Category,
                Price = products.Price,
                StockQuantity = products.StockQuantity
            };

            if(productDTO == null)
            {
                return NotFound($"this {id} is not present in record");
            }

            return Ok(productDTO);
        }

        [HttpPost]
        [Route("Create")]

        public ActionResult<ProductDTO> CreateProduct([FromBody] ProductDTO products)
        {
            if (products == null)
            {
                return BadRequest();
            }

            ProductDTO newProduct = new ProductDTO
            {
                ProductID = products.ProductID,
                Name = products.Name,
                Category = products.Category,
                Price = products.Price,
                StockQuantity = products.StockQuantity

            };

            if (newProduct.Price > 0 && newProduct.StockQuantity >= 0)
            {
                ProductRepository.Products.Add(newProduct);
            }


            return Ok(newProduct);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<ProductDTO> UpdateProduct([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var existingProduct = ProductRepository.Products.Where(s=>s.ProductID == product.ProductID).FirstOrDefault();
            if (existingProduct == null)
            {
                return NotFound($"The product with id {product.ProductID} not found");
            }

            existingProduct.Name= product.Name;
            existingProduct.Category= product.Category;
            existingProduct.Price= product.Price;
            existingProduct.StockQuantity = product.StockQuantity;

            return Ok(existingProduct);
        }


        [HttpPatch]
        [Route("{id:int}/UpdatePartial")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<ProductDTO> UpdateProductPartial(int id, [FromBody] JsonPatchDocument<ProductDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }

            var existingProduct = ProductRepository.Products.Where(s => s.ProductID == id).FirstOrDefault();

            if (existingProduct == null)
            {
                return NotFound($"The product with id {id} not found");
            }

            var productDTO = new ProductDTO()
            {
                ProductID = existingProduct.ProductID,
                Name = existingProduct.Name,
                Category = existingProduct.Category,
                Price = existingProduct.Price,
                StockQuantity = existingProduct.StockQuantity,
            };

            patchDocument.ApplyTo(productDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingProduct.Name = productDTO.Name;
            existingProduct.Category = productDTO.Category;
            existingProduct.Price = productDTO.Price;
            existingProduct.StockQuantity = productDTO.StockQuantity;

            return NoContent();


        }



    }
}
