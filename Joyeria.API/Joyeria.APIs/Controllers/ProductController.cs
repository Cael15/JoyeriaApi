using Joyeria.APIs.ViewModels;
using Joyeria.Core.Models;
using Joyeria.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Joyeria.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService,
            ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await this._productService.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProductById([FromRoute]Guid id)
        {
            try
            {
                var product = await this._productService.GetProductByIdAsync(id);
                if (product == null) return BadRequest($"Producto con id {id} no existe");

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            try
            {
                var product = await this._productService.GetProductByIdAsync(id);
                if (product == null) return BadRequest($"Producto con id {id} no existe");
                await this._productService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductVM product)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest($"Payload producto no es valido");
                var category = await this._categoryService.GetCategoryByIdAsync(product.CategoryId);
                if (category == null) return BadRequest($"Category con id {product.CategoryId} no existe");

                var productToCreate = new Product()
                { 
                    Name = product.Name,
                    Description = product.Description,
                    Stock = product.Stock,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                };

                var productCreated = await _productService.CreateAsync(productToCreate);

                return Ok(productCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromBody] ProductVM product, [FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload producto no es valido");
                var category = await this._categoryService.GetCategoryByIdAsync(product.CategoryId);
                if (category == null) return BadRequest($"Category con id {product.CategoryId} no existe");
                var productFound = await this._productService.GetProductByIdAsync(id);
                if (productFound == null) return BadRequest($"Producto con id {id} no existe");

                productFound.Name = product.Name;
                productFound.Description = product.Description;
                productFound.Stock = product.Stock;
                productFound.Price = product.Price;
                productFound.CategoryId = product.CategoryId;

                var productUpdated = await _productService.UpdateAsync(productFound);

                return Ok(productUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
   
    
    
    
    }
}
