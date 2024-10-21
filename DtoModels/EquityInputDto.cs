

namespace DtoModels;

public class EquityInputDto
{
    public decimal SellingPrice { get; set; }
    public DateOnly ReservationDate { get; set; }
    public int NoOfTerm { get; set; }

    public bool IsValid(out string errors)
    {
        errors = string.Empty;

        if(SellingPrice <= 0)
            errors = "Selling Price is not allowed";
        else if(ReservationDate.CompareTo(DateOnly.Parse(DateTime.Now.ToString("MM/dd/yyyy"))) < 0)
            errors = "Reservation Date is not valid";
        else if(NoOfTerm <= 0)
            errors = "No. of Term is not valid";

        return string.IsNullOrEmpty(errors);
    }
}
