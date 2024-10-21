using DtoModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web.MVC.Services;

public class EquityApiService(IHttpClientFactory httpCF)
{
    private readonly IHttpClientFactory _httpCF = httpCF;

    public async Task<IEnumerable<EquityScheduleDto>> CreateEquity(EquityInputDto input)
    {
        HttpClient client = _httpCF.CreateClient(name: "PCFI.Api.Service");
        var content = JsonContent.Create(new
        {
            sellingPrice = input.SellingPrice,
            reservationDate = input.ReservationDate,
            noOfTerm = input.NoOfTerm
        });
        HttpRequestMessage request = new(method: HttpMethod.Post, requestUri: "api/Equity");
        request.Content = content;
        HttpResponseMessage response = await client.SendAsync(request);
        var json = response.Headers.GetValues("equity-results");
        var model = JsonSerializer.Deserialize<IEnumerable<EquityScheduleDto>>(json.FirstOrDefault() ?? string.Empty);
        return model ?? [];
    }

    public async Task<IEnumerable<EquityDto>> GetEquities()
    {
        HttpClient client = _httpCF.CreateClient(name: "PCFI.Api.Service");
        HttpRequestMessage request = new(method: HttpMethod.Get, requestUri: "api/Equity");
        HttpResponseMessage response = await client.SendAsync(request);
        var model = await response.Content.ReadFromJsonAsync<IEnumerable<EquityDto>>();
        return model ?? [];
    }

    public async Task<bool> DeleteEquity(int id)
    {
        HttpClient client = _httpCF.CreateClient(name: "PCFI.Api.Service");
        HttpRequestMessage request = new(method: HttpMethod.Delete, requestUri: $"api/Equity/{id}");
        HttpResponseMessage response = await client.SendAsync(request);
        return response.IsSuccessStatusCode;
    }
}
