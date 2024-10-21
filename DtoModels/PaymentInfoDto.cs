using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoModels;

public class PaymentInfoDto
{
    public decimal Amount { get; set; }
    public decimal Interest { get; set; }
    public decimal Insurance { get; set; }
    public decimal Total { get; set; }
}
