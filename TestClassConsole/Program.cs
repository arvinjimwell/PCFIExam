using PCFI;
using static System.Console;
using Microsoft.EntityFrameworkCore;

using(EquityDbContext db = new())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    Equity model = new Equity(sPrice: 10000M, rDate: DateOnly.Parse("4/5/2022"), 5);
    db.Equities.Add(model);
    db.SaveChanges();

    var equity = db.Equities.First();
    WriteLine($"ID: {equity.Id}");
    WriteLine($"Selling Price: {equity.SellingPrice}");
    WriteLine($"Reservation Date: {equity.ReservationDate}");
    WriteLine($"Equity Term: {equity.Term}");
    WriteLine($"Monthly Amount: {equity.MonthlyAmount}");
    WriteLine($"Start Date: {equity.StartDate}");

    foreach(var item in equity.Schedules)
    {
        WriteLine();
        WriteLine($"ID: {item.Id}");
        WriteLine($"Term No: {item.TermNo}");
        WriteLine($"Balance: {item.Balance}");
        WriteLine($"DueDate: {item.DueDate}");
        WriteLine($"Payment Info: {item.PaymentInfo.Id}");
        WriteLine($"Amount: {item.PaymentInfo.Amount}");
        WriteLine($"Interest: {item.PaymentInfo.Interest}");
        WriteLine($"Insurance: {item.PaymentInfo.Insurance}");
        WriteLine($"Total: {item.PaymentInfo.Total}");
    }

    WriteLine("Update Selling Price");
    equity.UpdateSellingPrice(12000M);
    db.SaveChanges();

    equity = db.Equities.First();
    WriteLine($"ID: {equity.Id}");
    WriteLine($"Selling Price: {equity.SellingPrice}");
    WriteLine($"Reservation Date: {equity.ReservationDate}");
    WriteLine($"Equity Term: {equity.Term}");
    WriteLine($"Monthly Amount: {equity.MonthlyAmount}");
    WriteLine($"Start Date: {equity.StartDate}");

    foreach(var item in equity.Schedules)
    {
        WriteLine();
        WriteLine($"ID: {item.Id}");
        WriteLine($"Term No: {item.TermNo}");
        WriteLine($"Balance: {item.Balance}");
        WriteLine($"DueDate: {item.DueDate}");
        WriteLine($"Payment Info: {item.PaymentInfo.Id}");
        WriteLine($"Amount: {item.PaymentInfo.Amount}");
        WriteLine($"Interest: {item.PaymentInfo.Interest}");
        WriteLine($"Insurance: {item.PaymentInfo.Insurance}");
        WriteLine($"Total: {item.PaymentInfo.Total}");
    }

    WriteLine("Remove Term");
    equity.UpdateTerm(4);
    db.SaveChanges();

    equity = db.Equities.First();
    WriteLine($"ID: {equity.Id}");
    WriteLine($"Selling Price: {equity.SellingPrice}");
    WriteLine($"Reservation Date: {equity.ReservationDate}");
    WriteLine($"Equity Term: {equity.Term}");
    WriteLine($"Monthly Amount: {equity.MonthlyAmount}");
    WriteLine($"Start Date: {equity.StartDate}");

    foreach(var item in equity.Schedules)
    {
        WriteLine();
        WriteLine($"ID: {item.Id}");
        WriteLine($"Term No: {item.TermNo}");
        WriteLine($"Balance: {item.Balance}");
        WriteLine($"DueDate: {item.DueDate}");
        WriteLine($"Payment Info: {item.PaymentInfo.Id}");
        WriteLine($"Amount: {item.PaymentInfo.Amount}");
        WriteLine($"Interest: {item.PaymentInfo.Interest}");
        WriteLine($"Insurance: {item.PaymentInfo.Insurance}");
        WriteLine($"Total: {item.PaymentInfo.Total}");
    }

    WriteLine("Add Term");
    equity.UpdateTerm(5);
    db.SaveChanges();

    equity = db.Equities.First();
    WriteLine($"ID: {equity.Id}");
    WriteLine($"Selling Price: {equity.SellingPrice}");
    WriteLine($"Reservation Date: {equity.ReservationDate}");
    WriteLine($"Equity Term: {equity.Term}");
    WriteLine($"Monthly Amount: {equity.MonthlyAmount}");
    WriteLine($"Start Date: {equity.StartDate}");

    foreach(var item in equity.Schedules)
    {
        WriteLine();
        WriteLine($"ID: {item.Id}");
        WriteLine($"Term No: {item.TermNo}");
        WriteLine($"Balance: {item.Balance}");
        WriteLine($"DueDate: {item.DueDate}");
        WriteLine($"Payment Info: {item.PaymentInfo.Id}");
        WriteLine($"Amount: {item.PaymentInfo.Amount}");
        WriteLine($"Interest: {item.PaymentInfo.Interest}");
        WriteLine($"Insurance: {item.PaymentInfo.Insurance}");
        WriteLine($"Total: {item.PaymentInfo.Total}");
    }
}

