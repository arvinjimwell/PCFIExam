using DtoModels;
using Microsoft.EntityFrameworkCore;
using PCFI;

namespace API.Services;

public class EquityService(EquityDbContext db) : IEquityService
{
    private readonly EquityDbContext _db = db;

    public IEnumerable<Equity> GetEquities()
    {
        return _db.Equities.AsNoTracking()
            .Include(m => m.Schedules)
            .AsNoTracking();
    }

    public Equity? GetEquity(int id)
    {
        return _db.Equities.Include(m => m.Schedules)
            .FirstOrDefault(m => m.Id == id);
    }

    public (bool, Equity?) CreateEquity(decimal sPrice, DateOnly rDate, int noOfTerm)
    {
        Equity model = new(sPrice, rDate, noOfTerm);
        var temp = _db.Equities.Add(model);
        return (_db.SaveChanges() > 0, GetEquity(temp.Entity.Id));
    }

    public bool DeleteEquity(int id)
    {
        var model = _db.Equities.Find(id);
        if(model is null)
            return true;

        _db.Equities.Remove(model);
        return _db.SaveChanges() > 0;
    }


    public (bool, Equity?) UpdateSellingPrice(int id, decimal price)
    {
        var model = GetEquity(id);
        if(model is null)
            return (false, null);

        model.UpdateSellingPrice(price);
        return _db.SaveChanges() > 0 ? (true, model) : (false, null);
    }

    public (bool, Equity?) UpdateTerm(int id, int term)
    {
        var model = GetEquity(id);
        if(model is null)
            return (false, null);

        model.UpdateTerm(term);
        return _db.SaveChanges() > 0 ? (true, model) : (false, null);
    }
}
