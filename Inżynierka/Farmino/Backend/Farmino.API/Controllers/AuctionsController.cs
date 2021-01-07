using Farmino.Service.Commands.AuctionCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IAuctionService _auctionService;

        public AuctionsController(ICommandDispatcher commandDispatcher, IAuctionService actionService)
        {
            _commandDispatcher = commandDispatcher;
            _auctionService = actionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _auctionService.GetAuction(id));

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _auctionService.BrowseAuctions());

        [HttpGet("winner/{id}")]
        public async Task<IActionResult> GetWinner(Guid id)
            => Ok(await _auctionService.GetWinner(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuction command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Auction has been created");
        }

        [HttpPost("to-auction")]
        public async Task<IActionResult> Post([FromBody] ToAuction command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("You are taking part in auction");
        }
    }
}
