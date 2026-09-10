using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;
using TodoAPI.Services;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ISystemTime _timeSystem;
        public ProductsController(ISystemTime timeSystem)
        {
            _timeSystem = timeSystem;
        }

        [HttpGet("GetTime")]
        public IActionResult GetTime()
        {
            var getSystemTime = _timeSystem.GetCurrentTime();
            return Ok(new
            {
                serverTime = getSystemTime
            });
        }

        private static readonly List<Product> products = new()
        {
           new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 50000,
                Quantity = 10
            },
            new Product
            {
                Id = 2,
                Name = "Keyboard",
                Price = 1500,
                Quantity = 20
            },
            new Product
            {
                Id = 3,
                Name = "Mouse",
                Price = 800,
                Quantity = 30
            }
        };


        [HttpGet("getProd")]
        public IActionResult GetProduct()
        {
            return Ok(products);
        }


        [HttpGet("{Id}")]
        public IActionResult GetProduct(int Id)
        {
            var product = products.FirstOrDefault(x => x.Id == Id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }


        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            product.Id = products.Max(x => x.Id) + 1;

            products.Add(product);

            return Ok("Product Added");
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            var product = products.FirstOrDefault(x => x.Id == Id);

            if (product == null)
            {
                return NotFound(Id);
            }

            products.Remove(product);
            return Ok("Deleted Successfully");
        }

    }
}
