using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ModelBindingSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorCodeController : ControllerBase
    {
        public IActionResult Get(string code)
        {
            // logger(把錯誤log記下來, 檔案型,寫在DB...)
            return BadRequest($"Error, status code: {code}");
        }
    }
}
