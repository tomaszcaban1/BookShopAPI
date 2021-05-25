using System;
using System.IO;
using BookShopAPI.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace BookShopAPI.Controllers
{
    [Route("file")]
    public class FileController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetFile([FromQuery] string fileName)
        {
            var roothPath = Directory.GetCurrentDirectory();
            var filePath = $"{roothPath}/{FileConstants.StaticFiles}/{fileName}";

            var isFileExist = System.IO.File.Exists(filePath);

            if (!isFileExist)
                return NotFound();

            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var fileType);
            var fileContents = System.IO.File.ReadAllBytes(filePath);

            return File(fileContents, fileType);
        }

        [HttpPost]
        public ActionResult<string> PostFile([FromForm] IFormFile file)
        {
            if (file is null)
                return BadRequest();

            var roothPath = Directory.GetCurrentDirectory();
            var fileName = file.FileName;
            var filePath = $"{roothPath}/{FileConstants.StaticFiles}/{fileName}";

            using (var outputFileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(outputFileStream);
            }

            return Ok($"{FileConstants.StaticFiles}/{fileName}");
        }
    }
}
