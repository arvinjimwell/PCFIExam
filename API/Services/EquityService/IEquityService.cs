using PCFI;

namespace API.Services;

public interface IEquityService
{
    IEnumerable<Equity> GetEquities();

    Equity? GetEquity(int id);

    (bool, Equity?) CreateEquity(decimal sPrice, DateOnly rDate, int noOfTerm);
    bool DeleteEquity(int id);
    (bool, Equity?) UpdateSellingPrice(int id, decimal price);
    (bool, Equity?) UpdateTerm(int id, int term);
}
