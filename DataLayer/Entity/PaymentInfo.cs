
namespace PCFI;

public class PaymentInfo
{
    public int Id { get; set; }
    public decimal Amount { get; private set; }
    public decimal Interest { get; private set; }
    public decimal Insurance { get; private set; }
    public decimal Total { get; private set; }

    public int ScheduleId { get; set; }
    public virtual EquitySchedule Schedule { get; set; } = null!;

    public PaymentInfo() { }
    public PaymentInfo(EquitySchedule schedule)
    {
        ScheduleId = schedule.Id;
        Schedule = schedule;
        UpdatePaymentInfo();
    }

    public void UpdatePaymentInfo()
    {
        Amount = Schedule.Equity.MonthlyAmount;
        Interest = Schedule.Balance * 0.05M;
        Insurance = Amount * 0.01M;
        Total = Amount + Interest + Insurance;
    }
}
