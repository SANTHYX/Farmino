using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Queries;
using Farmino.Service.Queries.Offer;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Get([FromQuery] PagedQuery paged, [FromQuery] OfferQuery query)
            => Ok(await _offerService.BrowseAllAsync(paged,query));

        [Authorize]
        [HttpGet("{userName}/observed")]
        public async Task<IActionResult> Get(string userName, [FromQuery] PagedQuery paged)
            => Ok(await _offerService.GetObservedsAsync(userName, paged));

        [Authorize]
        [HttpPost("make-order")]
        public async Task<IActionResult> Post([FromBody] MakeOrder command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been created");
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateOffer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Order has been updated");
        }

        [Authorize]
        [HttpPost("deactivate")]
        public async Task<IActionResult> Post([FromBody] DeactiveOffer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Offer has been created");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateOffer command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Offer has been created");
        }
    }
}
