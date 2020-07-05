using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safcsp.Restaurant.Application.Attributes;
using Safcsp.Restaurant.Application.Dtos;
using Safcsp.Restaurant.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Safcsp.Restaurant.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Reservation")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _ctx;

        public ReservationController(IReservationService ctx)
        {
            _ctx = ctx;
        }

        [OperationOrder(1)]
        [Authorize]

        [HttpPost("CreateReservation")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(CreateReservation), 200)]
        [ProducesResponseType(400)]

        public async Task<IActionResult> CreateReservation([FromBody] CreateReservation dto)
        {
            try
            {
                var Result = await _ctx.CreateReservation(dto);
                if (!Result)
                {
                    return BadRequest();
                }
            }
            catch {

                return BadRequest();
            }


            return Created(string.Empty, string.Empty);

        }
    }
}
