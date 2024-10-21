

namespace DtoModels;

public class EquityScheduleDto
{
    public decimal Balance { get; set; }
    public int TermNo { get; set; }
    public DateOnly DueDate { get; set; }
    public PaymentInfoDto PaymentInfo { get; set; } = null!;
}
