using DtoModels;

namespace Web.MVC.Models;

public class PageModel
{
    public EquityDto? TermUpdateResult { get; set; }
    public EquityDto? SPUpdateResult { get; set; }
    public IEnumerable<EquityScheduleDto> CreateResults { get; set; } = [];
    public IEnumerable<EquityDto> Equities { get; set; } = [];
}
