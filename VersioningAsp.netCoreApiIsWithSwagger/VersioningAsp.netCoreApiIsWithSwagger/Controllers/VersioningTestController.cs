using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VersioningAsp.netCoreApiIsWithSwagger.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("2")]

    public class VersioningTestController : ControllerBase
    {
        [HttpGet]
        [Route("api/VersioningTest/get")]
        [MapToApiVersion("1")]
        public IActionResult Get(string text)
        {
            return Ok(new { version = "V1", text = text });
        }

        [HttpGet]
        [MapToApiVersion("2")]
        [Route("api/VersioningTest/get")]
        public IActionResult GetV2(string text)
        {
            return Ok(new { version = "V2", text = text });
        }
    }

    //URI Versioning 
    //public class VersioningTestController : ControllerBase
    //{
    //    [HttpGet]
    //    [Route("api/v{version:apiVersion}/VersioningTest/get")]
    //    [MapToApiVersion("1")]
    //    public IActionResult Get(string text)
    //    {
    //        return Ok(new { version = "V1", text = text });
    //    }

    //    [HttpGet]
    //    [MapToApiVersion("2")]
    //    [Route("api/v{version:apiVersion}/VersioningTest/get")]
    //    public IActionResult GetV2(string text)
    //    {
    //        return Ok(new { version = "V2", text = text });
    //    }
    //}
}
