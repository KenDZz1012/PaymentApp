using PaymentApplication.ConfigEnv;
using PaymentApplication.DI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureMediatR();
builder.Services.ConfigFluentValidation(typeof(Assembly).Assembly);
builder.Services.ConfigureServices();
builder.Services.AddScoped<Config_VNPay>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x
     .AllowAnyMethod()
     .AllowAnyHeader()
     .SetIsOriginAllowed(origin => true) // allow any origin
     .AllowCredentials()); // allow credentials
app.UseAuthorization();

app.MapControllers();

app.Run();
