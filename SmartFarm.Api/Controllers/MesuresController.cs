namespace SmartFarm.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using SmartFarm.Application.DTOs;
using SmartFarm.Application.Services;

[ApiController]
[Route("api/[controller]")]
public class MesuresController : ControllerBase
{
    private readonly MesureCapteurService _service;

    public MesuresController(MesureCapteurService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMesureCapteurDto dto)
    {
        var id = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }
}