using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantSystem.Application.Features.Tenants.Commands;
using MultiTenantSystem.Application.Features.Tenants.Queries;

namespace MultiTenantSystem.API.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TenantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateTenant")]
        public async Task<IActionResult> CreateTenant(CreateTenantCommand command)
        {
            var tenantId = await _mediator.Send(command);
            return Ok(tenantId);
        }

        [HttpGet("GetTenantById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTenantByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetAllTenant")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTenantQuery());
            return Ok(result);
        }

        /*[HttpPost("{tenantId}/users")]
        [Authorize(Roles = "TenantAdmin")]
        public async Task<IActionResult> RegisterTenantUser(Guid tenantId, RegisterTenantUserCommand command)
        {
            command = command with { TenantId = tenantId };
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }*/
    }
}
