using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiTenantSystem.Application.DTOs;
using MultiTenantSystem.Application.Features.Employee.Commands;
using MultiTenantSystem.Application.Features.Employee.Queries;

namespace MultiTenantSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _http;

        public EmployeeController(IMediator mediator, IHttpContextAccessor http)
        {
            _mediator = mediator;
            _http = http;
        }

        private Guid GetTenantIdFromClaims()
        {
            var claim = _http.HttpContext?.User?.FindFirst("TenantId")?.Value;
            return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException("Invalid tenant");
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            var tenantId = GetTenantIdFromClaims();
            var id = await _mediator.Send(new CreateEmployeeCommand(dto, tenantId));
            return Ok(id);
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAll()
        {
            var tenantId = GetTenantIdFromClaims();
            var result = await _mediator.Send(new GetEmployeeQuery(tenantId));
            return Ok(result);
        }

        [HttpPut("UpdateEmployee/{id}")]
        public async Task<IActionResult> Update(Guid id, CreateEmployeeDto dto)
        {
            var tenantId = GetTenantIdFromClaims();
            await _mediator.Send(new UpdateEmployeeCommand(id, dto, tenantId));
            return NoContent();
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tenantId = GetTenantIdFromClaims();
            await _mediator.Send(new DeleteEmployeeCommand(id, tenantId));
            return NoContent();
        }
    }
}
