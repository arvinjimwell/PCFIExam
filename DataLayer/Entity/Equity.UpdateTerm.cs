using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCFI;

public partial class Equity
{
    public void UpdateTerm(int term)
    {
        if(term == Term)
            return;

        int tempTerm = Term;
        Term = term;
        SetMonthAmount();
        foreach(var s in Schedules)
        {
            s.UpdateBalance();
        }

        if(tempTerm < Term)
        {
            for(int i = tempTerm + 1; i <= Term; i++)
            {
                Schedules.Add(new(balance: GetTermBalance(i), i, this));
            }
        }
        else
        {
            for(int i = Term + 1; i <= tempTerm; i++)
            {
                var s = Schedules.First(s => s.TermNo == i);
                Schedules.Remove(s);
            }
        }
    }
}
