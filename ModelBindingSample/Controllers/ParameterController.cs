using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingSample.Controllers
{
    [Route("Parameter/[action]")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        //[HttpGet()] 瞭解一下，有無帶"{id}"的差異
        [HttpGet("{id}")]
        public IActionResult RouteBinding(int id)
        {
            throw new Exception();
            return Content($"id is {id}");
        }

        //[HttpGet()] 瞭解一下，有無帶"{id}"的差異
        [HttpGet("{id}")]
        public IActionResult RouteBinding2([FromRoute] int id)
        {
            return Content($"id is {id}");
        }

        // "{id}" 的問題，下一個 SampleTypeSample 再更深入討論。
        // 這裡先專注在Parameter Binding。

        [HttpGet]
        public IActionResult HeaderBinding([FromHeader] string header)
        {
            return Content($"header is {header}");
        }

        [HttpGet]
        public IActionResult FormBinding([FromForm] string form)
        {
            return Content($"form is {form}");
        }

        [HttpGet]
        public IActionResult QueryBinding([FromQuery] string query)
        {
            return Content($"query is {query}");
        }

        // 學員測
        [HttpGet("{id:int}")]
        public IActionResult TogetherBinding(
            [FromRoute] int id,
            [FromHeader] string header,
            [FromForm] string form,
            [FromQuery] string query)
        {
            return Content($"header: {header}, form: {form}, id: {id}, query: {query}");
        }

        // mark for netcoreapp3
        [HttpGet]
        public IActionResult DIBinding([FromServices] ILogger<ParameterController> logger)
        {
            return Content($"logger is null: {logger == null}.");
        }

        [HttpPost]
        public IActionResult BodyBinding([FromBody] UserData model)
        {
            return Ok(model);
        }
    }

    public class UserData
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [RegularExpression(@"\w+")]
        public string Name { get; set; }
        [StringLength(maximumLength: 255, MinimumLength = 8)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
    }
}
