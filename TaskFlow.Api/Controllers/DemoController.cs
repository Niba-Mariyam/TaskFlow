using Microsoft.AspNetCore.Mvc;
using TaskFlow.Api.Services;

namespace TaskFlow.Api.Controllers
{
    [ApiController]
    [Route("api/demo")]
    public class DemoController:ControllerBase
    {
        private readonly IGuidProvider _a;
        private readonly IGuidProvider _b;

        public DemoController(IGuidProvider a,IGuidProvider b)
        {
            _a = a;
            _b = b;
        }


        [HttpGet]
        public IActionResult Get() => Ok( new { a = _a.Id, b = _b.Id }); 
    }
}
