using Companies.Api.Controllers.Requests;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rusell.Companies.Application;
using Rusell.Companies.Application.Create;
using Rusell.Companies.Application.Find;
using Rusell.Companies.Application.FindByNit;

namespace Companies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CompaniesController> _logger;

    public CompaniesController(IMediator mediator, ILogger<CompaniesController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyResponse>> GetCompany(string id)
    {
        var company = await _mediator.Send(new FindCompanyQuery(id));
        if (company is null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpGet("by_nit/{nit}")]
    public async Task<ActionResult<CompanyResponse>> GetCompanyByNit(string nit)
    {
        var company = await _mediator.Send(new FindCompanyByNitQuery(nit));
        if (company is null)
        {
            return NotFound();
        }

        return Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        try
        {
            var command = request.Adapt<CreateCompanyCommand>();
            await _mediator.Send(command);
        }
        catch (DbUpdateException e)
        {
            _logger.LogError(e, "Error creating company");
            return BadRequest();
        }

        return Ok();
    }
}