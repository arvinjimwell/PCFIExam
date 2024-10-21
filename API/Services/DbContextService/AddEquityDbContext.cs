using PCFI;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public static class ApiServices
{
    public static IServiceCollection AddEquityDbContext(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<EquityDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

        return services;
    }
}
