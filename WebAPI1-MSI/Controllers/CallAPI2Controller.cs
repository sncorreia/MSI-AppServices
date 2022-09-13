using Azure;
using Azure.Core;
using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Diagnostics;
using System.Text.Json;
using WebAPI1_MSI.Models;

namespace WebAPI1_MSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallAPI2Controller : ControllerBase
    {
        ChainedTokenCredential credential = new ChainedTokenCredential(new ManagedIdentityCredential(), new ClientSecretCredential("14de090f-18bd-4cbd-8136-d0bbaf1b1d7a", "0b98eb26-99b5-4bb5-bc97-9ddc79c5b97a", "mgb8Q~eJVF2tcgHw-nKoznKuV8KC2wY9kwwWqa8C"));
        private readonly IHttpClientFactory _httpClientFactory;

        public CallAPI2Controller(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tokenRequestContext = new TokenRequestContext(new[] { "api://75db5425-03cd-4088-a135-9be8be85815f/.default" });

            var accessToken = await credential.GetTokenAsync(tokenRequestContext);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://webapi220220907142906.azurewebsites.net/api2/onlyaad")
            {
                Headers =
                {
                    { HeaderNames.Authorization, "Bearer " + accessToken.Token },
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var api2response = JsonSerializer.Deserialize<API2Response>(content, options);

                return Ok(api2response);
            }
            else
            {
                Debug.WriteLine(httpResponseMessage);
                return StatusCode(500);
            }

        }

    }
}
