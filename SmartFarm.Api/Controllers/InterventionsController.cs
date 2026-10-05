namespace SmartFarm.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using SmartFarm.Application.DTOs;
using SmartFarm.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class InterventionsController : ControllerBase
{
    private readonly InterventionService _service;

    public InterventionsController(InterventionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInterventionDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }
}