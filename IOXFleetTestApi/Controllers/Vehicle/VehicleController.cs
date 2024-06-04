using IOXFleetTestApi.Controllers.Vehicle.RequestObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOXFleetTestApi.Controllers.Vehicle
{
    [Route("api/")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ISender Sender;
        
        public VehicleController(ISender sender)
        {
            Sender = sender;
        }
        
        [HttpPost("add-vehicle")]
        public async Task<IActionResult> AddVehicle(AddVehicleRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var commnad = request.MapToCommand(request);
            
            await Sender.Send(commnad, cancellationToken);

            return Ok("Vehicle Added.");
        }
        
        [HttpPost("vehicle-list")]
        public async Task<IActionResult> VehicleList(VehicleListRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var commnad = request.MapToQuery(request);
            
            var response = await Sender.Send(commnad, cancellationToken);

            return Ok(response);
        }
    }
}
