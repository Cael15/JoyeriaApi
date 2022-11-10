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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            try
            {
                var categories = await this._categoryService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryVM category)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload categoria no es valida");


                var categoryToCreate = new Category()
                {
                    Name = category.Name
                };

                var categoryCreated = await _categoryService.CreateAsync(categoryToCreate);

                return Ok(categoryCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] CategoryVM category, [FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest($"Payload categoria no es valida");
               
                var categoryFound = await this._categoryService.GetCategoryByIdAsync(id);
                if (categoryFound == null) return BadRequest($"Producto con id {id} no existe");

                categoryFound.Name = category.Name;
               

                var categoryUpdated = await _categoryService.UpdateAsync(categoryFound);

                return Ok(categoryUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
