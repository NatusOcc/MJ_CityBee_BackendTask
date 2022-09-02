using CityBee_task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CityBee_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpPost("upload")]
        public IActionResult UploadBook(IFormFile file)
        {
            if (file is null || file.Length == 0)
            {
                return BadRequest("Proper file is not provided");
            }
            else
            {
                return Ok(BookService.CommonWords(file, 10));
            }
        }
    }
}
