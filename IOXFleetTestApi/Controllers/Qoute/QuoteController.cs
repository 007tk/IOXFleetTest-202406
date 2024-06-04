using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOXFleetTest.Application.Qoutes.Commands.PayQuoteCommand;
using IOXFleetTestApi.Controllers.Qoute.RequestObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOXFleetTestApi.Controllers.Qoute
{
    [Route("api/")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly ISender Sender;
        
        public QuoteController(ISender sender)
        {
            Sender = sender;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateQuoteRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = request.MapToCommand(request);
            
            await Sender.Send(command, cancellationToken);

            return Ok("Transaction complete.");
        }
        
        [HttpPost("pay")]
        public async Task<IActionResult> Pay(PayQuoteRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = request.MapToCommand(request);
            
            await Sender.Send(command, cancellationToken);

            return Ok("Transaction complete.");
        }
        
    }
}
