using Farmino.Service.Commands.OfferCommands;
using Farmino.Service.Dispatchers.Interfaces;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _offerService.GetOfferAsync(id));

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _offerService.BrowseAllAsync());

        [HttpPost("buy")]
        public async Task<IActionResult> Post([FromBody] Buy command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Transaction has been completed sucesfully");
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
