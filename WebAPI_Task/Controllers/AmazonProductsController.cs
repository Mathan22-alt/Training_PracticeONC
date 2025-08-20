using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using WebAPI_Task.Models;

namespace WebAPI_Task.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class AmazonProductsController : ControllerBase

    {


        private static List<Products> products = new List<Products>

        {

            new Products { ProdID = 1, ProdName = "Laptop", Price = 50000, Category = "Electronics" },

            new Products { ProdID = 2, ProdName = "Mixer", Price = 3000, Category = "Electrical" },

            new Products { ProdID = 3, ProdName = "Mobile", Price = 20000, Category = "Electronics" }

        };


        [HttpGet("all")]

        public IActionResult GetAllProducts()

        {

            return Ok(products);

        }

        [HttpGet("FindProductByID/{id:int}")]

        public IActionResult GetProduct(int id)

        {

            return Ok(products[id]);

        }

        [HttpGet("FindProductByCategory/{category}")]

        public IActionResult GetProduct(string category)

        {

            var result = products.Where(p => p.Category == category).ToList();

            return Ok(result);

        }

    }

}

