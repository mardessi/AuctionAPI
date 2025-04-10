using AuctionApplication.DTOs;
using AuctionApplication.Models;

namespace AuctionApplication.Interfaces
{
    public interface IAuctionService
    {
        AuctionResultDto GetAuctionWinner(List<Bidder> bidders, decimal reservePrice);
    }
}
