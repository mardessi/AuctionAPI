using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AuctionApplication.DTOs;
using AuctionApplication.Models;
using FluentAssertions;

namespace AuctionAPI.Tests
{
    public class AuctionApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public AuctionApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostAuction_Should_ReturnWinner_When_ValidRequest()
        {
            // Arrange
            var request = new AuctionRequestDto
            {
                ReservePrice = 100,
                Bidders = new List<Bidder>
                {
                    new Bidder
                    {
                        Name = "Alice",
                        Bids = new List<decimal> { 90, 110 }
                    },
                    new Bidder
                    {
                        Name = "Bob",
                        Bids = new List<decimal> { 120 }
                    }
                }
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/auction", request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var auctionResult = await response.Content.ReadFromJsonAsync<AuctionResultDto>();
            auctionResult.Should().NotBeNull();
            auctionResult.WinnerName.Equals("Bob");
            auctionResult.WinnerPrice.Equals(110);
      
        }
    }
}
