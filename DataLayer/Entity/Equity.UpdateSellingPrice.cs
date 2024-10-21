using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCFI;

public partial class Equity
{
    public void UpdateSellingPrice(decimal price)
    {
        SellingPrice = price;
        SetMonthAmount();
        foreach(var s in Schedules)
        {
            s.UpdateBalance();
        }
    }
}
