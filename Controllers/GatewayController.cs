using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using UserMicroservice.DTOs;
using System.Text.Json;

namespace UserMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IHttpClientFactory clientFactory;

        public GatewayController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        // POST: api/Gateway
        [HttpGet]
        public async Task Post([FromBody] string value)
        {
            var parameters = new ServiceRegistrationDTO
            {
                Name = "Service1",
                Address = "http://localhost:4000",
                Type = "type1"

            };
            var request = new HttpRequestMessage(HttpMethod.Post,
                "http://localhost:4000/service-register");
            request.Content = new StringContent(JsonSerializer.Serialize(parameters),
                Encoding.UTF8,
                "application/json");
            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);


        }

    }
}
