using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOXFleetTestApi.Controllers.Transaction.RequestObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOXFleetTestApi.Controllers.Transaction
{
    [Route("api/")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ISender Sender;
        
        public TransactionController(ISender sender)
        {
            Sender = sender;
        }
        
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(DepositRequest request, CancellationToken cancellationToken)
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
