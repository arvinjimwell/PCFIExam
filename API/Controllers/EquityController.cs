using API.Extensions;
using API.Services;
using DtoModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EquityController(IEquityService equityService) : ControllerBase
{
    private readonly IEquityService _equityService = equityService;

    [HttpGet]
    public IActionResult Get()
    {
        var models = _equityService.GetEquities()?
            .ToDto();

        return Ok(models ?? []);
    }

    [HttpGet("{id}", Name = nameof(GetEquity))]
    public IActionResult GetEquity(int id)
    {
        var model = _equityService.GetEquity(id);
        return model is null ? BadRequest("Not Found!") : Ok(model.ToDto());
    }

    [HttpPost]
    public IActionResult Post([FromBody] EquityInputDto input)
    {
        if(input is null)
            return BadRequest();

        if(!input.IsValid(out string error))
            return BadRequest(error);

        var result = _equityService.CreateEquity(input.SellingPrice, input.ReservationDate, input.NoOfTerm);
        if(result.Item1)
        {
            var json = JsonSerializer.Serialize(result.Item2?.ToDto().Schedules);
            Response.Headers.TryAdd("equity-results", json);
        }

        return Ok(result.Item1);
    }

    [HttpPut]
    [Route("/api/[controller]/update/selling-price")]
    public IActionResult UpdateSellingPrice([FromBody] UpdateSellingPriceDto input)
    {
        if(input.SellingPrice <= 0)
            return BadRequest("Invalid Selling Price");

        var model = _equityService.UpdateSellingPrice(input.Id, input.SellingPrice);
        return model.Item1 ? Ok(model.Item2!.ToDto()) : BadRequest();
    }

    [HttpPut]
    [Route("/api/[controller]/update/term")]
    public IActionResult UpdateNoOfTerm([FromBody] UpdateNoOfTermDto input)
    {
        if(input.NoOfTerm <= 0)
            return BadRequest("Invalid No. Of Term");

        var result = _equityService.UpdateTerm(input.Id, input.NoOfTerm);
        return result.Item1 ? Ok(result.Item2!.ToDto()) : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _equityService.DeleteEquity(id);
        return result ? Ok() : BadRequest();
    }
}
