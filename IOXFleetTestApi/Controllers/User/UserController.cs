using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOXFleetTestApi.Controllers.RequestObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IOXFleetTestApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender Sender;

        public UserController(ISender sender)
        {
            Sender = sender;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var commnad = request.MapToCommand(request);
            
            await Sender.Send(commnad, cancellationToken);

            return Ok("User created!");
        }
    }
}
