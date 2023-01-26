using Microsoft.AspNetCore.Mvc;
using Tienda.Domain.Models;
using Tienda.Domain.Repositories;

namespace Tienda.Controllers.ProductController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ActionName("List")] //api/Product/List
        public async Task<IActionResult> ListMethod()
        {
            try
            {
                var products = await _unitOfWork.Products.GetAllAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        [ActionName("Get")] //api/Product/Get
        public async Task<IActionResult> GetMethod(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                return Ok(product);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Create")] //api/Product/Create
        public async Task<IActionResult> CreateMethod(Product product)
        {
            try
            {
                _unitOfWork.Products.Add(product);
                _unitOfWork.Save();
                if(product == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction("Create", new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
