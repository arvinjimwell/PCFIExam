namespace DtoModels;

public class EquityDto
{
    public int Id { get; set; }
    public decimal SellingPrice { get; set; }
    public DateOnly ReservationDate { get; set; }
    public int Term { get; set; }
    public decimal MonthlyAmount { get; set; }
    public DateOnly StartDate { get; set; }
    public ICollection<EquityScheduleDto> Schedules { get; set; } = [];
}
