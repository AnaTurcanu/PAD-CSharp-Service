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
        public async Task<IActionResult> Post()
        {
            var parameters = new ServiceRegistrationDTO
            {
                Service_name = "Service1",
                Address = "http://localhost:50757",
                Type = "type1"

            };
            var request = new HttpRequestMessage(HttpMethod.Post,
                "http://localhost:5000/service-register");
            request.Content = new StringContent(JsonSerializer.Serialize(new {service_name = "Service1", address = "http://localhost:50757", type = "type1" }),
                Encoding.UTF8,
                "application/json");
            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }
            var another = await response.Content.ReadAsStringAsync();
            //var content = JsonSerializer.DeserializeAsync<string>(another);
            return Ok(another);


        }

    }
}
