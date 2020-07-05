using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Safcsp.Restaurant.Application.Attributes;
using Safcsp.Restaurant.Application.Dtos;
using Safcsp.Restaurant.Application.Interfaces;
using Safcsp.Restaurant.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Safcsp.Restaurant.Api.Controllers
{
    [ApiVersion("1.0")]

    [ApiExplorerSettings(GroupName = "Athentication")]

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _ctx;

        public AuthController(IAuthService ctx)
        {
            _ctx = ctx;
        }


        /// <summary>
        /// user registration method to create new user 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("signup")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(UserSignUp), 200)]
        [ProducesResponseType(500)]
        [OperationOrder(5)]


        public async Task<IActionResult> SignUp([FromBody] UserSignUp dto)
        {

            var userCreateResult = await _ctx.CreateUser(dto);

            if (userCreateResult.Succeeded)
            {
                return Created(string.Empty, string.Empty);
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }


        /// <summary>
        /// login method 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("SignIn")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(UserSignUp), 200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [OperationOrder(4)]

        public async Task<IActionResult> SignIn([FromBody] UserSignIn dto)
        {
            var user = _ctx.CheckUser(dto);
            if (user is null)
            {
                return NotFound("User not found");
            }

            var userSigninResult = await _ctx.CheckUserPassword(user, dto);

            if (userSigninResult)
            {
                return Ok();
            }

            return BadRequest("Email or password incorrect.");
        }


        [HttpPost("Roles")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [OperationOrder(3)]

        public async Task<IActionResult> CreateRole([FromQuery]string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest("Role name should be provided.");
            }
            try
            {
                var roleResult = await _ctx.CreateRole(roleName);

                if (!roleResult.Succeeded)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            return Ok();

        }


        [HttpPost("User/Role")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(typeof(UserRole), 200)]
        [ProducesResponseType(400)]
        [OperationOrder(2)]

        public async Task<IActionResult> AddUserToRole([FromBody] UserRole userRole)
        {
            try
            {
                var result = await _ctx.AssginRoleToUser(userRole);

                if (!result.Succeeded)
                {
                    return BadRequest();
                }
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("jwt")]
        [MapToApiVersion("1.0")]
        [OperationOrder(1)]
        [ProducesResponseType(typeof(UserSignIn), 200)]
        [ProducesResponseType(400)]
        
        public async Task<IActionResult> GenrateJwtToken([FromBody] UserSignIn dto)
        {
            try
            {
                var user = _ctx.CheckUser(dto);

                if (user != null)
                {
                  var token =  await _ctx.GenerateJwtToken(user);
                    return Ok(token);
                }
            }
            catch
            {
                return BadRequest();
            }
            return Ok();
        }


    }
}
