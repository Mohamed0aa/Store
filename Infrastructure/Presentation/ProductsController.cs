using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager _serviceManager):ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync ()
        {
            var products=await _serviceManager.ProductService.GetAllProductsAsync();

            if (products is null) return BadRequest();

            return Ok(products);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync( int id)
        {
            var product = await _serviceManager.ProductService.GetByIdAsync( id);

            if (product is null) return BadRequest();

            return Ok(product);

        }
        [HttpGet("Brands")]
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            var brands = await _serviceManager.ProductService.GetAllBrandsAsync();

            if (brands is null) return BadRequest();

            return Ok(brands);

        }
        [HttpGet("Types")]
        public async Task<IActionResult> GetAllTypesAsync()
        {
            var Types = await _serviceManager.ProductService.GetAllTypesAsync();

            if (Types is null) return BadRequest();

            return Ok(Types);
        }


    }
}
