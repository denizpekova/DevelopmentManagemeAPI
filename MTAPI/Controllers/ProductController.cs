using Azure;
using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTAPI.Models;

namespace MTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = productServices.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public IActionResult Get(int id)
        {
            var result = productServices.GetProductsById(id);
            if (result == null)
            {
                var NotFounds = new ResponseMessage<Products>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = "Ürün bulunamadı",
                    Data = null
                };

                return NotFound(NotFounds);
            }
            var sucessResponse = new ResponseMessage<Products>
            {
                Success = true,
                StatusCode = 200,
                Message = "",
                Data = result
            };
            return Ok(sucessResponse);
        }

        [HttpGet("getByCategory/{category}")]
        public IActionResult GetByCategory(string category)
        {
            var result = productServices.getProductsByCategory(category);
            if (result == null)
                {
                var NotFounds = new ResponseMessage<List<Products>>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = "Category bulunamadı",
                    Data = null
                };
                return NotFound(NotFounds);
            }
            return Ok(new { success = true, data = result });
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] Products newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
                var result = productServices.AddProducts(newProduct);
            if (result == null)
            {
                var notFound = new ResponseMessage<Products>
                {
                    Success = false,
                    StatusCode = 500,
                    Message = "ürün eklerken bir hata oluştu",
                    Data = null
                };
                return BadRequest(notFound);
            }
            var sucessResponse = new ResponseMessage<Products>
            {
                Success = true,
                StatusCode = 201,
                Message = "Ürün başarılı şekilde eklendi",
                Data = result,
                Count = 1

            };

            return Ok(sucessResponse);
           
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] Products updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
       
            var result = productServices.UpdateProducts(updatedProduct);
            if (result == null) {
                var notFound = new ResponseMessage<Products>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = "Ürün bulunamadı",
                    Data = null
                };
                return NotFound(notFound);
            }

            var successResponse = new ResponseMessage<Products>
            {
                Success = true,
                StatusCode = 200,
                Message = "Ürün başarılı şekilde güncellendi.",
                Data = result
            };
            return Ok(successResponse);
      
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {

            productServices.DeleteProducts(id);
            var successResponse =  new ResponseMessage<Products>
            {
                Success = true,
                StatusCode = 200,
                Message = "Ürün başarılı şekilde silindi.",
                Data = null
            };
            return Ok(successResponse);

            
        }
    }
}
