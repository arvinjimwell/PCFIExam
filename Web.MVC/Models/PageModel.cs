using DtoModels;

namespace Web.MVC.Models;

public class PageModel
{
    public IEnumerable<EquityScheduleDto> Results { get; set; } = [];
    public IEnumerable<EquityDto> Equities { get; set; } = [];
}
