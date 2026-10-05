namespace SmartFarm.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using SmartFarm.Application.DTOs;
using SmartFarm.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class CulturesController : ControllerBase
{
    private readonly CultureService _service;

    public CulturesController(CultureService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCultureDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }
}