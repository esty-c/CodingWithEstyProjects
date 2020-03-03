using Microsoft.AspNetCore.Mvc;

namespace Asp.NetCoreVersioning.Controllers
{
 
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class VersioningTestController : Controller
    {
        
        [HttpGet]
        [Route("api/v{version:apiVersion}/VersioningTest/get")]
        [Route("api/VersioningTest/get")]
        public IActionResult Get()
        {
            return Ok("V1");
        }

        [HttpGet]
        [MapToApiVersion("2")]
        [Route("api/v{version:apiVersion}/VersioningTest/get")]
        [Route("api/VersioningTest/get")]
        public IActionResult GetV2()
        {
            return Ok("V2");
        }
    }
}