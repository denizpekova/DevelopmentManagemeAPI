using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTAPI.Models;

namespace MTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenseServices licenseServices;
        public LicenseController(ILicenseServices licenseServices)
        {
            this.licenseServices = licenseServices;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = licenseServices.GetAllLicenses();

            if (result == null || !result.Any())
            {
                var notFound = new ResponseMessage<List<license>>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = "Lisans bulunamadı.",
                    Data = null
                };
                return NotFound(notFound);
            }
            
            var sucesssResponse = new ResponseMessage<List<license>>
            {
                Success = true,
                StatusCode = 200,
                Message = "Lisanslar başarıyla getirildi.",
                Data = result,
                Count = result.Count
            };

            return Ok(sucesssResponse);
        }

        [HttpGet("getById/{key}")]
        public IActionResult Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                var badRequest = new ResponseMessage<license>
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Lisans anahtarı boş olamaz.",
                    Data = null
                };

                return BadRequest(badRequest);
            }

            var result = licenseServices.GetLicenseByKey(key);
            if (result == null)
            {
                var notFound = new ResponseMessage<license>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = "Lisans bulunamadı.",
                    Data = null
                };

                return NotFound(notFound);
            }
            var successResponse = new ResponseMessage<license>
            {
                Success = true,
                StatusCode = 200,
                Message = "Lisans başarıyla getirildi.",
                Data = result
            };

            return Ok(successResponse);      
        }

        [HttpPost("create")]
        public IActionResult createLisans([FromBody] license newLicense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

       
            var lisans = licenseServices.AddLicense(newLicense);
            var successResponse = new ResponseMessage<license>
            {
                Success = true,
                StatusCode = 201,
                Message = "Lisans başarıyla oluşturuldu.",
                Data = lisans
            };
            return Ok(successResponse);
           
        }

        [HttpPut("update")]
        public IActionResult updateLisans([FromBody] license updateLisans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

      
            var lisansUpdate = licenseServices.UpdateLicense(updateLisans);
            if (lisansUpdate == null)
            {
                var notFound = new ResponseMessage<license>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = "Güncellenecek lisans bulunamadı.",
                    Data = null
                };
                return NotFound(notFound);
            }

            var sucessResponse = new ResponseMessage<license>
            {
                Success = true,
                StatusCode = 200,
                Message = "Lisans başarıyla güncellendi.",
                Data = lisansUpdate
            };
            return Ok(sucessResponse);          
        }

        [HttpDelete("delete/{key}")]
        public IActionResult deleteLisans(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                var badRequest = new ResponseMessage<license>
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Lisans anahtarı boş olamaz.",
                    Data = null
                };
                return BadRequest(badRequest);
            }

            licenseServices.DeleteLicense(key);

            var sucessResult = new ResponseMessage<license>
            {
                Success = true,
                StatusCode = 200,
                Message = "Lisans başarıyla silindi.",
                Data = null
            };
            return Ok(sucessResult);
         }
    }
}
