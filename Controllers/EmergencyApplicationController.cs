using AybukeYalcinAnaokulu.Core.Models;
using AybukeYalcinAnaokulu.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace AybukeYalcinAnaokulu.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/[controller]/[action]")]
[ApiController]
public class EmergencyApplicationController : ControllerBase
{
    public MongoDBService _mongoDBService { get; }
    public EmergencyApplicationController(MongoDBService mongoDBService)
    {
        this._mongoDBService = mongoDBService ?? throw new ArgumentNullException(nameof(mongoDBService));
    }

    [HttpGet]
    public async Task<List<EmergencyApplicationForm>> Get() 
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EmergencyApplicationForm applicationForm) 
    {
        await _mongoDBService.CreateAsync(applicationForm);
        return CreatedAtAction(nameof(Get), new { id = applicationForm.Id, applicationForm });
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(string Id) 
    {
        await _mongoDBService.DeleteAsync(Id);
        return NoContent();
    }

    
}
