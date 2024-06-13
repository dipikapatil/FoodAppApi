using FoodAppApi.Context;
using FoodAppApi.Models;
using FoodAppApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IProductService _productService;
        IRepository _repository;
        public CategoriesController(IProductService productService, IRepository repository)
        {
            _productService = productService;
            _repository = repository;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _productService.GetCategories();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProductByCategory()
        {
            try
            {
                var products = _productService.GetProducts();
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("AddProductItem")]
        public IActionResult AddProductItem(Product product )
        {
            try
            {
                _productService.AddEntity(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetProuctById")]
        public async Task<ActionResult<Product>> GeProductById(int id)
        {
            var model = await _repository.SelectById<Product>(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }
        [HttpPut]
        [Route("SaveProduct")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                _productService.Update(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
