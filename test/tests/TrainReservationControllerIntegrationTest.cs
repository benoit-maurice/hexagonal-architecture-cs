using api.Controllers;
using System;
using Xunit;
using domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using api;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using api.Dto;
using System.Text.Json;
using System.IO;

namespace tests
{
    public class TrainReservationControllerIntegrationTest
    {
        private HttpClient _client;

        public TrainReservationControllerIntegrationTest()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();

            var server = new TestServer(builder);
            _client = server.CreateClient();
        }

        [Fact]
        public async Task Post_Train_Reservation_Should_Return_Reservation()
        {
            var postPayload = JsonSerializer.Deserialize<object>(
                @"{ 
                    ""train_id"": ""TGV"", 
                    ""seat_count"": ""2"" 
                }");

            var postContent = JsonContent.Create(postPayload, MediaTypeHeaderValue.Parse("application/json"));

            var response = await _client.PostAsync("/tickets", postContent);

            var responsePayload = await response.Content.ReadAsStringAsync();

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(@"{""train_id"":""TGV"",""booking_reference"":""REF_1234"",""seats"":[""1A"",""2A""]}", responsePayload);
        }
    }
}
