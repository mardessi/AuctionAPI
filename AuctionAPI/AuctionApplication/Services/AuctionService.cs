using AuctionApplication.DTOs;
using AuctionApplication.Interfaces;
using AuctionApplication.Models;

namespace AuctionApplication.Services
{
    public class AuctionService : IAuctionService
    {
        public AuctionResultDto GetAuctionWinner(List<Bidder> bidders, decimal reservePrice)
        {
            // récupérer pour bidder le max bid et les bid valide qui sont >= reserve
            var validBids = bidders
                .Select(b => new
                {
                    BidderName = b.Name,
                    BestBid  = b.Bids?.Max() ?? 0
                })
                .Where(b=>b.BestBid>=reservePrice)
                .ToList();

            if(!validBids.Any())
            {
                throw new InvalidOperationException("No valid bids !");
            }

            // récupérer le max de valid bid
            var winner = validBids.OrderByDescending(b=>b.BestBid).First();

            // récupérer le deuxiéme gagnant
            var secondWinner= validBids
                .Where(b=>b.BidderName!=winner.BidderName)
                .OrderByDescending(b=>b.BestBid)
                .FirstOrDefault();

            decimal winningPrice = secondWinner != null ? secondWinner.BestBid : reservePrice;

            return new AuctionResultDto
            {
                WinnerName = winner.BidderName,
                WinnerPrice = winningPrice,
            };
        }
    }
}
