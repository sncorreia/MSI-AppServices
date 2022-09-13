using Azure.Core;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI1_MSI.Models;

namespace WebAPI1_MSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenForAPI2Controller : ControllerBase
    {
        ChainedTokenCredential credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new ClientSecretCredential("<Tenant_ID>", "<Client_Id>", "<Client_Secret>"));

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tokenRequestContext = new TokenRequestContext(new[] { "api://75db5425-03cd-4088-a135-9be8be85815f/.default" });

            var accessToken = await credential.GetTokenAsync(tokenRequestContext);

            var accessTokenResponse = new AccessTokenResponse
            {
                Token = accessToken.Token,
                ExpiresOn = accessToken.ExpiresOn
            };

            return Ok(accessTokenResponse);

        }
    }
}
