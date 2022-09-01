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
                return Ok(CommonWords(file, 10));
            }
        }


        /// <summary>
        /// Method to count top N ammount of repeating words in a file
        /// </summary>
        /// <param name="file">file in which to count</param>
        /// <param name="ammount">how many words should be returned</param>
        /// <returns>top N most common words in a file</returns>
        private IEnumerable CommonWords(IFormFile file, int ammount)
        {
            Dictionary<string, int> wordsDict = new Dictionary<string, int>();
            string[] line;
            char[] seperator = { ' ', ',', '.', '-', ':', ';', '?', '!', '"' };
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    line = reader.ReadLine().Split(seperator);
                    foreach(string word in line)
                    {
                        if (word != "")
                        {
                            wordsDict.TryGetValue(word.ToLower(), out var currentCount);
                            wordsDict[word.ToLower()] = currentCount + 1;
                        }
                    }
                }
            }
            return wordsDict.OrderByDescending(x => x.Value).Take(ammount);
        }
    }
}
