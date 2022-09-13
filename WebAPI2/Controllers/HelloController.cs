using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [Authorize]
    [Route("api2/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetResponseForAPI2()
        {
            var response = new API2Response
            {
                ComingFromAPI = 2,
                API2CreatedAt = DateTime.Now,
                Description = "This controller accepts all the schemas"
            };

            return Ok(response);
        }
    }
}
