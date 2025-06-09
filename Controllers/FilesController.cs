// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
            ?? throw new System.ArgumentNullException(
                nameof(fileExtensionContentTypeProvider)
            );
        }
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathToFile = "getting-acquainted-with-aspnet-core-slides - Copy.pdf";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }
            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var fileBytes = System.IO.File.ReadAllBytes(pathToFile);
            // return File(fileBytes, "text/plain", Path.GetFileName(pathToFile));
            return File(fileBytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}