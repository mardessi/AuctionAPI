using AuctionApplication.DTOs;
using AuctionApplication.Interfaces;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IAuctionService _auctionService;

        public AuctionController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        /// <summary>
        /// Lancer une enchère et retourner le gagnant + prix payé.
        /// </summary>
        /// <param name="request">Données de l'enchère</param>
        /// <returns>Résultat de l'enchère</returns>
        [HttpPost]
        public IActionResult RunAuction([FromBody] AuctionRequestDto request)
        {

            // Appeler le service
            var result = _auctionService.GetAuctionWinner(request.Bidders, request.ReservePrice);

            // Retourner résultat API
            return Ok(result);
        }
    }
}
