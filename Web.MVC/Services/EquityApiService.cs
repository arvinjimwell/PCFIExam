using DtoModels;
using System.Text.Json;

namespace Web.MVC.Services;

public class EquityApiService(IHttpClientFactory httpCF)
{
    private readonly IHttpClientFactory _httpCF = httpCF;

    public async Task<IEnumerable<EquityScheduleDto>> CreateEquity(EquityInputDto input)
    {
        var content = JsonContent.Create(new
        {
            sellingPrice = input.SellingPrice,
            reservationDate = input.ReservationDate,
            noOfTerm = input.NoOfTerm
        });
        HttpResponseMessage response = await CallToApi(HttpMethod.Post, "api/Equity", content);
        return IfSuccessDeserializeHeader(response);
    }

    private IEnumerable<EquityScheduleDto> IfSuccessDeserializeHeader(HttpResponseMessage response)
    {
        if(!response.IsSuccessStatusCode)
            return [];

        var json = response.Headers.GetValues("equity-results");
        var model = JsonSerializer.Deserialize<IEnumerable<EquityScheduleDto>>(json.FirstOrDefault() ?? string.Empty);
        return model ?? [];
    }

    public async Task<IEnumerable<EquityDto>> GetEquities()
    {
        HttpResponseMessage response = await CallToApi(HttpMethod.Get, requestUri: "api/Equity");
        var model = await response.Content.ReadFromJsonAsync<IEnumerable<EquityDto>>();
        return model ?? [];
    }

    public async Task<bool> DeleteEquity(int id)
    {
        HttpResponseMessage response = await CallToApi(HttpMethod.Delete, $"api/Equity/{id}");
        return response.IsSuccessStatusCode;
    }

    private async Task<HttpResponseMessage> CallToApi(HttpMethod requestMethod, string requestUri, JsonContent? content = null)
    {
        HttpClient client = _httpCF.CreateClient(name: "PCFI.Api.Service");
        HttpRequestMessage request = new(method: requestMethod, requestUri: requestUri);
        if(content != null)
            request.Content = content;

        return await client.SendAsync(request);
    }
}
