using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VerticalSliceArchitectureCQRSMediatRCarter.Contracts;
using VerticalSliceArchitectureCQRSMediatRCarter.Database;
using VerticalSliceArchitectureCQRSMediatRCarter.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddSingleton<CarterConfigurator>(); 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
CreateBook.AddEndpoint(app);
GetAllBooks.AddEndpoint(app);
//app.MapCarter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
