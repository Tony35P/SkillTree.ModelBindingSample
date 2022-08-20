using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ModelBindingSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorCodeController : ControllerBase
    {
        public string RequestId { get; set; }
        public string ErrorStatusCode { get; set; }
        public string OriginalURL { get; set; }

        public IActionResult Get(string code)
        {
            // logger
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ErrorStatusCode = code;
            var statusCodeReExecuteFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeReExecuteFeature != null)
            {
                OriginalURL =
                    statusCodeReExecuteFeature.OriginalPathBase
                    + statusCodeReExecuteFeature.OriginalPath
                    + statusCodeReExecuteFeature.OriginalQueryString;
            }

            return BadRequest($"Error, RequestId: {RequestId}, OriginalUrl: {OriginalURL}, status code: {ErrorStatusCode}");
        }
    }
}
