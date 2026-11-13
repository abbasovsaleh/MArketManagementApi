using MarketManagement.DTOs.Stores;
using MarketManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _service;

    public StoreController(IStoreService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var store = await _service.GetByIdAsync(id);

        if (store == null)
            return NotFound();

        return Ok(store);
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateStoreDto dto)
    {
        try
        {
            await _service.AddAsync(dto);
            return Ok("Store added successfully");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateStoreDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (!result)
            return NotFound();

        return Ok("Store updated successfully");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return Ok("Store deleted successfully");
    }
}