using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEquityDbContext(connectionString);
builder.Services.AddScoped<IEquityService, EquityService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Web.MVC.Policy", policy =>
    {
        policy.WithOrigins("https://localhost:5001");
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policyName: "Web.MVC.Policy");

app.MapControllers();

app.Run();
