using AuctionApplication.Models;

namespace AuctionApplication.DTOs
{
    public class AuctionRequestDto
    {
        public List<Bidder> Bidders { get; set; }
        public decimal ReservePrice { get; set; }
    }
}
