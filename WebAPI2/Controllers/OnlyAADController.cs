using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [Authorize(Policy = "OnlyAADScheme")]
    [Route("api2/[controller]")]
    [ApiController]
    public class OnlyAADController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetResponseForAPI2()
        {
            var response = new API2Response
            {
                ComingFromAPI = 2,
                API2CreatedAt = DateTime.Now,
                Description = "This controller accepts the OnlyAADScheme"
            };

            return Ok(response);
        }
    }
}
