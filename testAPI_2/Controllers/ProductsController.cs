using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testAPI_2.DTOs;
using testAPI_2.Models;
using testAPI_2.Services.Interfaces;

namespace testAPI_2.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // BAI 1
        [HttpGet]
        public List<Product> GetProducts()
        {
            List<Product> listProd = _productService.GetProducts();
            return listProd;
        }

        // BAI 2
        [HttpGet("{id}")]
        public IActionResult GetProductsById(int id)
        {
            try
            {
                Product prod = _productService.GetProductsById(id);
                return Ok(prod);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // BAI 3
        [HttpPost]
        public Product InsertProduct(ProductDto product)
        {
            Product prod = _productService.InsertProduct(product);
            return prod;
        }

        // BAI 4
        [HttpPut("{id}")]
        public bool UpdateProduct(int id, ProductDto product)
        {
            bool prod = _productService.UpdateProduct(id, product);
            return prod;
        }

        // BAI 5
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            bool prod = _productService.DeleteProduct(id);
            return prod;
        }
    }
}
