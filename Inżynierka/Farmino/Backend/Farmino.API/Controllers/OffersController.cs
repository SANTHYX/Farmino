using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Queries.Offer;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IOfferService _offerService;

        public OffersController(ICommandDispatcher commandDispatcher, IOfferService offerService)
        {
            _commandDispatcher = commandDispatcher;
            _offerService = offerService;
        }

        [HttpGet("{offerId}")]
        public async Task<IActionResult> Get(Guid offerId)
            => Ok(await _offerService.GetOfferAsync(offerId));

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OfferQuery query)
            => Ok(await _offerService.BrowseAllAsync(query));

        [HttpPost("make-order")]
        public async Task<IActionResult> Post([FromBody] MakeOrder command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been created");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOffer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Offer has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoveOffer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Offer has been removed");
        }
    }
}
