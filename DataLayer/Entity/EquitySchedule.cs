
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
    
    public int PaymentInfoId { get; set; }
    public virtual PaymentInfo PaymentInfo { get; init; } = null!;

    public EquitySchedule() { }
    public EquitySchedule(decimal balance, int termNo, Equity equity)
    {
        Balance = balance;
        TermNo = termNo;
        EquityId = equity.Id;
        Equity = equity;
        PaymentInfo = new(this);
        SetDueDate();
    }
    
    public void SetDueDate()
    {
        DueDate = Equity.ReservationDate.AddMonths(TermNo);
    }

    public void UpdateBalance()
    {
        Balance = Equity.SellingPrice - (Equity.MonthlyAmount * TermNo);
    }

    
}
