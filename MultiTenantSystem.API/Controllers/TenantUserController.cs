using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantSystem.Application.Features.Users.Commands;

namespace MultiTenantSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class TenantUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*[HttpPost("tenants/addEdit")]
        public async Task<IActionResult> AddOrUpdateTenantAdmin(Guid tenantId, [FromBody] CreateOrUpdateTenantAdminCommand cmd)
        {
            var result = await _mediator.Send(cmd with { TenantId = tenantId });
            return Ok(result);
        }*/

        [HttpPost("addEdit")]
        public async Task<IActionResult> AddOrUpdateTenantAdmin([FromBody] CreateOrUpdateTenantAdminCommand cmd)
        {
            var result = await _mediator.Send(cmd);
            return Ok(result);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTenantAdmin(Guid tenantId)
        {
            var result = await _mediator.Send(new DeleteTenantAdminCommand(tenantId));
            return result ? Ok("Deleted") : NotFound("Tenant admin not found");
        }
    }
}
