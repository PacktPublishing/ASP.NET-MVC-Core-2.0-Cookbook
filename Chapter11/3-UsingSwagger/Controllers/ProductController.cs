using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var productsFromRepo = _productRepository.GetAllProducts();

            if (productsFromRepo == null)
            {
                // return HTTP response status code 404
                return NotFound();
            }

            // return HTTP status code 200
            return Ok(productsFromRepo);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var productFromRepo = _productRepository.Find(id);

            if (productFromRepo == null)
            {
                // return HTTP response status code 404
                return NotFound();
            }

            // return HTTP response status code 200
            return Ok(productFromRepo);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product == null)
            {
                // return HTTP response status code 400
                return BadRequest();
            }

            _productRepository.Add(product);

            // return HTTP response status code 201
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (product == null || product.Id != id)
            {
                // return HTTP response status code 401
                return BadRequest();
            }

            var productFromRepo = _productRepository.Find(id);

            if (productFromRepo == null)
            {
                // return HTTP response status code 404
                return NotFound();
            }

            _productRepository.Update(product);

            // return HTTP response status code 204
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productFromRepo = _productRepository.Find(id);

            if (productFromRepo == null)
            {
                // return HTTP response status code 404
                return NotFound();
            }

            _productRepository.Remove(id);

            // return HTTP response status code 204
            return new NoContentResult();
        }
    }
}
