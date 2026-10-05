namespace SmartFarm.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using SmartFarm.Application.DTOs;
using SmartFarm.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class ParcellesController : ControllerBase
{
    private readonly ParcelleService _service;

    public ParcellesController(ParcelleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var parcelles = await _service.GetAllAsync();
        return Ok(parcelles);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateParcelleDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }
}