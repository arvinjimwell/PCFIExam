
using Microsoft.VisualBasic;
using System.ComponentModel;

namespace PCFI;

public class EquitySchedule
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public int TermNo { get; init; }
    public DateOnly DueDate { get; private set; }

    public int EquityId { get; set; }
    public virtual Equity Equity { get; set; } = null!;

    public EquitySchedule() { }
    public EquitySchedule(decimal balance, int termNo, Equity equity)
    {
        Balance = balance;
        TermNo = termNo;
        EquityId = equity.Id;
        Equity = equity;
        SetDueDate();
    }
    
    public void SetDueDate() =>
        DueDate = Equity.ReservationDate.AddMonths(TermNo);

    public void UpdateBalance() =>
        Balance = Equity.SellingPrice - (Equity.MonthlyAmount * TermNo);

    public decimal GetTotal() =>
        GetAmount() + GetInterest() + GetInsurance();

    public decimal GetAmount() =>
        Equity.MonthlyAmount;

    public decimal GetInterest() =>
        Balance * 0.05M;

    public decimal GetInsurance() =>
        GetAmount() * 0.01M;

}
