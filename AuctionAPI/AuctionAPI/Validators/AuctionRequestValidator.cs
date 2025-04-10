using AuctionApplication.DTOs;
using FluentValidation;

namespace AuctionAPI.Validators
{
    public class AuctionRequestValidator: AbstractValidator<AuctionRequestDto>
    {
        public AuctionRequestValidator()
        {
            RuleFor(x => x.Bidders)
                .NotEmpty()
                .WithMessage("At least one bidder must be provided.");

            RuleForEach(x => x.Bidders).ChildRules(bidder =>
            {
                bidder.RuleFor(b => b.Name)
                      .NotEmpty()
                      .WithMessage("Bidder name is required.");

                bidder.RuleFor(b => b.Bids)
                      .NotEmpty()
                      .WithMessage("Each bidder must have at least one bid.");
            });

            RuleFor(x => x.ReservePrice)
                    .NotEmpty()
                    .GreaterThan(-1)
                    .WithMessage("Reserve price must be minimum 0");
        }
    }
}
