using Farmino.Service.Commands.ProductCommands;
using Farmino.Service.Dispatchers.Interfaces;
using Farmino.Service.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Farmino.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IProductService _productService;

        public ProductsController(ICommandDispatcher commandDispatcher, IProductService productService)
        {
            _commandDispatcher = commandDispatcher;
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
            => Ok(await _productService.GetAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProduct command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok("Product has been added");
        }
    }
}
