
namespace PCFI;

public partial class Equity
{
    public int Id { get; set; }
    public decimal SellingPrice { get; private set; }
    public DateOnly ReservationDate { get; private set; }
    public int Term { get; private set; }
    public decimal MonthlyAmount { get; private set; }
    public DateOnly StartDate { get; private set; }
    public virtual ICollection<EquitySchedule> Schedules { get; private set; } = [];

    public Equity() { }
    public Equity(decimal sPrice, DateOnly rDate, int term)
    {
        SellingPrice = sPrice;
        ReservationDate = rDate;
        Term = term;
        SetMonthAmount();
        SetStartDate();
        SetSchedules();
    }

    private void SetMonthAmount() =>
        MonthlyAmount = SellingPrice / Term;

    private void SetStartDate() =>
        StartDate = ReservationDate.AddMonths(1);


    private void SetSchedules()
    {
        for(int i = 1; i <= Term; i++)
        {
            Schedules.Add(new(balance: GetTermBalance(i), i, this));
        }
    }

    private decimal GetTermBalance(int termNo) =>
        SellingPrice - ( MonthlyAmount * termNo );
}
