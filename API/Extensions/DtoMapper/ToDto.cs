using DtoModels;
using PCFI;

namespace API.Extensions;

public static class DtoMapper
{
    public static EquityDto ToDto(this Equity model)
    {
        return new()
        {
            Id = model.Id,
            SellingPrice = model.SellingPrice,
            MonthlyAmount = model.MonthlyAmount,
            ReservationDate = model.ReservationDate,
            StartDate = model.StartDate,
            Term = model.Term,
            Schedules = model.Schedules.MapScheduleDto().ToList()
        };
    }

    private static IEnumerable<EquityScheduleDto> MapScheduleDto(this ICollection<EquitySchedule> schedules)
    {
        return schedules.Select<EquitySchedule, EquityScheduleDto>(s => new()
        {
            Balance = s.Balance,
            DueDate = s.DueDate,
            TermNo = s.TermNo,
            PaymentInfo = new()
            {
                Amount = s.GetAmount(),
                Insurance = s.GetInsurance(),
                Interest = s.GetInterest(),
                Total = s.GetTotal()
            }
        });
    }

    public static IEnumerable<EquityDto> ToDto(this IEnumerable<Equity> models)
    {
        return models.Select(m => m.ToDto()).ToList();
    }
}
