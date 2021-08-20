using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WinFormsAddPassPDF;

namespace WebAppiGeneratePdf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerPdfController : ControllerBase
    {
        [HttpGet("DownloadBase64")]
        public async Task<IActionResult> DownloadBase64([FromServices] ProtectedSecuredPDFiTextSharp _ProtectedSecuredPDFiTextSharp)
        {
            var stream = _ProtectedSecuredPDFiTextSharp.GenerateOwnerPassword();
            return File(stream, "application/octet-stream"); // returns a FileStreamResult
        }
        [HttpGet("Download")]
        public async Task<IActionResult> Download([FromServices] ProtectedSecuredPDFiTextSharp _ProtectedSecuredPDFiTextSharp)
        {
            byte[] buffer = _ProtectedSecuredPDFiTextSharp.GenerateOwnerPasswordByte();
            Stream stream = new MemoryStream(buffer);
            
            return File(stream, "application/octet-stream","pdf_enc.pdf"); // returns a FileStreamResult
        }
    }
}
